using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.RefitClient;

public interface IUserClient
{
    [Post("/User/")]
    Task<UserRegisterResponse> RegisterAsync([Body] UserRegisterRequest registerRequest);
    [Get("/User/")]
    Task<UserRegisterResponse> loginAsync([Query] UserLoginRequest loginRequest);
}
