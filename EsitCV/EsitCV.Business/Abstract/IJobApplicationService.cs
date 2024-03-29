﻿using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.JobApplicationDtos;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Abstract
{
    public interface IJobApplicationService
    {
        Task<IDataResult> AddAsync(JobApplicationAddDto jobApplicationAddDto);
        Task<IDataResult> UpdateAsync(JobApplicationUpdateDto jobApplicationUpdateDto);
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetAllByUserIdAsync(int id);
        Task<IDataResult> DeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByIdAsync(int id);
    }
}
