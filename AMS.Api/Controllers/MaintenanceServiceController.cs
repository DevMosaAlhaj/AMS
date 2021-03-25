using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.MaintenanceServiceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Authorize(Roles = UserRole.AllWithoutAccountant)]
    public class MaintenanceServiceController : BaseController
    {


        private readonly IMaintenanceServiceService _service;

        public MaintenanceServiceController(IMaintenanceServiceService service)
        {
            _service = service;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll MaintenanceServices Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get MaintenanceService Successfully", await _service.Get(id)));


        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceServiceCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "MaintenanceService Created Successfully", await _service.Create(dto, userId)));



        [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MaintenanceServiceUpdateDto dto, int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "MaintenanceService Updated Successfully", await _service.Update(dto, id, userId)));


        [Authorize(Roles = UserRole.SuperAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "MaintenanceService Deleted Successfully", await _service.Delete(id, userId)));



    }
}
