using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.SparePartSoldServices
{
    public interface ISparePartSoldService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<SparePartSoldViewModel> Get(int id);
        
        Task<int> Create (SparePartSoldCreateDto dto, string userId);
        
        Task<int> Update (SparePartSoldUpdateDto dto, int id, string userId);
        
        Task<int> Delete (int id, string userId);
        
    }
}