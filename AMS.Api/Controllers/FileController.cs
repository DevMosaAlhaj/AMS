using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.FileServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
    public class FileController : BaseController
    {

        private readonly IFileService _service;

        public FileController(IFileService service)
        {
            _service = service;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll Files Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get File Successfully", await _service.Get(id)));


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FileCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "File Created Successfully", await _service.Create(dto, userId)));




        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] FileUpdateDto dto, int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "File Updated Successfully", await _service.Update(dto, id, userId)));


        [Authorize(Roles = UserRole.SuperAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "File Deleted Successfully", await _service.Delete(id, userId)));

    }
}
