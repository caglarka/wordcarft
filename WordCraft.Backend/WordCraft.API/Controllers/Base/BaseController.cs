using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WordCraft.API.Controllers.Base
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(Core.Models.BaseResponseModels.CustomResponse<T> response)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
                return new ObjectResult(null)
                {
                    StatusCode = (int)response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        //[NonAction]
        //public ClaimModel GetCurrentUser() => User.GetCurrentUser();
    }
}
