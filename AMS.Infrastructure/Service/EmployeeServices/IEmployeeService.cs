using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<EmployeeViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize,EmployeeSearchDto dto);

        Task<int> Create(EmployeeCreateDto dto, string userId);
        
        Task<int> Update(EmployeeUpdateDto dto,int id, string userId);
        
        Task<int> Delete(int id, string userId); 

    }
}