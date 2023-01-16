using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;

namespace EbookStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EbookStoreDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(
            EbookStoreDbContext dbContext, 
            UserManager<User> userManager, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                FirstName = registerRequest.FirstName.Trim(),
                LastName = registerRequest.LastName.Trim(),
                UserName = registerRequest.UserName.Trim(),
                Email = registerRequest.Email.Trim(),
                PhoneNumber = registerRequest.PhoneNumber.Trim(),
                SecurityStamp = registerRequest.FirstName,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            var resultRole = await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded && resultRole.Succeeded)
            {
                return Ok(_mapper.Map<UserRegisterResponse>(user));
            }

            return BadRequest("Create user unsuccessfully!");
        }
    }
}
