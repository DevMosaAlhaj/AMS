using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Data.Data;
using AMS.Data.DbEntity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.SparePartSoldServices
{
    public class SparePartSoldService : ISparePartSoldService
    {
        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public SparePartSoldService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.SparePartsSold.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var sparePartsSold = await _dbContext.SparePartsSold
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.SalesStaff)
                .Include(x => x.SalesStaff)
                .Skip(skipVal).Take(pageSize).ToListAsync();


            var sparePartsSoldViewModel = _mapper.Map<List<SparePartSoldViewModel>>(sparePartsSold);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = sparePartsSoldViewModel,
                PagesCount = pagesCount
            };
        }

        public async Task<SparePartSoldViewModel> Get(int id)
        {
            var sparePartSold = await _dbContext.SparePartsSold
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.SalesStaff)
                .Include(x => x.SalesStaff)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SparePartSoldViewModel>(sparePartSold);
        }

        public async Task<int> Create(SparePartSoldCreateDto dto, string userId)
        {
            var createdSparePartSold = _mapper.Map<SparePartSoldDbEntity>(dto);

            await _dbContext.SparePartsSold.AddAsync(createdSparePartSold);

            await _dbContext.SaveChangesAsync();

            return createdSparePartSold.Id;
        }

        public async Task<int> Update(SparePartSoldUpdateDto dto, int id, string userId)
        {
            var oldSparePartSold = await _dbContext.SparePartsSold
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.SalesStaff)
                .Include(x => x.SalesStaff)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedSparePartSold = _mapper.Map(dto, oldSparePartSold);

            _dbContext.SparePartsSold.Update(updatedSparePartSold);

            await _dbContext.SaveChangesAsync();

            return updatedSparePartSold.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedSparePartSold = await _dbContext.SparePartsSold.FindAsync(id);

            deletedSparePartSold.IsDeleted = true;

            _dbContext.SparePartsSold.Update(deletedSparePartSold);

            await _dbContext.SaveChangesAsync();

            return deletedSparePartSold.Id;
        }
    }
}