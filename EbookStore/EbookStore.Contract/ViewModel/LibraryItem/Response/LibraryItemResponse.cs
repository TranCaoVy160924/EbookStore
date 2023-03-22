using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.LibraryItem.Response;
public class LibraryItemResponse
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string CoverImage { get; set; }
    public string PdfLink { get; set; }
}
