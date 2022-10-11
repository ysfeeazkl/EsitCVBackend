using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.CirriculumVitaeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class CirriculumVitaeProfile : Profile
    {
        public CirriculumVitaeProfile()
        {
            CreateMap<CirriculumVitaeAddDto, CurriculumVitae>();
            CreateMap<CirriculumVitaeUpdateDto, CurriculumVitae>();
        }
    }
}
