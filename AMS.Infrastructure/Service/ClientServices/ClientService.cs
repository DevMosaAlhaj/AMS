using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Data.Data;
using AMS.Data.DbEntity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.ClientServices
{
    public class ClientService : IClientService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public ClientService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page,int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Clients.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var clients = await _dbContext.Clients
                .Include(x=>x.Motors)
                .Include(x=>x.SparePartsSold)
                .Include(x=>x.MaintenanceContracts)
                .Include(x=>x.MaintenanceServices)
                .Include(x=>x.SaleContracts)
                .Skip(skipVal).Take(pageSize).ToListAsync();


            var clientsViewModel = _mapper.Map<List<ClientViewModel>>(clients);
           

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = clientsViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<ClientViewModel> Get(int id)
        {
            var client = await _dbContext.Clients
                .Include(x=>x.Motors)
                .Include(x=>x.SparePartsSold)
                .Include(x=>x.MaintenanceContracts)
                .Include(x=>x.MaintenanceServices)
                .Include(x=>x.SaleContracts).SingleOrDefaultAsync(x=> x.Id == id);

            return _mapper.Map<ClientViewModel>(client);
        }

        public async Task<int> Create(ClientCreateDto dto, string userId)
        {
            var createdClient = _mapper.Map<ClientDbEntity>(dto);

            createdClient.CreatedBy = userId;

            await _dbContext.Clients.AddAsync(createdClient);
            await _dbContext.SaveChangesAsync();

            return createdClient.Id;

        }

        public async Task<int> Update(ClientUpdateDto dto, int id, string userId)
        {
            var oldClient = await _dbContext.Clients
                .Include(x => x.Motors)
                .Include(x => x.SparePartsSold)
                .Include(x => x.MaintenanceContracts)
                .Include(x => x.MaintenanceServices)
                .Include(x => x.SaleContracts).SingleOrDefaultAsync(x => x.Id == id);

            var updatedClient = _mapper.Map(dto, oldClient);

            updatedClient.UpdateAt = DateTime.Now;
            updatedClient.UpdatedBy = userId;

            _dbContext.Clients.Update(updatedClient);

            await _dbContext.SaveChangesAsync();

            return updatedClient.Id;

        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedClient = await _dbContext.Clients.FindAsync(id);

            deletedClient.IsDeleted = true;

            deletedClient.UpdateAt = DateTime.Now;
            deletedClient.UpdatedBy = userId;

            _dbContext.Clients.Update(deletedClient);

            await _dbContext.SaveChangesAsync();

            return deletedClient.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize , ClientSearchDto dto)
        {

            var clientsCount = await _dbContext.Clients.CountAsync(x =>
            (dto.IdentityNo==null || x.IdentityNo == dto.IdentityNo)&&
            (string.IsNullOrEmpty(dto.Address) || x.Address.Contains(dto.Address))&&
            (string.IsNullOrEmpty(dto.Name) || x.Address.Contains(dto.Name))&&
            (string.IsNullOrEmpty(dto.PhoneNumber) || x.Address.Contains(dto.PhoneNumber))&&
            (string.IsNullOrEmpty(dto.Mediator) || x.Mediator.Contains(dto.Mediator)));


            var pagesCount = (int)Math.Ceiling(clientsCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var clients = await _dbContext.Clients.Where(x =>
           (dto.IdentityNo == null || x.IdentityNo == dto.IdentityNo) &&
           (string.IsNullOrEmpty(dto.Address) || x.Address.Contains(dto.Address)) &&
           (string.IsNullOrEmpty(dto.Name) || x.Address.Contains(dto.Name)) &&
           (string.IsNullOrEmpty(dto.PhoneNumber) || x.Address.Contains(dto.PhoneNumber)) &&
           (string.IsNullOrEmpty(dto.Mediator) || x.Mediator.Contains(dto.Mediator)))
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var clientsViewModel = _mapper.Map<List<ClientViewModel>>(clients);


            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = clientsViewModel,
                PagesCount = pagesCount
            };
        }


    }
}