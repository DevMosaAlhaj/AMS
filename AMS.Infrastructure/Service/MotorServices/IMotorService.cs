using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.MotorServices
{
    public interface IMotorService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<MotorViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize,MotorSearchDto dto);

        Task<int> Create(MotorCreateDto dto, string userId);
        
        Task<int> Update(MotorUpdateDto dto, int id, string userId);
        
        Task<int> Delete(int id, string userId);
        
        
    }
}