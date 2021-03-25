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
using AMS.Infrastructure.Service.NotificationServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.MotorServices
{
    public class MotorService : IMotorService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;
        private readonly INotificationService _service ;

        public MotorService(IMapper mapper, AmsDbContext dbContext, INotificationService service)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _service = service;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Motors.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var motors = await _dbContext.Motors
                .Include(x=>x.MaintenanceCycles)
                .Include(x=>x.MaintenanceContracts)
                .Include(x=>x.MaintenanceServices)
                .Include(x=>x.SaleContracts)
                .Include(x=>x.Client)
                .Include(x=>x.SparePartsSold)
                .Skip(skipVal).Take(pageSize).ToListAsync();


            var motorsViewModel = _mapper.Map<List<MotorViewModel>>(motors);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = motorsViewModel,
                PagesCount = pagesCount
            };
        }

        public async Task<MotorViewModel> Get(int id)
        {
            var motor = await _dbContext.Motors
                .Include(x => x.Client)
                .Include(x=>x.MaintenanceCycles)
                .Include(x=>x.MaintenanceContracts)
                .Include(x=>x.MaintenanceServices)
                .Include(x=>x.SaleContracts)
                .Include(x=>x.SparePartsSold)
                .SingleOrDefaultAsync(x => x.Id == id);


            return _mapper.Map<MotorViewModel>(motor);
        }

        public async Task<int> Create(MotorCreateDto dto , string userId)
        {
            var createdMotor = _mapper.Map<MotorDbEntity>(dto);

            createdMotor.CreatedBy = userId;

            await _dbContext.Motors.AddAsync(createdMotor);

            await _dbContext.SaveChangesAsync();

            return createdMotor.Id;
        }

        public async Task<int> Update(MotorUpdateDto dto, int id , string userId)
        {
            var oldMotor = await _dbContext.Motors
                .Include(x => x.Client)
                .Include(x => x.MaintenanceCycles)
                .Include(x => x.MaintenanceContracts)
                .Include(x => x.MaintenanceServices)
                .Include(x => x.SaleContracts)
                .Include(x => x.SparePartsSold)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedMotor = _mapper.Map(dto, oldMotor);

            updatedMotor.UpdateAt = DateTime.Now;
            updatedMotor.UpdatedBy = userId;

            _dbContext.Motors.Update(updatedMotor);

            await _dbContext.SaveChangesAsync();

            // Check Motor if Need to Change Oli

            var hoursDifference = updatedMotor.CurrentCounterReading - updatedMotor.PreviousCounterReading;

            if (hoursDifference >= updatedMotor.OliCounter)
            {
                // Motor Need to Change Oli , Then Push Notification To All Users

                var usersFcmToken = await _dbContext.Users
                    .Where(x=> x.FcmToken != null)
                    .Select(x => x.FcmToken).ToListAsync();

                var message = new MessageCreateDto()
                {
                    Title="اشعار صيانة",
                    Body="هناك مولد يحتاج الى تغيير زيت للمحرك",
                    Action="Motor",
                    ActionId=updatedMotor.Id
                };

                var notifications = _service.CreateNotifications(message, usersFcmToken);

                await _service.PushNotifications(notifications);
            }


            return updatedMotor.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedMotor = await _dbContext.Motors.FindAsync(id);

            deletedMotor.IsDeleted = true;
            deletedMotor.UpdateAt = DateTime.Now;
            deletedMotor.UpdatedBy = userId;

            _dbContext.Motors.Update(deletedMotor);

            await _dbContext.SaveChangesAsync();

            return deletedMotor.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, MotorSearchDto dto)
        {

            var motorsCount = await _dbContext.Motors.CountAsync(x=>
            (string.IsNullOrEmpty(dto.Address) || x.Address.Contains(dto.Address) )&&
            (string.IsNullOrEmpty(dto.Charger) || x.Charger.Contains(dto.Charger) )&&
            (string.IsNullOrEmpty(dto.EngineModel) || x.EngineModel.Contains(dto.EngineModel) )&&
            (string.IsNullOrEmpty(dto.EngineNumber) || x.EngineNumber.Contains(dto.EngineNumber) )&&
            (string.IsNullOrEmpty(dto.EngineType) || x.EngineType.Contains(dto.EngineType) )&&
            (string.IsNullOrEmpty(dto.MotorModel) || x.MotorModel.Contains(dto.MotorModel) )&&
            (string.IsNullOrEmpty(dto.MotorNumber) || x.MotorNumber.Contains(dto.MotorNumber) )&&
            (string.IsNullOrEmpty(dto.MotorType) || x.MotorType.Contains(dto.MotorType) )
            
            );

            throw new NotImplementedException();
        }
    }
}