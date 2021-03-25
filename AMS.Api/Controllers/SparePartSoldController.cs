using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.SparePartSoldServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Authorize(Roles = UserRole.All)]
    public class SparePartSoldController : BaseController
    {


        private readonly ISparePartSoldService _service;

        public SparePartSoldController(ISparePartSoldService service)
        {
            _service = service;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll SparePartsSold Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get SparePartSold Successfully", await _service.Get(id)));


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SparePartSoldCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "SparePartSold Created Successfully", await _service.Create(dto, userId)));



        [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SparePartSoldUpdateDto dto, int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "SparePartSold Updated Successfully", await _service.Update(dto, id, userId)));


        [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "SparePartSold Deleted Successfully", await _service.Delete(id, userId)));


    }
}
