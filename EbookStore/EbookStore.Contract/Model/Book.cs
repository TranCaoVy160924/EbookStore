using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public Boolean IsActive { get; set; }
    public int SaleId { get; set; }
    public int NumberOfPage { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string PdfLink { get; set; }
    public string EpubLink { get; set; }
    public DateTime ReleaseDate { get; set; }

    public virtual List<BookGenre> BookGenres { get; set; }

    public virtual List<WishItem>? WishItems { get; set; }

    public virtual List<LibraryItem>? LibraryItems { get; set; }

    public virtual List<CartItem>? CartItems { get; set; }

    public virtual Sale Sale { get; set; }
}