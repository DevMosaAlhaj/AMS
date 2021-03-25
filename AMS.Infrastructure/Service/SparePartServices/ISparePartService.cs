using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.SparePartServices
{
    public interface ISparePartService
    {

        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<SparePartViewModel> Get(int id);

        Task<int> Create(SparePartCreateDto dto, string userId);
        
        Task<int> Update(SparePartUpdateDto dto , int id, string userId);
        
        Task<int> Delete(int id, string userId);
        

    }
}