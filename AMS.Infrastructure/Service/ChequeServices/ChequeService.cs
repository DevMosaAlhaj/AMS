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

namespace AMS.Infrastructure.Service.ChequeServices
{
    public class ChequeService : IChequeService
    {
        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public ChequeService(AmsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.Cheques.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var cheques = await _dbContext.Cheques
                .Include(x => x.Transaction)
                .Skip(skipVal).Take(pageSize)
                .ToListAsync();

            var chequesViewModel = _mapper.Map<List<ChequeViewModel>>(cheques);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = chequesViewModel,
                PagesCount = pagesCount
            };
        }

        public async Task<ChequeViewModel> Get(int id)
        {
            var cheque = await _dbContext.Cheques.Include(x => x.Transaction)
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ChequeViewModel>(cheque);
        }

        public async Task<int> Create(ChequeCreateDto dto,string userId)
        {
            var createdCheque = _mapper.Map<ChequeDbEntity>(dto);

            createdCheque.CreatedBy = userId;

            await _dbContext.Cheques.AddAsync(createdCheque);
            await _dbContext.SaveChangesAsync();

            return createdCheque.Id;
        }

        public async Task<int> Update(ChequeUpdateDto dto, int id, string userId)
        {
            var oldCheque = await _dbContext.Cheques.Include(x => x.Transaction)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedCheque = _mapper.Map(dto, oldCheque);

            updatedCheque.UpdateAt = DateTime.Now;
            updatedCheque.UpdatedBy = userId;

            _dbContext.Cheques.Update(updatedCheque);
            await _dbContext.SaveChangesAsync();

            return updatedCheque.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedCheque = await _dbContext.Cheques.FindAsync(id);

            deletedCheque.IsDeleted = true;
            deletedCheque.UpdateAt = DateTime.Now;
            deletedCheque.UpdatedBy = userId;

            _dbContext.Cheques.Update(deletedCheque);
            await _dbContext.SaveChangesAsync();

            return deletedCheque.Id;
        }

        public async Task<PagingViewModel> Search(int page, int pageSize ,ChequeSearchDto dto)
        {
            var chequesCount = await _dbContext.Cheques.CountAsync(x =>
            (dto.Amount == null || x.Amount == dto.Amount) &&
            (dto.DueAt == null || (x.DueAt.Day == dto.DueAt.Value.Day && x.DueAt.Month == dto.DueAt.Value.Month && x.DueAt.Year == dto.DueAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.ByBank) || x.ByBank.Contains(dto.ByBank)) &&
            (string.IsNullOrEmpty(dto.DebtorName) || x.DebtorName.Contains(dto.DebtorName))
            );


            var pagesCount = (int)Math.Ceiling(chequesCount / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var cheques = await _dbContext.Cheques.Where(x =>
            (dto.Amount == null || x.Amount == dto.Amount) &&
            (dto.DueAt == null || (x.DueAt.Day == dto.DueAt.Value.Day && x.DueAt.Month == dto.DueAt.Value.Month && x.DueAt.Year == dto.DueAt.Value.Year)) &&
            (string.IsNullOrEmpty(dto.ByBank) || x.ByBank.Contains(dto.ByBank)) &&
            (string.IsNullOrEmpty(dto.DebtorName) || x.DebtorName.Contains(dto.DebtorName))
            ).Skip(skipVal).Take(pageSize).ToListAsync();

            var chequesViewModel = _mapper.Map<List<ChequeViewModel>>(cheques);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = chequesViewModel,
                PagesCount = pagesCount
            };

        }
    }
}