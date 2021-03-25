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

namespace AMS.Infrastructure.Service.SparePartServices
{
    public class SparePartService : ISparePartService
    {
        
        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public SparePartService(AmsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.SpareParts.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;


            var spareParts = await _dbContext.SpareParts
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var sparePartViewModel = _mapper.Map<List<SparePartViewModel>>(spareParts);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = sparePartViewModel,
                PagesCount = pagesCount
            };

          
        }

        public async Task<SparePartViewModel> Get(int id)
        {
            var sparePart = await _dbContext.SpareParts.SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SparePartViewModel>(sparePart);
        }

        public async Task<int> Create(SparePartCreateDto dto, string userId)
        {
            var createdSparePart = _mapper.Map<SparePartDbEntity>(dto);

            await _dbContext.SpareParts.AddAsync(createdSparePart);

            await _dbContext.SaveChangesAsync();

            return createdSparePart.Id;
        }

        public async Task<int> Update(SparePartUpdateDto dto, int id, string userId)
        {
            var oldSparePart = await _dbContext.SpareParts.FindAsync(id);

            var updatedSparePart = _mapper.Map(dto, oldSparePart);

            _dbContext.SpareParts.Update(updatedSparePart);

            await _dbContext.SaveChangesAsync();

            return updatedSparePart.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
           

            var deletedSparePart = await _dbContext.SpareParts.FindAsync(id);

            deletedSparePart.IsDeleted = true;
            
            _dbContext.SpareParts.Update(deletedSparePart);

            await _dbContext.SaveChangesAsync();

            return deletedSparePart.Id;
        }
    }
}