using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.SaleRepo;
public class SaleRepository : ISaleRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public SaleRepository(EbookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task CreateBookSaleAsync(SaleCreateRequest createRequest, List<int> bookIds)
    {
        Sale sale = _mapper.Map<Sale>(createRequest);
        List<Book> books = new List<Book>();
        foreach (int bookId in bookIds)
        {
            Book book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            if (book != null)
            {
                books.Add(book);
            }
        }
        sale.Books = books;
        _dbContext.Sales.Add(sale);
        await _dbContext.SaveChangesAsync();
    }
}