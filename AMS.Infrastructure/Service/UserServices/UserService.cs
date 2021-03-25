using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Constant;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.Enum;
using AMS.Core.ViewModel;
using AMS.Data.Data;
using AMS.Data.DbEntity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.UserServices
{
    public class UserService : IUserService
    {
        
        private readonly IMapper _mapper;
        private readonly UserManager<UserDbEntity> _manager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AmsDbContext _dbContext;

        public UserService(IMapper mapper, UserManager<UserDbEntity> manager, AmsDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _manager = manager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Users.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var users = await _dbContext.Users
                .Include(x=> x.ForEmp)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);


            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = usersViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<UserViewModel> Get(string id)
        {
            var user = await _dbContext.Users
                .Include(x => x.ForEmp)
                .SingleOrDefaultAsync(x=> x.Id == id);

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<string> Create(UserCreateDto dto, string userId)
        {
            var createdUser = _mapper.Map<UserDbEntity>(dto);

            createdUser.UserName = createdUser.Email;

            var result = await _manager.CreateAsync(createdUser, dto.Password);
            
            await _dbContext.SaveChangesAsync();

            var createdRole = "";

            switch (createdUser.UserType)
            {
                case UserType.SuperAdmin:
                    createdRole = UserRole.SuperAdmin;
                    break;

                case UserType.RegistryOfficer:
                    createdRole = UserRole.RegistryOfficer;
                    break;

                case UserType.MaintenanceWorker:
                    createdRole = UserRole.MaintenanceWorker;
                    break;

                default:
                    createdRole = UserRole.Accountant;
                    break;
            }

           

            if (!await _roleManager.RoleExistsAsync(createdRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(createdRole));
            }

            await _manager.AddToRoleAsync(createdUser, createdRole);

            return !result.Succeeded ? "Error When Create User" : createdUser.Id;
        }

        public async Task<string> Update(UserUpdateDto dto, string id, string userId)
        {
            var oldUser = await _dbContext.Users
                .Include(x => x.ForEmp)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedUser = _mapper.Map(dto, oldUser);

             await _manager.UpdateAsync(updatedUser);

             await _dbContext.SaveChangesAsync();

             return updatedUser.Id;
        }

        public async Task<string> Delete(string id, string userId)
        {
            var deletedUser = await _dbContext.Users.FindAsync(id);

            deletedUser.IsDeleted = true;

            _dbContext.Users.Update(deletedUser);

            await _dbContext.SaveChangesAsync();

            return deletedUser.Id;
        }

       

    }
}