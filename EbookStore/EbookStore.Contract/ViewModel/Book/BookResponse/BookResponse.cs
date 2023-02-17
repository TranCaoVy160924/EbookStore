using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EbookStore.Contract.ViewModel.Book.BookResponse;
public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public int SalePercent { get; set; }
    public int NumberOfPage { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}
