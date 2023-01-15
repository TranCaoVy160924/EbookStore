using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model
{
    public class WishItem
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool InCart { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }
    }
}
