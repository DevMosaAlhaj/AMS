using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.MaintenanceContractServices
{
    public interface IMaintenanceContractService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<MaintenanceContractViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize, MaintenanceContractSearchDto dto);

        Task<int> Create(MaintenanceContractCreateDto dto, string userId);
        
        Task<int> Update(MaintenanceContractUpdateDto dto,int id, string userId);
        
        Task<int> Delete(int id, string userId);
    }
}