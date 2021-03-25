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

namespace AMS.Infrastructure.Service.MaintenanceContractServices
{
    public class MaintenanceContractService : IMaintenanceContractService
    {
        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public MaintenanceContractService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.MaintenanceContracts.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var maintenanceContracts = await _dbContext.MaintenanceContracts
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.MaintenanceCycles)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var maintenanceContractsViewModel = _mapper.Map<List<MaintenanceContractViewModel>>(maintenanceContracts);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceContractsViewModel,
                PagesCount = pagesCount
            };
        }

        public async Task<MaintenanceContractViewModel> Get(int id)
        {
            var maintenanceContract = await _dbContext.MaintenanceContracts
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.MaintenanceCycles)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<MaintenanceContractViewModel>(maintenanceContract);
        }

        public async Task<int> Create(MaintenanceContractCreateDto dto, string userId)
        {
            var createdMaintenanceContract = _mapper.Map<MaintenanceContractDbEntity>(dto);

            createdMaintenanceContract.CreatedBy = userId;

            await _dbContext.MaintenanceContracts.AddAsync(createdMaintenanceContract);
            await _dbContext.SaveChangesAsync();

            return createdMaintenanceContract.Id;
        }

        public async Task<int> Update(MaintenanceContractUpdateDto dto, int id, string userId)
        {
            var oldMaintenanceContract = await _dbContext.MaintenanceContracts
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.MaintenanceCycles)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedMaintenanceContract = _mapper.Map(dto, oldMaintenanceContract);

            updatedMaintenanceContract.UpdateAt = DateTime.Now;
            updatedMaintenanceContract.UpdatedBy = userId;

            _dbContext.MaintenanceContracts.Update(updatedMaintenanceContract);

            await _dbContext.SaveChangesAsync();

            return updatedMaintenanceContract.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedMaintenanceContract = await _dbContext.MaintenanceContracts.FindAsync(id);

            deletedMaintenanceContract.IsDeleted = true;
            deletedMaintenanceContract.UpdateAt = DateTime.Now;
            deletedMaintenanceContract.UpdatedBy = userId;

            _dbContext.MaintenanceContracts.Update(deletedMaintenanceContract);

            await _dbContext.SaveChangesAsync();

            return deletedMaintenanceContract.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, MaintenanceContractSearchDto dto)
        {

            var maintenanceContractsCount = await _dbContext.MaintenanceContracts.CountAsync(x=>
                (dto.ContractDate == null || (x.ContractDate.Day == dto.ContractDate.Value.Day && x.ContractDate.Month == dto.ContractDate.Value.Month && x.ContractDate.Year == dto.ContractDate.Value.Year)) &&
                (dto.ContractStartDate == null || (x.ContractStartDate.Day == dto.ContractStartDate.Value.Day && x.ContractStartDate.Month == dto.ContractStartDate.Value.Month && x.ContractStartDate.Year == dto.ContractStartDate.Value.Year)) &&
                (dto.ContractEndDate == null || (x.ContractEndDate.Day == dto.ContractEndDate.Value.Day && x.ContractEndDate.Month == dto.ContractEndDate.Value.Month && x.ContractEndDate.Year == dto.ContractEndDate.Value.Year)) &&
                (dto.CyclePerMonth == null || x.CyclePerMonth == dto.CyclePerMonth)
                );

            var pagesCount = (int)Math.Ceiling(maintenanceContractsCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;


            var maintenanceContracts = await _dbContext.MaintenanceContracts.Where(x =>
               (dto.ContractDate == null || (x.ContractDate.Day == dto.ContractDate.Value.Day && x.ContractDate.Month == dto.ContractDate.Value.Month && x.ContractDate.Year == dto.ContractDate.Value.Year)) &&
               (dto.ContractStartDate == null || (x.ContractStartDate.Day == dto.ContractStartDate.Value.Day && x.ContractStartDate.Month == dto.ContractStartDate.Value.Month && x.ContractStartDate.Year == dto.ContractStartDate.Value.Year)) &&
               (dto.ContractEndDate == null || (x.ContractEndDate.Day == dto.ContractEndDate.Value.Day && x.ContractEndDate.Month == dto.ContractEndDate.Value.Month && x.ContractEndDate.Year == dto.ContractEndDate.Value.Year)) &&
               (dto.CyclePerMonth == null || x.CyclePerMonth == dto.CyclePerMonth)
               ).Skip(skipVal).Take(pageSize).ToListAsync();


            var maintenanceContractsViewModel = _mapper.Map<List<MaintenanceContractViewModel>>(maintenanceContracts);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceContractsViewModel,
                PagesCount = pagesCount
            };
        }
    }
}