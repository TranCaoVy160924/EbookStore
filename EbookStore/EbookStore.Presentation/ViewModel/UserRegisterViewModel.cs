using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Presentation.RefitClient;
using System;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.ViewModel;

public class UserRegisterViewModel
{
    private readonly IUserClient _userClient;
    public UserRegisterRequest RegisterRequest { get; set; }

    public UserRegisterViewModel(IUserClient userClient)
    {
        _userClient = userClient;
        RegisterRequest = new UserRegisterRequest()
        {
            UserName = string.Empty,
            FirstName = string.Empty,
            LastName = string.Empty,
            Password = string.Empty,
            ConfirmPassword = string.Empty,
            Email = string.Empty,
            PhoneNumber = string.Empty
        };
    }

    public async Task RegisterUserAsync()
    {
        try
        {
            UserRegisterResponse user = await _userClient.RegisterAsync(RegisterRequest);

        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
