using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookStore.Contract.Model
{
    public class User: IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public List<WishItem>? WishList { get; set; }

        public List<LibraryItem>? Library { get; set; }

        public List<CartItem>? Cart { get; set; }
    }
}
