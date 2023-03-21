using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Book.Response;
public class BookDetailResponse
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int NumberOfPage { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string PdfLink { get; set; }
    //public string EpubLink { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int? SaleId { get; set; }
    public double? SalePercent { get; set; }
}
