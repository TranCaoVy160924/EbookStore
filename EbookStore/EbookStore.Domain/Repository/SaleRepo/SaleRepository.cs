using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Sale.Response;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Data.EF;
using EbookStore.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.Mail;
using System.Net;
using EbookStore.Domain.Repository.WishlistRepo;
using static System.Reflection.Metadata.BlobBuilder;

namespace EbookStore.Domain.Repository.SaleRepo;
public class SaleRepository : ISaleRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IWishlistRepository _wishlistRepo;
    private readonly IMapper _mapper;

    public SaleRepository(
        EbookStoreDbContext dbContext,
        IWishlistRepository wishlistRepo,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _wishlistRepo = wishlistRepo;
        _mapper = mapper;
    }

    #region UpdateAsync
    public async Task UpdateExtendSaleAsync(SaleExtendRequest updateRequest)
    {
        Sale updateExtendSale = await _dbContext.Sales
            .QueryId(updateRequest.SaleId)
            .FirstOrDefaultAsync();


        if (updateExtendSale != null)
        {
            try
            {
                UpdateExtendSale(updateExtendSale, updateRequest);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        else
        {
            throw new Exception("Update extend date sale fail!");
        }
    }
    private static void UpdateExtendSale(Sale sale, SaleExtendRequest saleExtendRequest)
    {
        sale.EndDate = saleExtendRequest.NewEndDate;
    }
    #endregion

    #region GetOneAsync
    public async Task<SaleDetailResponse> GetOneAsync(int saleId)
    {
        Sale sale = await _dbContext.Sales
            .QueryId(saleId)
            .Include(x => x.Books)
            .FirstOrDefaultAsync();

        if (sale != null)
        {
            return _mapper.Map<SaleDetailResponse>(sale);
        }
        else
        {
            throw new Exception("Sale dont exist");
        }
    }
    #endregion

    #region CreateAsync
    public async Task CreateAsync(SaleCreateRequest createRequest)
    {
        Sale sale = _mapper.Map<Sale>(createRequest);
        List<Sale> oldSale = new List<Sale>();
        List<Book> books = await CheckBookForAddingToSale(createRequest.BookIds);

        if (books.Count > 0)
        {
            foreach (Book book in books)
            {
                if (oldSale != null)
                {
                    oldSale.Add(book.Sale);
                }
                book.Sale = sale;
            }

            sale.Books = books;
            _dbContext.Sales.Add(sale);
            await _dbContext.SaveChangesAsync();

            await NotifyUserByEmail(books);
        }
        else
        {
            throw new Exception("No book in sale");
        }
    }

    private async Task<List<Book>> CheckBookForAddingToSale(List<int> bookIds)
    {
        List<Book> books = new List<Book>();

        foreach (int bookId in bookIds)
        {
            Book book = await _dbContext.Books
                .Include(b => b.Sale)
                .FirstOrDefaultAsync(b => b.BookId == bookId);
            if (book != null)
            {
                if (book.SaleId != null && DateTime.Compare(book.Sale.EndDate, DateTime.Today) >= 0)
                {
                    throw new Exception("Book already has a sale assigned.");
                }
                books.Add(book);
            }
            else
            {
                throw new Exception($"Book with id {bookId} does not exist.");
            }
        }

        return books;
    }

    private async Task NotifyUserByEmail(List<Book> books)
    {
        foreach (Book book in books)
        {
            List<User> wishers = await _wishlistRepo.GetWishersAsync(book.BookId);
            List<string> wisherEmails = wishers.Select(u => u.Email).ToList();
            _wishlistRepo.SendSaleNotifyEmail(wisherEmails, book.Title);
        }
    }
    #endregion

    #region GetSalesAsync
    public async Task<PagedList<SaleResponse>> GetSalesAsync(SaleQueryRequest queryRequest)
    {
        if (DateTime.Compare(queryRequest.EndDate, DateTime.Today) <= 0
            || queryRequest.EndDate == DateTime.MaxValue)
        {
            queryRequest.EndDate = DateTime.Now;
        }
        IQueryable<Sale> query = _dbContext.Sales
            .Include(s => s.Books)
            .QueryName(queryRequest.Name)
            .QuerySaleDate(queryRequest.StartDate, queryRequest.EndDate)
            .AsQueryable();

        var paginatedResult = await query.PaginateResultAsync(queryRequest);
        return paginatedResult.MapResultToResponse<Sale, SaleResponse>(_mapper);
    }
    #endregion
}