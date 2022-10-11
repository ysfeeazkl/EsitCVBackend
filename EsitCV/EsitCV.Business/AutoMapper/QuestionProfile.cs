using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.QuestionDtos;

namespace EsitCV.Business.AutoMapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionAddDto, Question>();
            CreateMap<QuestionUpdateDto, Question>();
        }
    }
}
