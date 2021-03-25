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

namespace AMS.Infrastructure.Service.TransactionServices
{
    public class TransactionService : ITransactionService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public TransactionService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Transactions.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var transactions = await _dbContext.Transactions
                .Include(x=>x.Cheques)
                .Include(x=>x.ExchangeBills)
                .Include(x=>x.AccessoryFiles)
                .Include(x=>x.SaleContract)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var transactionsViewModel = _mapper.Map<List<TransactionViewModel>>(transactions);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = transactionsViewModel,
                PagesCount = pagesCount,
            };
        }

        public async Task<TransactionViewModel> Get(int id)
        {
            var transaction = await _dbContext.Transactions
                .Include(x=>x.Cheques)
                .Include(x=>x.ExchangeBills)
                .Include(x=>x.AccessoryFiles)
                .Include(x=>x.SaleContract)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TransactionViewModel>(transaction);
        }

        public async Task<int> Create(TransactionCreateDto dto, string userId)
        {
            var createdTransaction = _mapper.Map<TransactionDbEntity>(dto);

            await _dbContext.Transactions.AddAsync(createdTransaction);

            await _dbContext.SaveChangesAsync();

            return createdTransaction.Id;
        }

        public async Task<int> Update(TransactionUpdateDto dto, int id, string userId)
        {
            var oldTransaction = await _dbContext.Transactions
                .Include(x => x.Cheques)
                .Include(x => x.ExchangeBills)
                .Include(x => x.AccessoryFiles)
                .Include(x => x.SaleContract)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedTransaction = _mapper.Map(dto, oldTransaction);

            _dbContext.Transactions.Update(updatedTransaction);

            await _dbContext.SaveChangesAsync();

            return updatedTransaction.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            

            var deletedTransaction =  await _dbContext.Transactions.FindAsync(id);

            deletedTransaction.IsDeleted = true;

            _dbContext.Transactions.Update(deletedTransaction);

            await _dbContext.SaveChangesAsync();

            return deletedTransaction.Id;
        }
    }
}