﻿using EsitCV.Entities.ComplexTypes;
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
using EsitCV.Entities.Dtos.JobApplicationDtos;

namespace EsitCV.Business.Concrete
{
    public class JobApplicationManager : ManagerBase, IJobApplicationService
    {
        public JobApplicationManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync(JobApplicationAddDto jobApplicationAddDto)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> UpdateAsync(JobApplicationUpdateDto jobApplicationUpdateDto)
        {
            throw new NotImplementedException();
        }

       

        public Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetAllByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}