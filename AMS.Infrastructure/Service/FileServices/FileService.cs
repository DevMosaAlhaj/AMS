using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Data.Data;
using AMS.Data.DbEntity;
using AMS.Infrastructure.Service.StorageServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Infrastructure.Service.FileServices
{
    
    public class FileService : IFileService
    {


        private readonly IMapper _mapper;
        private readonly AmsDbContext _dbContext;
        private readonly IStorageService _storageService;

        public FileService (IMapper mapper , AmsDbContext dbContext, IStorageService storageService)
        {
            _dbContext = dbContext;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task<PagingViewModel> GetAll(int page, int pageSize)
        {
            var pagesCount = (int)Math.Ceiling(await _dbContext.Files.CountAsync() / (double)pageSize);

            if (page > pagesCount || page < 1)
                page = 1;


            var skipVal = (page - 1) * pageSize;


            var files = await _dbContext.Files
                .Include(x=> x.Transaction)
                .Skip(skipVal).Take(pageSize).ToListAsync();

            var filesViewModel = _mapper.Map<List<FileViewModel>>(files);

           

            return new PagingViewModel()
            {
                CurrentPage = page,
                Data = filesViewModel,
                PagesCount = pagesCount
            };

        }

        public async Task<FileViewModel> Get(int id)
        {
            var file = await _dbContext.Files
                .Include(x => x.Transaction).SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<FileViewModel>(file);
        }

        public async Task<int> Create(FileCreateDto dto , string userId)
        {
            var createdFile = _mapper.Map<FileDbEntity>(dto);

            createdFile.FilePath = await _storageService.SaveFile(dto.File,$"Transaction{dto.TransactionId}",dto.FileExtension);

            await _dbContext.Files.AddAsync(createdFile);

            await _dbContext.SaveChangesAsync();

           return createdFile.Id;
        }

        public async Task<int> Update(FileUpdateDto dto, int id, string userId)
        {
            var oldFile = await _dbContext.Files
                .Include(x => x.Transaction).SingleOrDefaultAsync(x => x.Id == id);


            var updatedFile = _mapper.Map(dto, oldFile);

            updatedFile.FilePath = await _storageService.SaveFile(dto.File, $"Transaction{dto.TransactionId}", dto.FileExtension);

            _dbContext.Files.Update(updatedFile);

            await _dbContext.SaveChangesAsync();

            return updatedFile.Id;
        }

        public async Task<int> Delete(int id, string userId)
        {
            var deletedFile = await _dbContext.Files.FindAsync(id);

            deletedFile.IsDeleted = true;

            _dbContext.Files.Update(deletedFile);

            await _dbContext.SaveChangesAsync();

            return deletedFile.Id;

        }
    }
}