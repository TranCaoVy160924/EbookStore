using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public Boolean IsActive { get; set; }
        public int SaleID { get; set; }
        public int NumberOfPage { get; set; }
        public double Price { get; set; }
        public string CoverImage { get; set; }
        public string PdfLink { get; set; }
        public string EpubLink { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<Genre>? Genres { get; set; }

        public List<WishItem>? Wisher { get; set; }

        public List<LibraryItem>? Owners { get; set; }

        public List<CartItem>? Shoppers { get; set; }

        public Sale? Sale { get; set; }
    }
}
