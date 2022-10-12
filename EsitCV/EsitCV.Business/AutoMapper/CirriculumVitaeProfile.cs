using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.CurriculumVitaeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class CurriculumVitaeProfile : Profile
    {
        public CurriculumVitaeProfile()
        {
            CreateMap<CurriculumVitaeAddDto, CurriculumVitae>();
            CreateMap<CurriculumVitaeUpdateDto, CurriculumVitae>();
        }
    }
}
