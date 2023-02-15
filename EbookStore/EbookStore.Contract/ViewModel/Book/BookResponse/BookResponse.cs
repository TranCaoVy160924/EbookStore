using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.Book.BookResponse;
public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}
