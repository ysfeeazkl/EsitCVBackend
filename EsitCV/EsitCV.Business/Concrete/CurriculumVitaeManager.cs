﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.CurriculumVitaeDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.CurriculumVitaeValidators;
using Microsoft.EntityFrameworkCore;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using EsitCV.Business.AbstractUtilities;


namespace EsitCV.Business.Concrete
{
    public class CurriculumVitaeManager : ManagerBase, ICurriculumVitaeService
    {
        IHttpContextAccessor _httpContextAccessor;
        IAwsStorageService _awsStorageService;

        public CurriculumVitaeManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAwsStorageService awsStorageService) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
            _awsStorageService = awsStorageService;
        }

        public async Task<IDataResult> AddAsync(CurriculumVitaeAddDto curriculumVitaeAddDto)
        {
            ValidationTool.Validate(new CurriculumVitaeAddDtoValidator(), curriculumVitaeAddDto);

            var userIsExist = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == curriculumVitaeAddDto.UserID);
            if (userIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı  ");
            //var cvIsExist = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.UserID == curriculumVitaeAddDto.UserID);
            //if (cvIsExist is not null)
            //    return new DataResult(ResultStatus.Error, "Bu kullanıcının zaten cv si var");

            var result = await _awsStorageService.UploadCVFileAsync(curriculumVitaeAddDto.File);
            if (result.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, result);

            var curriculumVitae = Mapper.Map<CurriculumVitae>(curriculumVitaeAddDto);
            curriculumVitae.CreatedDate = DateTime.Now;
            //curriculumVitae.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);


            curriculumVitae.FileUrl = result.Message;
            curriculumVitae.FileName = (string)result.Data;
            curriculumVitae.User = userIsExist;
            curriculumVitae.UserID = userIsExist.ID;
            await DbContext.CurriculumVitaes.AddAsync(curriculumVitae);


            userIsExist.CurriculumVitae = curriculumVitae;
            userIsExist.CurriculumVitaeID = curriculumVitae.ID;

            DbContext.Users.Update(userIsExist);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Cv başarıyla Eklendi.", curriculumVitae);

        }
        public async Task<IDataResult> UpdateAsync(CurriculumVitaeUpdateDto curriculumVitaeUpdateDto)
        {
            ValidationTool.Validate(new CurriculumVitaeUpdateDtoValidator(), curriculumVitaeUpdateDto);
           
            var cvIsExist = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.UserID == curriculumVitaeUpdateDto.ID);
            if (cvIsExist is null)
                return new DataResult(ResultStatus.Error, "böyle bir cv bulunamadı");

            var curriculumVitae = Mapper.Map<CurriculumVitae>(curriculumVitaeUpdateDto);

            _awsStorageService.DeleteCVFile(cvIsExist.FileUrl);                                                   
            await _awsStorageService.UploadCVFileAsync(curriculumVitaeUpdateDto.File);                            
            curriculumVitae.FileUrl = _awsStorageService.GetCVFileUrl(curriculumVitaeUpdateDto.File.FileName);    

            curriculumVitae.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            curriculumVitae.ModifiedDate = DateTime.Now;

            DbContext.CurriculumVitaes.Update(curriculumVitae);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Cv başarıyla Eklendi.", curriculumVitae);
        }

       

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<CurriculumVitae> query = DbContext.Set<CurriculumVitae>().Include(a=>a.User).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.User.FirstName) : query.OrderByDescending(a => a.User.FirstName);
                    break;
                case OrderBy.CreatedDate:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }

            if (currentPage != 0 && pageSize != 0)
            {
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<CurriculumVitae>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);

        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var curriculumVitae = await DbContext.CurriculumVitaes.Include(a=>a.User).SingleOrDefaultAsync(a => a.ID == id);
            if (curriculumVitae is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunamadı");
            return new DataResult(ResultStatus.Success, curriculumVitae);
        }

        public async Task<IDataResult> GetByUserIdAsync(int id)
        {
            var curriculumVitae = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.UserID == id);
            if (curriculumVitae is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunamadı");
            return new DataResult(ResultStatus.Success, curriculumVitae);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var curriculumVitae = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.ID == id);
            if (curriculumVitae is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunmuyor");

            curriculumVitae.ModifiedDate = DateTime.Now;
            curriculumVitae.IsActive = false;
            curriculumVitae.IsDeleted = true;

            _awsStorageService.DeleteFile(curriculumVitae.FileName);

            DbContext.CurriculumVitaes.Update(curriculumVitae);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "CV başarı ile silindi");
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var curriculumVitae = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.ID == id);
            if (curriculumVitae is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunmuyor");

            _awsStorageService.DeleteFile(curriculumVitae.FileName);
            DbContext.CurriculumVitaes.Remove(curriculumVitae);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Cv başarı ile silindi");
        }
    }
}
