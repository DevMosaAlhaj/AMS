using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.PriceOfferServices
{
    public interface IPriceOfferService
    {

        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<PriceOfferViewModel> Get(int id);

        Task<int> Create(PriceOfferCreateDto dto, string userId);
        
        Task<int> Update(PriceOfferUpdateDto dto , int id, string userId);
        
        Task<int> Delete(int id, string userId);

    }
}