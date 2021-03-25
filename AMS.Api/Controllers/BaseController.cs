using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AMS.Core.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        protected async Task<IActionResult> GetResponse(Func<string,Task<ApiResponseViewModel>> func)
        {

            var userId = User.FindFirst(ClaimTypes.Sid)?.Value ?? "UnKnown";

           return Ok(await func(userId));
        }
            



        protected IActionResult GetResponse(Func<string,ApiResponseViewModel> func)
        {
            var userId = User.FindFirst(ClaimTypes.Sid)?.Value ?? "UnKnown";

            return Ok(func(userId));
        }
            

        // string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    }
}
