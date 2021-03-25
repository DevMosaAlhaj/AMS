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

namespace AMS.Infrastructure.Service.ExchangeBillServices
{
    public class ExchangeBillService : IExchangeBillService
    {
        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public ExchangeBillService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.MaintenanceContracts.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var exchangeBills = await _dbContext.ExchangeBills
                .Include(x => x.Transaction)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var exchangeBillsViewModel = _mapper.Map<List<ExchangeBillViewModel>>(exchangeBills);


            return new PagingViewModel()
            {
                Data = exchangeBillsViewModel,
                CurrentPage = page,
                PagesCount = pagesCount
            };
        }

        public async Task<ExchangeBillViewModel> Get(int id)
        {
            var exchangeBill = await _dbContext.ExchangeBills
                .Include(x => x.Transaction)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ExchangeBillViewModel>(exchangeBill);
        }

        public async Task<int> Create(ExchangeBillCreateDto dto , string userId)
        {
            var createdExchangeBill = _mapper.Map<ExchangeBillDbEntity>(dto);

            createdExchangeBill.CreatedBy = userId;

            await _dbContext.ExchangeBills.AddAsync(createdExchangeBill);
            await _dbContext.SaveChangesAsync();

            return createdExchangeBill.Id;
        }

        public async Task<int> Update(ExchangeBillUpdateDto dto, int id, string userId)
        {
            var oldExchangeBill = await _dbContext.ExchangeBills
                .Include(x => x.Transaction)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedExchangeBill = _mapper.Map(dto, oldExchangeBill);

            updatedExchangeBill.UpdateAt = DateTime.Now;
            updatedExchangeBill.UpdatedBy = userId;

            _dbContext.ExchangeBills.Update(updatedExchangeBill);

            await _dbContext.SaveChangesAsync();

            return updatedExchangeBill.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedExchangeBill = await _dbContext.ExchangeBills.FindAsync(id);

            deletedExchangeBill.IsDeleted = true;
            deletedExchangeBill.UpdateAt = DateTime.Now;
            deletedExchangeBill.UpdatedBy = userId;

            _dbContext.ExchangeBills.Update(deletedExchangeBill);

            await _dbContext.SaveChangesAsync();

            return deletedExchangeBill.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize, ExchangeBillSearchDto dto)
        {
            var exchangeBillsCount = await _dbContext.ExchangeBills.CountAsync(x =>
            (dto.Amount == null || x.Amount == dto.Amount)&&
            (dto.DueAt == null || (x.DueAt.Day == dto.DueAt.Value.Day && x.DueAt.Month == dto.DueAt.Value.Month && x.DueAt.Year == dto.DueAt.Value.Year)) &&
            (dto.WritingAt == null || (x.WritingAt.Day == dto.WritingAt.Value.Day && x.WritingAt.Month == dto.WritingAt.Value.Month && x.WritingAt.Year == dto.WritingAt.Value.Year)) &&
            (dto.IsPaid == null || x.IsPaid == dto.IsPaid)&&
            (string.IsNullOrEmpty(dto.Currency) || x.Currency.Contains(dto.Currency))&&
            (string.IsNullOrEmpty(dto.DebtorName) || x.DebtorName.Contains(dto.DebtorName))
            );


            var pagesCount = (int)Math.Ceiling(exchangeBillsCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var exchangeBills = await _dbContext.ExchangeBills.Where(x =>
            (dto.Amount == null || x.Amount == dto.Amount) &&
            (dto.DueAt == null || (x.DueAt.Day == dto.DueAt.Value.Day && x.DueAt.Month == dto.DueAt.Value.Month && x.DueAt.Year == dto.DueAt.Value.Year)) &&
            (dto.DueAt == null || (x.WritingAt.Day == dto.WritingAt.Value.Day && x.WritingAt.Month == dto.WritingAt.Value.Month && x.WritingAt.Year == dto.WritingAt.Value.Year)) &&
            (dto.IsPaid == null || x.IsPaid == dto.IsPaid) &&
            (string.IsNullOrEmpty(dto.Currency) || x.Currency.Contains(dto.Currency)) &&
            (string.IsNullOrEmpty(dto.DebtorName) || x.DebtorName.Contains(dto.DebtorName))
            ).Skip(skipVal).Take(pageSize).ToListAsync();

            var exchangeBillsViewModel = _mapper.Map<List<ExchangeBillViewModel>>(exchangeBills);


            return new PagingViewModel()
            {
                Data = exchangeBillsViewModel,
                CurrentPage = page,
                PagesCount = pagesCount
            };
        }
    }
}