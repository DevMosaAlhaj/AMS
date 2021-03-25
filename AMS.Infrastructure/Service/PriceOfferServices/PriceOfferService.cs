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

namespace AMS.Infrastructure.Service.PriceOfferServices
{
    public class PriceOfferService : IPriceOfferService
    {

        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;

        public PriceOfferService(IMapper mapper, AmsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int) Math.Ceiling(await _dbContext.PriceOffers.CountAsync() / (double) pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;

            var priceOffers = await _dbContext.PriceOffers
                .Include(x=>x.MaintenanceService)
                .Include(x=>x.SpareParts)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var priceOffersViewModel = _mapper.Map<List<PriceOfferViewModel>>(priceOffers);

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = priceOffersViewModel,
                PagesCount = pagesCount
            };
        }

        public async Task<PriceOfferViewModel> Get(int id)
        {
            var priceOffer = await _dbContext.PriceOffers
                .Include(x => x.MaintenanceService)
                .Include(x => x.SpareParts)
                .SingleOrDefaultAsync(x=> x.Id == id);

            return _mapper.Map<PriceOfferViewModel>(priceOffer);
        }

        public async Task<int> Create(PriceOfferCreateDto dto,string userId)
        {
            var createdPriceOffer = _mapper.Map<PriceOfferDbEntity>(dto);

            await _dbContext.PriceOffers.AddAsync(createdPriceOffer);

            await _dbContext.SaveChangesAsync();

            return createdPriceOffer.Id;
        }

        public async Task<int> Update(PriceOfferUpdateDto dto, int id, string userId)
        {
            var oldPriceOffer = await _dbContext.PriceOffers
                .Include(x => x.MaintenanceService)
                .Include(x => x.SpareParts)
                .SingleOrDefaultAsync(x => x.Id == id);

            var updatedPriceOffer = _mapper.Map(dto, oldPriceOffer);

            _dbContext.PriceOffers.Update(updatedPriceOffer);

            await _dbContext.SaveChangesAsync();

            return updatedPriceOffer.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            
            var deletedPriceOffer = await _dbContext.PriceOffers.FindAsync(id);

            deletedPriceOffer.IsDeleted = true;

            _dbContext.PriceOffers.Update(deletedPriceOffer);

            await _dbContext.SaveChangesAsync();

            return deletedPriceOffer.Id;
        }
    }
}