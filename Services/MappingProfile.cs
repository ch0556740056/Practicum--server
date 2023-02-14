using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTO_s;
using Repositories.Entities;

namespace Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Child, ChildDto>().ReverseMap();
            CreateMap<PersonalDetail, PersonalDetailDto>().ReverseMap();
        }
    }
}
