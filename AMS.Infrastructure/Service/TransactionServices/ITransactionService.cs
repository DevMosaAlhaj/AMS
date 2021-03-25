using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.TransactionServices
{
    public interface ITransactionService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<TransactionViewModel> Get(int id);

        Task<int> Create(TransactionCreateDto dto, string userId);
        
        Task<int> Update(TransactionUpdateDto dto , int id, string userId);
        
        Task<int> Delete(int id, string userId); 
    }
}