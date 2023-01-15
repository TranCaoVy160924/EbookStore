using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public List<Genre> Genres { get; set; }

        public List<WishItem> WishList { get; set; }

        public List<LibraryItem> Library { get; set; }
    }
}
