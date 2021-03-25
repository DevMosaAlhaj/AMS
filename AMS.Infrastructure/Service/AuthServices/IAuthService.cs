using System.Threading.Tasks;
using AMS.Core.Dto.AuthDto;
using AMS.Core.ViewModel;
using AMS.Data.DbEntity;

namespace AMS.Infrastructure.Service.AuthServices
{
    public interface IAuthService
    {

        Task<LoginResponseViewModel> Login(LoginDto dto);

        Task<string> Logout(string token);

        Task<LoginResponseViewModel> RefreshToken(string refreshToken);

        Task<TokenViewModel> GenerationAccessToken(UserDbEntity user);

        Task<string> RegisterFcmToken(string userId, string userFcmToken);

    }
}
