using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model
{
    public class CartItem
    {
        public Guid UserID { get; set; }
        public int BookID { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
