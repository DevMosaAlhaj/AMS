using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Infrastructure.Service.MaintenanceCycleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Authorize(Roles = UserRole.SuperAdminOrRegistryOfficer)]
    public class MaintenanceCycleController : BaseController
    {
        private readonly IMaintenanceCycleService _service;

        public MaintenanceCycleController(IMaintenanceCycleService service)
        {
            _service = service;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "GetAll MaintenanceCycles Successfully", await _service.GetAll(page, pageSize)));


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "Get MaintenanceCycle Successfully", await _service.Get(id)));


        [Authorize(Roles = UserRole.AllWithoutAccountant)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceCycleCreateDto dto)
            => await GetResponse(async (userId) =>
            new ApiResponseViewModel(true, "MaintenanceCycle Created Successfully", await _service.Create(dto, userId)));



        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MaintenanceCycleUpdateDto dto, int id)
           => await GetResponse(async (userId) =>
           new ApiResponseViewModel(true, "MaintenanceCycle Updated Successfully", await _service.Update(dto, id, userId)));


        [Authorize(Roles = UserRole.SuperAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
          => await GetResponse(async (userId) =>
          new ApiResponseViewModel(true, "MaintenanceCycle Deleted Successfully", await _service.Delete(id, userId)));


    }
}
