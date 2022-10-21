using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerAddDto, Answer>();
            CreateMap<AnswerUpdateDto, Answer>();
            CreateMap<JobApplicationAnswerAddDto, Answer>();
        }
    }
}
