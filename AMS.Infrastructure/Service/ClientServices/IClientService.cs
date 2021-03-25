using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;

namespace AMS.Infrastructure.Service.ClientServices
{
    public interface IClientService
    {
        Task<PagingViewModel> GetAll(int page,int pageSize);

        Task<ClientViewModel> Get(int id);

        Task<PagingViewModel> Search(int page, int pageSize, ClientSearchDto dto);

        Task<int> Create(ClientCreateDto dto, string userId);
        
        Task<int> Update(ClientUpdateDto dto, int id, string userId);
        
        Task<int> Delete(int id, string userId);


    }
}