using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace EbookStore.Contract.Model;

public class User: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }

    public virtual List<WishItem>? WishItems { get; set; }

    public virtual List<LibraryItem>? LibraryItems { get; set; }

    public virtual List<CartItem>? CartItems { get; set; }
}
