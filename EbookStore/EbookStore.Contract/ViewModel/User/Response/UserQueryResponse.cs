using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.User.Response;
public class UserQueryResponse
{
    public int UserId { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }

}
