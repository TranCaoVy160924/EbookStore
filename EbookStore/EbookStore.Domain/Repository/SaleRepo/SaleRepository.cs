using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Sale.Response;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EbookStore.Domain.Repository.SaleRepo;
public class SaleRepository : ISaleRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public SaleRepository(
        EbookStoreDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
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
            }catch(Exception ex)
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

    public async Task CreateBookSaleAsync(SaleCreateRequest createRequest)
    {
        Sale sale = _mapper.Map<Sale>(createRequest);
        List<Book> books = new List<Book>();
        List<int> bookIds = createRequest.BookIds;
        foreach (int bookId in bookIds)
        {
            Book book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            if (book != null)
            {
                books.Add(book);
            }
            else
            {
                throw new Exception("Book dont exist");
            }
        }
        sale.Books = books;
        _dbContext.Sales.Add(sale);
        await _dbContext.SaveChangesAsync();
        foreach (Book book in books)
        {
            book.SaleId = sale.SaleId;
        }
        await _dbContext.SaveChangesAsync();
    }
}
