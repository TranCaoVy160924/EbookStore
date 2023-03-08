using AutoMapper.Internal;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.User.Request;
using EbookStore.Contract.ViewModel.User.Response;
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

namespace EbookStore.Client.RefitClient;
[Headers("Content-Type: application/json")]

public interface IUserClient
{
    [Post("/User/")]
    Task<UserRegisterResponse> RegisterAsync([Body] UserRegisterRequest registerRequest);
    [Post("/User/auth/token/")]
    Task<string> AuthenticateAsync([Body] UserLoginRequest loginRequest);

    [Post("/User/Search/")]
    Task<ApiResponse<List<UserQueryResponse>>> GetResponseAsync([Body] UserQueryRequest queryRequest,
        [Header("Authorization")] string jwtToken);

    [Post("/User/Ban")]
    Task<ApiResponse<List<UserQueryResponse>>> BanAsync([Body] UserQueryRequest userQueryRequest,
        [Header("Authorization")] string jwtToken);

}
