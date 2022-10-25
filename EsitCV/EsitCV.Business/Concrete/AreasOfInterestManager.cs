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

namespace EsitCV.Business.Concrete
{
    public class AreasOfInterestManager: ManagerBase, IAreasOfInterestService
    {
        public AreasOfInterestManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {
                
        }

        public Task<IDataResult> AddAsync(AreasOfInterestAddDto areasOfInterestAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByProfileIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> UpdateAsync(AreasOfInterestUpdateDto areasOfInterestUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
