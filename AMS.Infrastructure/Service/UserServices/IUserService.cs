using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.UserServices
{
    public interface IUserService
    {
        Task<PagingViewModel> GetAll(int page, int pageSize);

        Task<UserViewModel> Get(string id);

        Task<string> Create(UserCreateDto dto, string userId);

        Task<string> Update(UserUpdateDto dto , string id, string userId);
        
        Task<string> Delete(string id, string userId);

       
    }
}