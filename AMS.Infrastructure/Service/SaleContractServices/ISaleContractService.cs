using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.SaleContractServices
{
    public interface ISaleContractService
    {

        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<SaleContractViewModel> Get(int id);

        Task<int> Create(SaleContractCreateDto dto, string userId);
        
        Task<int> Update(SaleContractUpdateDto dto , int id, string userId);
        
        Task<int> Delete(int id, string userId);

    }
}