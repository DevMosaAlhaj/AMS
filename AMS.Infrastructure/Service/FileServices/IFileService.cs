using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.FileServices
{
    public interface IFileService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<FileViewModel> Get(int id);

        Task<int> Create(FileCreateDto dto, string userId);
        
        Task<int> Update(FileUpdateDto dto , int id, string userId);
        
        Task<int> Delete(int id, string userId);
        
    }
}