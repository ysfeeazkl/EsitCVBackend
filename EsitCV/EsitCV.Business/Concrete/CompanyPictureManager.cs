using System;
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
using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.CompanyPicuteValidators;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Entities.Concrete;

namespace EsitCV.Business.Concrete
{
    public class CompanyPictureManager: ManagerBase, ICompanyPictureService
    {
        IHttpContextAccessor _httpContextAccessor;
        IAwsStorageService _awsStorageService;
        public CompanyPictureManager(EsitCVContext context, IMapper mapper, IAwsStorageService awsStorageService, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _awsStorageService = awsStorageService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(CompanyPictureAddDto companyPictureAddDto)
        {
            ValidationTool.Validate(new CompanyPictureAddDtoValidator(), companyPictureAddDto);

            var companyIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == companyPictureAddDto.CompanyID);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");
            var pictureIsExist = await DbContext.CompanyPictures.SingleOrDefaultAsync(a => a.CompanyID == companyIsExist.ID);
            if (pictureIsExist is not null)
                return new DataResult(ResultStatus.Wrong, "Şirketin bir resimi zaten var güncelleyebilirsiniz");

            var result = await _awsStorageService.UploadCVFileAsync(companyPictureAddDto.File);
            if (result.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, result);

            var companyPicture = Mapper.Map<CompanyPicture>(companyPictureAddDto);
            companyPicture.CreatedDate = DateTime.Now;
            //companyPicture.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);


            companyPicture.FileUrl = (string)result.Message;
            companyPicture.FileName = (string)result.Data;
            companyPicture.Company = companyIsExist;
            companyPicture.CompanyID = companyIsExist.ID;

            companyIsExist.CompanyPicture = companyPicture;
            companyIsExist.CompanyPictureID = companyPicture.ID;

            await DbContext.CompanyPictures.AddAsync(companyPicture);
            DbContext.Companies.Update(companyIsExist);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Şirket Resimi başarıyla Eklendi.", companyPicture);
        }
        public async Task<IDataResult> UpdateAsync(CompanyPictureUpdateDto companyPictureUpdateDto)
        {
            ValidationTool.Validate(new CompanyPictureUpdateDtoValidator(), companyPictureUpdateDto);

            var companyIsExist = await DbContext.Companies.Include(a=>a.CompanyPicture).SingleOrDefaultAsync(a => a.ID == companyPictureUpdateDto.CompanyID);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");
            var companyPictureIsExist = await DbContext.CompanyPictures.SingleOrDefaultAsync(a => a.ID == companyIsExist.CompanyPicture.ID);
            if (companyPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");

            _awsStorageService.DeleteFile(companyPictureIsExist.FileName);
            var result = await _awsStorageService.UploadCVFileAsync(companyPictureUpdateDto.File);
            if (result.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, result);

            var companyPicture = Mapper.Map<CompanyPictureUpdateDto,CompanyPicture>(companyPictureUpdateDto, companyPictureIsExist);
            companyPicture.CreatedDate = DateTime.Now;
            //companyPicture.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);


            companyPicture.FileUrl = (string)result.Message;
            companyPicture.FileName = (string)result.Data;
            companyPicture.Company = companyIsExist;
            companyPicture.CompanyID = companyIsExist.ID;

            DbContext.CompanyPictures.Update(companyPicture);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Şirket Resimi başarıyla güncellendi.", companyPicture);
        }


        public async Task<IDataResult> GetByCompanyIdAsync(int id)
        {
          
            var companyPictureIsExist = await DbContext.CompanyPictures.SingleOrDefaultAsync(a => a.CompanyID == id);
            if (companyPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");
            return new DataResult(ResultStatus.Error, companyPictureIsExist);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var companyPictureIsExist = await DbContext.CompanyPictures.SingleOrDefaultAsync(a => a.ID == id);
            if (companyPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");
            return new DataResult(ResultStatus.Error, companyPictureIsExist);
        }
        public async Task<IDataResult> DeleteByFileUrlAsync(string fileUrl)
        {
            var companyPictureIsExist = await DbContext.CompanyPictures.SingleOrDefaultAsync(a => a.FileUrl == fileUrl);
            if (companyPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");

            _awsStorageService.DeleteFile(companyPictureIsExist.FileName);

            DbContext.CompanyPictures.Remove(companyPictureIsExist);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Error, "Resim başarıyla silindi" ,companyPictureIsExist);
        }
    }
}
