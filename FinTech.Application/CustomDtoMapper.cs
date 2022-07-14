using AutoMapper;
using FinTech.Application.Dto;
using FinTech.Core.FTEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application
{
    public  class CustomDtoMapper : Profile 
    {
        public CustomDtoMapper()
        {
            CreateMap<EmployeeDto, Employee>()
                 .ForMember(Employee => Employee.Id, e => e.MapFrom(s => s.EmployeeTemperatures.Select(m => m.EmployeeId)))
                  .ReverseMap();

            CreateMap<CreateEditEmployeeInputDto, Employee>()
                .ReverseMap();

            CreateMap<CreateEditEmployeeInputDto, EmployeeDto>()
                .ReverseMap();

            CreateMap<CreateEditEmployeeTemperatureInputDto, EmployeeTemperature>()
               .ReverseMap();

            CreateMap<CreateEditEmployeeTemperatureInputDto, EmployeeTemperatureDto>()
               .ReverseMap();

            CreateMap<EmployeeTemperature, EmployeeTemperatureDto> ()                            
                .ReverseMap();
        }
    }
}
