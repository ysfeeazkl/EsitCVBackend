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
using EsitCV.Entities.Dtos.UserPictureDtos;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Entities.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.UserPictureValidators;

namespace EsitCV.Business.Concrete
{
    public class UserPictureManager: ManagerBase, IUserPictureService
    {
        IHttpContextAccessor _httpContextAccessor;
        IAwsStorageService _awsStorageService;
        public UserPictureManager(EsitCVContext context, IMapper mapper, IAwsStorageService awsStorageService, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _awsStorageService = awsStorageService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(UserPictureAddDto userPictureAddDto)
        {
            ValidationTool.Validate(new UserPictureAddDtoValidator(), userPictureAddDto);

            var userIsExist = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == userPictureAddDto.UserID);
            if (userIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı");
            var pictureIsExist = await DbContext.UserPictures.SingleOrDefaultAsync(a => a.UserID == userIsExist.ID);
            if (pictureIsExist is not null)
                return new DataResult(ResultStatus.Wrong, "Kullanıcının bir resmi var güncelleyebilirsiniz");

            var result = await _awsStorageService.UploadCVFileAsync(userPictureAddDto.File);
            if (result.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, result);

            var userPicture = Mapper.Map<UserPicture>(userPictureAddDto);
            userPicture.CreatedDate = DateTime.Now;
            //userPicture.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            userPicture.FileUrl = result.Message;
            userPicture.FileName = (string)result.Data;
            userPicture.User = userIsExist;
            userPicture.UserID = userIsExist.ID;
            userIsExist.UserPicture = userPicture;
            userIsExist.UserPictureID = userPicture.ID;

            await DbContext.UserPictures.AddAsync(userPicture);
             DbContext.Users.Update(userIsExist);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Kullanıcı Resimi başarıyla Eklendi.", userPicture);
        }
        public async Task<IDataResult> UpdateAsync(UserPictureUpdateDto userPictureUpdateDto)
        {
            ValidationTool.Validate(new UserPictureUpdateDtoValidator(), userPictureUpdateDto);

            var userIsExist = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == userPictureUpdateDto.UserID);
            if (userIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");
            var userPictureIsExist = await DbContext.UserPictures.SingleOrDefaultAsync(a => a.ID == userPictureUpdateDto.ID);
            if (userPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");

            _awsStorageService.DeleteFile(userPictureIsExist.FileName);
            var result = await _awsStorageService.UploadCVFileAsync(userPictureUpdateDto.File);
            if (result.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, result);

            var userPicture = Mapper.Map<UserPictureUpdateDto, UserPicture>(userPictureUpdateDto, userPictureIsExist);
            userPicture.CreatedDate = DateTime.Now;
            //userPicture .CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);


            userPicture.FileUrl = (string)result.Message;
            userPicture.FileName = (string)result.Data;
            userPicture.User = userIsExist;
            userPicture.UserID = userIsExist.ID;
            userIsExist.UserPicture = userPicture;
            userIsExist.UserPictureID = userPicture.ID;

            DbContext.UserPictures.Update(userPicture);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Şirket Resimi başarıyla güncellendş.", userPicture);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var userPictureIsExist = await DbContext.UserPictures.SingleOrDefaultAsync(a => a.UserID == id);
            if (userPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");
            return new DataResult(ResultStatus.Success, userPictureIsExist);
        }

        public async Task<IDataResult> GetByUserIdAsync(int id)
        {
            var userPictureIsExist = await DbContext.UserPictures.SingleOrDefaultAsync(a => a.ID == id);
            if (userPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");

            return new DataResult(ResultStatus.Success, userPictureIsExist);
        }


        public async Task<IDataResult> DeleteByFileUrlAsync(string fileUrl)
        {
            var userPictureIsExist = await DbContext.UserPictures.SingleOrDefaultAsync(a => a.FileUrl == fileUrl);
            if (userPictureIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir resim bulunamadı");
            _awsStorageService.DeleteFile(userPictureIsExist.FileName);
            DbContext.UserPictures.Remove(userPictureIsExist);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Error, "Resim başarıyla silindi", userPictureIsExist);
        }
    }
}
