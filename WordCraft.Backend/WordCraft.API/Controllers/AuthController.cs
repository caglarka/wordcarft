using Microsoft.AspNetCore.Mvc;
using WordCraft.API.Controllers.Base;
using WordCraft.Core.Models.Dtos.Requests;
using WordCraft.Service.Services.WordCraft.AuthServices;

namespace WordCraft.API.Controllers
{
    [Route("api/[controller]")]

    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginReqDto model)
        {
            var response = await _authService.Login(model);
            return CreateActionResult(response);
        }
    }
}
