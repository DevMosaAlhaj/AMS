using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Authorize(Roles = UserRole.AllWithoutMaintenanceWorker)]
    public class CollectionCommissionController : BaseController
    {
        private readonly ICollectionCommissionService _service;


        public CollectionCommissionController(ICollectionCommissionService service)
        {
            _service = service;
        }



        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll CollectionCommissions Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get CollectionCommission Successfully", await _service.Get(id)));


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CollectionCommissionCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "CollectionCommission Created Successfully", await _service.Create(dto, userId)));



        [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CollectionCommissionUpdateDto dto, int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "CollectionCommission Updated Successfully", await _service.Update(dto, id, userId)));


        [Authorize(Roles = UserRole.SuperAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "CollectionCommission Deleted Successfully", await _service.Delete(id, userId)));

    }
}
