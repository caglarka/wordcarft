using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordCraft.API.Controllers.Base;
using WordCraft.Service.Services.WordCraft.UserServices;

namespace WordCraft.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return CreateActionResult(response);
        }
    }
}
