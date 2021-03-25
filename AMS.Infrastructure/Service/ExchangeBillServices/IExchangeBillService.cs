using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.ExchangeBillServices
{
    public interface IExchangeBillService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<ExchangeBillViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize,ExchangeBillSearchDto dto);

        Task<int> Create(ExchangeBillCreateDto dto, string userId);
        
        Task<int> Update(ExchangeBillUpdateDto dto, int id, string userId);
        
        Task<int> Delete(int id, string userId);

    }
}