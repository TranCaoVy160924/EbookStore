using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.User.UserLoginRequest
{
    public class UserLoginRequest
    {
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Invalid username")]
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Invalid password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}
