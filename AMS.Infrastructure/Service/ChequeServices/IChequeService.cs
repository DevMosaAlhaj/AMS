using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.ChequeServices
{
    public interface IChequeService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<ChequeViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize, ChequeSearchDto dto);

        Task<int> Create(ChequeCreateDto dto,string userId);
        
        Task<int> Update(ChequeUpdateDto dto, int id, string userId);
        
        Task<int> Delete(int id, string userId);
        
    }
}