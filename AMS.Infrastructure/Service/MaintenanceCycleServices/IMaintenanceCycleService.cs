using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.MaintenanceCycleServices
{
    public interface IMaintenanceCycleService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<MaintenanceCycleViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize,MaintenanceCycleSearchDto dto);

        Task<int> Create(MaintenanceCycleCreateDto dto, string userId);
        
        Task<int> Update(MaintenanceCycleUpdateDto dto, int id, string userId);
        
        Task<int> Delete(int id, string userId);

    }
}