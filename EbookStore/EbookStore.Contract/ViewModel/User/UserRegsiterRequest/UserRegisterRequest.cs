using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.ViewModel.User.UserRegsiterRequest;

public class UserRegisterRequest
{
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters!")]
    [Required(ErrorMessage = "Please enter username")]
    public string UserName { get; set; }

    [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters!")]
    [Required(ErrorMessage = "Please enter first name")]
    public string FirstName { get; set; }

    [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters!")]
    [Required(ErrorMessage = "Please enter last name")]
    public string LastName { get; set; }

    [DataType(DataType.Password, ErrorMessage = "Invalid password")]
    [Required(ErrorMessage = "Please enter password")]
    public string Password { get; set; }

    [DataType(DataType.Password, ErrorMessage = "Invalid password")]
    [Required(ErrorMessage = "Please confirm password")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.EmailAddress, ErrorMessage = "Invalid rmail address")]
    [EmailAddress(ErrorMessage = "Invalid rmail address")]
    [Required(ErrorMessage = "Please enter email")]
    public string Email { get; set; }

    [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone number")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [Required(ErrorMessage = "Please enter phone number")]
    public string PhoneNumber { get; set; }
}
