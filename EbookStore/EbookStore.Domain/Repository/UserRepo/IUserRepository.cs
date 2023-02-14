using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository;

public interface IUserRepository
{
    Task<UserRegisterResponse> CreateAsync(UserRegisterRequest request);
    Task<bool> IsDuplicateUserNameAsync(string username);
    Task<User> FindUserFromLoginRequestAsync(UserLoginRequest request);
    Task<string> CreateTokenAsync(User user);
}
