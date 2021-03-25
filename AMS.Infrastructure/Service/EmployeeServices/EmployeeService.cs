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

namespace AMS.Infrastructure.Service.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public EmployeeService(AmsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Employees.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var employees = await _dbContext.Employees
                .Include(x=> x.CollectionCommissions)
                .Include(x=> x.MaintenanceCycles)
                .Include(x=> x.SparePartsSold)
                .Include(x=> x.MaintenanceServices)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var employeesViewModel = _mapper.Map<List<EmployeeViewModel>>(employees);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = employeesViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            var employee = await _dbContext.Employees
                .Include(x=> x.CollectionCommissions)
                .Include(x=> x.MaintenanceCycles)
                .Include(x=> x.SparePartsSold)
                .Include(x=> x.MaintenanceServices)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task<int> Create(EmployeeCreateDto dto ,string userId)
        {
            var createdEmployee = _mapper.Map<EmployeeDbEntity>(dto);

            createdEmployee.CreatedBy = userId;

            await _dbContext.Employees.AddAsync(createdEmployee);

            await _dbContext.SaveChangesAsync();

            return createdEmployee.Id;
        }

        public async Task<int> Update(EmployeeUpdateDto dto, int id, string userId)
        {
            var oldEmployee = await _dbContext.Employees
                .Include(x => x.CollectionCommissions)
                .Include(x => x.MaintenanceCycles)
                .Include(x => x.SparePartsSold)
                .Include(x => x.MaintenanceServices)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedEmployee = _mapper.Map(dto, oldEmployee);

            updatedEmployee.UpdateAt = DateTime.Now;
            updatedEmployee.UpdatedBy = userId;

            _dbContext.Employees.Update(updatedEmployee);

            await _dbContext.SaveChangesAsync();

            return updatedEmployee.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {

            var deletedEmployee = await _dbContext.Employees.FindAsync(id);

            deletedEmployee.IsDeleted = true;
            deletedEmployee.UpdateAt = DateTime.Now;
            deletedEmployee.UpdatedBy = userId;

            _dbContext.Employees.Update(deletedEmployee);

            await _dbContext.SaveChangesAsync();

            return deletedEmployee.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, EmployeeSearchDto dto)
        {

            var employeesCount = await _dbContext.Employees.CountAsync(x => 
            (dto.IdentityNo==null || x.IdentityNo == null || x.IdentityNo == dto.IdentityNo)&&
            (string.IsNullOrEmpty(dto.Name) || x.Name.Contains(dto.Name) )&&
            (string.IsNullOrEmpty(dto.Address) || x.Address.Contains(dto.Address) )&&
            (string.IsNullOrEmpty(dto.JobName) || x.JobName.Contains(dto.JobName) )&&
            (string.IsNullOrEmpty(dto.PhoneNumber) || x.PhoneNumber.Contains(dto.PhoneNumber) )
            );


            var pagesCount = (int)Math.Ceiling(employeesCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var employees = await _dbContext.Employees.Where(x =>
            (dto.IdentityNo == null || x.IdentityNo == null || x.IdentityNo == dto.IdentityNo) &&
            (string.IsNullOrEmpty(dto.Name) || x.Name.Contains(dto.Name)) &&
            (string.IsNullOrEmpty(dto.Address) || x.Address.Contains(dto.Address)) &&
            (string.IsNullOrEmpty(dto.JobName) || x.JobName.Contains(dto.JobName)) &&
            (string.IsNullOrEmpty(dto.PhoneNumber) || x.PhoneNumber.Contains(dto.PhoneNumber))
            ).Skip(skipVal).Take(pageSize).ToListAsync();

            var employeesViewModel = _mapper.Map<List<EmployeeViewModel>>(employees);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = employeesViewModel,
                PagesCount = pagesCount
            };

            
        }
    }
}