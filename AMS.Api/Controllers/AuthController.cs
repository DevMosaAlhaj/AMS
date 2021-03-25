using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Dto.AuthDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    public class AuthController : BaseController
    {

        private readonly IAuthService _service;

        public AuthController (IAuthService service)
        {
            _service = service;
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true,"Login Successfully",await _service.Login(dto)));

        [HttpPost]
        public async Task<IActionResult> Logout ([FromBody] string accessToken)
            => await GetResponse(async (userId) => 
            new ApiResponseViewModel(true, "Logout Successfully", await _service.Logout(accessToken)));

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
            =>  await GetResponse( async (userId) =>
            new ApiResponseViewModel(true, "Token Refreshed Successfully", await _service.RefreshToken(refreshToken)));

        [HttpPost("userId")]
        public async Task<IActionResult> RegisterFcm(string userId , [FromBody] string fcmToken)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "FCM Token Registerd Successfully", await _service.RegisterFcmToken(userId,fcmToken)));


    }
}
