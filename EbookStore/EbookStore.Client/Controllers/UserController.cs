using EbookStore.Client.Models;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class UserController : Controller
{
    private readonly IUserClient _userClient;

    public UserController(IUserClient userClient)
    {
        _userClient = userClient;
    }

}
