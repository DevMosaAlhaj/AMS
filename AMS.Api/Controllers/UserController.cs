using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll Users Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get User Successfully", await _service.Get(id)));


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "User Created Successfully", await _service.Create(dto, userId)));




        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto dto, string id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "User Updated Successfully", await _service.Update(dto, id, userId)));



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "User Deleted Successfully", await _service.Delete(id, userId)));


      
    }
}
