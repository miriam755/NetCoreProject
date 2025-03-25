using AutoMapper;
using FinishProject.Core.DTOs;
using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace FinishProject.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<TimeLog, TimeLogDto>().ReverseMap();  
       CreateMap<Request, RequestDto>().ReverseMap();
        }
    }
}
