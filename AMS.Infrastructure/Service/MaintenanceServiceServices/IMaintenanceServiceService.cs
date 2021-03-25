using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.MaintenanceServiceServices
{
    public interface IMaintenanceServiceService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<MaintenanceServiceViewModel> Get(int id);

        Task<PagingViewModel> Search (int page, int pageSize , MaintenanceServiceSearchDto dto);

        Task<int> Create(MaintenanceServiceCreateDto dto, string userId);
        
        Task<int> Update(MaintenanceServiceUpdateDto dto,int id, string userId);
        
        Task<int> Delete(int id, string userId);
    }
}