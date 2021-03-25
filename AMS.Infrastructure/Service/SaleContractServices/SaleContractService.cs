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

namespace AMS.Infrastructure.Service.SaleContractServices
{
    public class SaleContractService : ISaleContractService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public SaleContractService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.SaleContracts.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var saleContracts = await _dbContext.SaleContracts
                .Include(x=>x.Client)
                .Include(x=>x.Motor)
                .Include(x=>x.Transaction)
                .Include(x=>x.AccessorySpareParts)
                .Skip(skipVal).Take(pageSize).ToListAsync();


            var saleContractsViewModel = _mapper.Map<List<SaleContractViewModel>>(saleContracts);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = saleContractsViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<SaleContractViewModel> Get(int id)
        {
            var saleContract = await _dbContext.SaleContracts
                .Include(x=>x.Client)
                .Include(x=>x.Motor)
                .Include(x=>x.Transaction)
                .Include(x=>x.AccessorySpareParts)
                .SingleOrDefaultAsync(x=>x.Id== id);


            return _mapper.Map<SaleContractViewModel>(saleContract);
        }

        public async Task<int> Create(SaleContractCreateDto dto, string userId)
        {
            var createdSaleContract = _mapper.Map<SaleContractDbEntity>(dto);

            await _dbContext.SaleContracts.AddAsync(createdSaleContract);

            await _dbContext.SaveChangesAsync();

            return createdSaleContract.Id;
        }

        public async Task<int> Update(SaleContractUpdateDto dto, int id, string userId)
        {
            var oldSaleContract = await _dbContext.SaleContracts
                .Include(x => x.Client)
                .Include(x => x.Motor)
                .Include(x => x.Transaction)
                .Include(x => x.AccessorySpareParts)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedSaleContract = _mapper.Map(dto, oldSaleContract);

            _dbContext.SaleContracts.Update(updatedSaleContract);

            await _dbContext.SaveChangesAsync();

            return updatedSaleContract.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {

            var deletedSaleContract = await _dbContext.SaleContracts.FindAsync(id);

            deletedSaleContract.IsDeleted = true;

            _dbContext.SaleContracts.Update(deletedSaleContract);

            await _dbContext.SaveChangesAsync();

            return deletedSaleContract.Id;
        }
    }
}