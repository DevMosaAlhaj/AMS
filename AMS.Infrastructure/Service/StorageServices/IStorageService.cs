using System.Threading.Tasks;

namespace AMS.Infrastructure.Service.StorageServices
{
    public interface IStorageService
    {

        Task<string> SaveFile(string fileBase64, string folderName, string extension);

        Task<string> GetFile(string filePath);
    }
}