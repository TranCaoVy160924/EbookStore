using EbookStore.Contract.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Book.BookQueryRequest;

public class BookQueryRequest: QueryStringParameters
{
    public string? Title { get; set; } = "";
    public List<int> Genres { get; set; } = new List<int>();
    public DateTime StartReleaseDate { get; set; } = DateTime.MinValue;
    public DateTime EndReleaseDate { get; set; } = DateTime.MaxValue;
}
