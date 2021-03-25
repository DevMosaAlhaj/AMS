using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service
{
    public interface ICollectionCommissionService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<CollectionCommissionViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize,CollectionCommissionSearchDto dto);

        Task<int> Create(CollectionCommissionCreateDto dto, string userId);
        
        Task<int> Update(CollectionCommissionUpdateDto dto,int id, string userId);
        
        Task<int> Delete(int id, string userId);
        

    }
}