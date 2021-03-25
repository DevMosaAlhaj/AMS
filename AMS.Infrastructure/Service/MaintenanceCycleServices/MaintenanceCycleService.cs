using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.SearchDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Data.Data;
using AMS.Data.DbEntity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.MaintenanceCycleServices
{
    public class MaintenanceCycleService : IMaintenanceCycleService
    {

        private readonly AmsDbContext _dbContext;
        private readonly IMapper _mapper;

        public MaintenanceCycleService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.MaintenanceCycles.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var maintenanceCycles = await _dbContext.MaintenanceCycles
                .Include(x=> x.MaintenanceContract)
                .Include(x=> x.SpareParts)
                .Include(x=> x.MaintenanceTeam)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var maintenanceCyclesViewModel = _mapper.Map<List<MaintenanceCycleViewModel>>(maintenanceCycles);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceCyclesViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<MaintenanceCycleViewModel> Get(int id)
        {
            var maintenanceCycle = await _dbContext.MaintenanceCycles
                .Include(x=> x.MaintenanceContract)
                .Include(x=> x.SpareParts)
                .Include(x=> x.MaintenanceTeam)
                .SingleOrDefaultAsync(x=>x.Id== id);

            return _mapper.Map<MaintenanceCycleViewModel>(maintenanceCycle);
        }

        public async Task<int> Create(MaintenanceCycleCreateDto dto, string userId)
        {
            var createdMaintenanceCycle = _mapper.Map<MaintenanceCycleDbEntity>(dto);

            createdMaintenanceCycle.CreatedBy = userId;

            await _dbContext.MaintenanceCycles.AddAsync(createdMaintenanceCycle);

            await _dbContext.SaveChangesAsync();

            return createdMaintenanceCycle.Id;
        }

        public async Task<int> Update(MaintenanceCycleUpdateDto dto, int id, string userId)
        {
            var oldMaintenanceCycle = await _dbContext.MaintenanceCycles
                .Include(x => x.MaintenanceContract)
                .Include(x => x.SpareParts)
                .Include(x => x.MaintenanceTeam)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedMaintenanceCycle = _mapper.Map(dto,oldMaintenanceCycle);

            updatedMaintenanceCycle.UpdateAt = DateTime.Now;
            updatedMaintenanceCycle.UpdatedBy = userId;

            _dbContext.MaintenanceCycles.Update(updatedMaintenanceCycle);

            await _dbContext.SaveChangesAsync();

            return updatedMaintenanceCycle.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            

            var deletedMaintenanceCycle = await _dbContext.MaintenanceCycles.FindAsync(id);

            deletedMaintenanceCycle.IsDeleted = true;
            deletedMaintenanceCycle.UpdateAt = DateTime.Now;
            deletedMaintenanceCycle.UpdatedBy = userId;

            _dbContext.MaintenanceCycles.Update(deletedMaintenanceCycle);

            await _dbContext.SaveChangesAsync();

            return deletedMaintenanceCycle.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, MaintenanceCycleSearchDto dto)
        {

            var maintenanceCyclesCount = await _dbContext.MaintenanceCycles.CountAsync( x=>
                (dto.VisitAt == null || (dto.VisitAt == null || (x.VisitAt.Day == dto.VisitAt.Value.Day && x.VisitAt.Month == dto.VisitAt.Value.Month && x.VisitAt.Year == dto.VisitAt.Value.Year))) && 
                (string.IsNullOrEmpty(dto.Service) || x.Service.Contains(dto.Service))  
                );

            var pagesCount = (int)Math.Ceiling(maintenanceCyclesCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;


            var maintenanceCycles = await _dbContext.MaintenanceCycles.Where(x =>
               (dto.VisitAt == null || (dto.VisitAt == null || (x.VisitAt.Day == dto.VisitAt.Value.Day && x.VisitAt.Month == dto.VisitAt.Value.Month && x.VisitAt.Year == dto.VisitAt.Value.Year))) &&
               (string.IsNullOrEmpty(dto.Service) || x.Service.Contains(dto.Service))
                ).Skip(skipVal).Take(pageSize).ToListAsync();


            var maintenanceCyclesViewModel = _mapper.Map<List<MaintenanceCycleViewModel>>(maintenanceCycles);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceCyclesViewModel,
                PagesCount = pagesCount
            };

            
        }
    }
}