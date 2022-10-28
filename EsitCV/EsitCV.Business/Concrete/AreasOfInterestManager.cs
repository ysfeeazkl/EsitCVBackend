using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AboutValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AreasOfInterestValidators;

namespace EsitCV.Business.Concrete
{
    public class AreasOfInterestManager: ManagerBase, IAreasOfInterestService
    {
        public AreasOfInterestManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {
                
        }

        public async Task<IDataResult> AddAsync(AreasOfInterestAddDto areasOfInterestAddDto)
        {
            ValidationTool.Validate(new AreasOfInterestAddDtoValidator(), areasOfInterestAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == areasOfInterestAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var areasOfInterest = Mapper.Map<AreasOfInterest>(areasOfInterestAddDto);
            areasOfInterest.CreatedDate = DateTime.Now;
            //areasOfInterest.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.AreasOfInterests.AddAsync(areasOfInterest);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlgili alan başarıyla Eklendi.", areasOfInterest);
        }

        public async Task<IDataResult> UpdateAsync(AreasOfInterestUpdateDto areasOfInterestUpdateDto)
        {
            throw new NotImplementedException();
        }



        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetByProfileIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
