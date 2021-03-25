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

namespace AMS.Infrastructure.Service.CollectionCommissionServices
{
    public class CollectionCommissionService : ICollectionCommissionService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public CollectionCommissionService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.CollectionCommissions.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var collectionCommissions = await _dbContext.CollectionCommissions
                .Include(x => x.CollectedByEmp)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var collectionCommissionsViewModel =
                _mapper.Map<List<CollectionCommissionViewModel>>(collectionCommissions);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = collectionCommissionsViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<CollectionCommissionViewModel> Get(int id)
        {
            var collectionCommission = await _dbContext.CollectionCommissions
                .Include(x=> x.CollectedByEmp)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<CollectionCommissionViewModel>(collectionCommission);
        }

        public async Task<int> Create(CollectionCommissionCreateDto dto,string userId)
        {
            var createdCollectionCommission = _mapper.Map<CollectionCommissionDbEntity>(dto);

            createdCollectionCommission.CreatedBy = userId;

            await _dbContext.CollectionCommissions.AddAsync(createdCollectionCommission);

            await _dbContext.SaveChangesAsync();

            return createdCollectionCommission.Id;
        }

        public async Task<int> Update(CollectionCommissionUpdateDto dto, int id, string userId)
        {
            var oldCollectionCommission = await _dbContext.CollectionCommissions
                .Include(x => x.CollectedByEmp)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedCollectionCommission = _mapper.Map(dto, oldCollectionCommission);

            updatedCollectionCommission.UpdatedBy = userId;
            updatedCollectionCommission.UpdateAt = DateTime.Now;

            _dbContext.CollectionCommissions.Update(updatedCollectionCommission);
            await _dbContext.SaveChangesAsync();

            return updatedCollectionCommission.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {

            var deletedCollectionCommission = await _dbContext.CollectionCommissions.FindAsync(id);

            deletedCollectionCommission.IsDeleted = true;
            deletedCollectionCommission.UpdatedBy = userId;
            deletedCollectionCommission.UpdateAt = DateTime.Now;

            _dbContext.CollectionCommissions.Update(deletedCollectionCommission);
            
            await _dbContext.SaveChangesAsync();

            return deletedCollectionCommission.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, CollectionCommissionSearchDto dto)
        {

            var collectionCommissionsCount = await _dbContext.CollectionCommissions.CountAsync(x =>
            (dto.CommissionAmount == null || x.CommissionAmount == dto.CommissionAmount)&&
            (dto.CollectedAt == null || (x.CollectedAt.Day == dto.CollectedAt.Value.Day && x.CollectedAt.Month == dto.CollectedAt.Value.Month && x.CollectedAt.Year == dto.CollectedAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.CommissionCurrency) || x.CommissionCurrency.Contains(dto.CommissionCurrency))
            );

            var pagesCount = (int)Math.Ceiling(collectionCommissionsCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var collectionCommissions = await _dbContext.CollectionCommissions.Where(x =>
            (dto.CommissionAmount == null || x.CommissionAmount == dto.CommissionAmount) &&
            (dto.CollectedAt == null || (x.CollectedAt.Day == dto.CollectedAt.Value.Day && x.CollectedAt.Month == dto.CollectedAt.Value.Month && x.CollectedAt.Year == dto.CollectedAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.CommissionCurrency) || x.CommissionCurrency.Contains(dto.CommissionCurrency))
            ).Skip(skipVal).Take(pageSize).ToListAsync();

            var collectionCommissionsViewModel =
               _mapper.Map<List<CollectionCommissionViewModel>>(collectionCommissions);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = collectionCommissionsViewModel,
                PagesCount = pagesCount
            };

            
        }
    }
}