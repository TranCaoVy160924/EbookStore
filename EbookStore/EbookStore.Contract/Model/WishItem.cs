using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Model;

public class WishItem
{
    public Guid UserId { get; set; }
    public int BookId { get; set; }
    public bool IsActive { get; set; }

    public virtual User User { get; set; }
    public virtual Book Book { get; set; }
}
