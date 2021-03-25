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

namespace AMS.Infrastructure.Service.MaintenanceServiceServices
{
    public class MaintenanceServiceService : IMaintenanceServiceService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public MaintenanceServiceService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.MaintenanceServices.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var maintenanceServices = await _dbContext.MaintenanceServices
                .Include(x=> x.Client)
                .Include(x=> x.Motor)
                .Include(x=> x.PriceOffer)
                .Include(x=> x.WorkshopOfficial)
                .Skip(skipVal).Take(pageSize).ToListAsync();


            var maintenanceServicesViewModel = _mapper.Map<List<MaintenanceServiceViewModel>>(maintenanceServices);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceServicesViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<MaintenanceServiceViewModel> Get(int id)
        {
            var maintenanceService = await _dbContext.MaintenanceServices
                .Include(x=> x.Client)
                .Include(x=> x.Motor)
                .Include(x=> x.PriceOffer)
                .Include(x=> x.WorkshopOfficial)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<MaintenanceServiceViewModel>(maintenanceService);
        }

        public async Task<int> Create(MaintenanceServiceCreateDto dto , string userId)
        {
            var createdMaintenanceService = _mapper.Map<MaintenanceServiceDbEntity>(dto);

            createdMaintenanceService.CreatedBy = userId;

            await _dbContext.MaintenanceServices.AddAsync(createdMaintenanceService);

            await _dbContext.SaveChangesAsync();

            return createdMaintenanceService.Id;
        }

        public async Task<int> Update(MaintenanceServiceUpdateDto dto, int id , string userId)
        {
            var oldMaintenanceService = await _dbContext.MaintenanceServices
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.PriceOffer)
                .Include(x => x.WorkshopOfficial)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedMaintenanceService = _mapper.Map(dto, oldMaintenanceService);

            updatedMaintenanceService.UpdateAt = DateTime.Now;
            updatedMaintenanceService.UpdatedBy = userId;

            _dbContext.MaintenanceServices.Update(updatedMaintenanceService);

            await _dbContext.SaveChangesAsync();

            return updatedMaintenanceService.Id;
        }

        public async Task<int> Delete(int id , string userId)
        {
            

            var deletedMaintenanceService = await _dbContext.MaintenanceServices.FindAsync(id);

            deletedMaintenanceService.IsDeleted = true;
            deletedMaintenanceService.UpdateAt = DateTime.Now;
            deletedMaintenanceService.UpdatedBy = userId;

            _dbContext.MaintenanceServices.Update(deletedMaintenanceService);

            await _dbContext.SaveChangesAsync();

            return deletedMaintenanceService.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, MaintenanceServiceSearchDto dto)
        {

            var maintenanceServicesCount = await _dbContext.MaintenanceServices.CountAsync(x=>
            (dto.EntryAt == null || (dto.EntryAt == null || (x.EntryAt.Day == dto.EntryAt.Value.Day && x.EntryAt.Month == dto.EntryAt.Value.Month && x.EntryAt.Year == dto.EntryAt.Value.Year))) &&
            (dto.ExitAt == null || x.ExitAt == null || (x.ExitAt.Value.Day == dto.ExitAt.Value.Day && x.ExitAt.Value.Month == dto.ExitAt.Value.Month && x.ExitAt.Value.Year == dto.ExitAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.TransportDescription) || x.TransportDescription.Contains(dto.TransportDescription) ) &&
            (string.IsNullOrEmpty(dto.ExitNotes) || x.ExitNotes.Contains(dto.ExitNotes) ) 
            
            );

            var pagesCount = (int)Math.Ceiling(maintenanceServicesCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;


            var maintenanceServices = await _dbContext.MaintenanceServices.Where(x =>
            (dto.EntryAt == null || (dto.EntryAt == null || (x.EntryAt.Day == dto.EntryAt.Value.Day && x.EntryAt.Month == dto.EntryAt.Value.Month && x.EntryAt.Year == dto.EntryAt.Value.Year))) &&
            (dto.ExitAt == null || x.ExitAt == null || (x.ExitAt.Value.Day == dto.ExitAt.Value.Day && x.ExitAt.Value.Month == dto.ExitAt.Value.Month && x.ExitAt.Value.Year == dto.ExitAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.TransportDescription) || x.TransportDescription.Contains(dto.TransportDescription)) &&
            (string.IsNullOrEmpty(dto.ExitNotes) || x.ExitNotes.Contains(dto.ExitNotes))).Skip(skipVal).Take(pageSize).ToListAsync();


            var maintenanceServicesViewModel = _mapper.Map<List<MaintenanceServiceViewModel>>(maintenanceServices);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = maintenanceServicesViewModel,
                PagesCount = pagesCount
            };

        }
    }
}