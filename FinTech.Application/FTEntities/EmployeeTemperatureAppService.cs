using FinTech.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTech.Core.Entities;
using FinTech.Core.FTEntities;
using Microsoft.EntityFrameworkCore;
using FinTech.Application.Dto;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FinTech.Application.Extension;

namespace FinTech.Application.FTEntities
{
    public class EmployeeTemperatureAppService :  IEmployeeTemperatureAppService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly ILogger Logger;
        private readonly IMapper _ObjectMapper;

        public EmployeeTemperatureAppService
            (
                IUnitOfWork iUnitOfWork,
                 IMapper ObjectMapper
            ) 
        
        {
            _iUnitOfWork = iUnitOfWork;
            _ObjectMapper = ObjectMapper;
        }

        public async Task<List<EmployeeTemperatureDto>> GetAll(GetAllTemperatureEmployeeFilterDto input)
        {
             var data = (await _iUnitOfWork.EmployeeTemperature
                .GetAll())
                .Include(x => x.EmployeeFk)
                .WhereIf(!string.IsNullOrEmpty(input.FirstName), x => x.EmployeeFk.FirstName.ToLower().Contains(input.FirstName.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(input.LastName), x => x.EmployeeFk.LastName.ToLower().Contains(input.LastName.ToLower()))
                .WhereIf(input.Id > 0, x => x.EmployeeFk.Id == input.Id)
                .WhereIf(input.TemperatureStartFilter.HasValue, x => x.Temperature >= input.TemperatureStartFilter.Value)
                .WhereIf(input.TemperatureEndFilter.HasValue, x => x.Temperature <= input.TemperatureEndFilter.Value)
                .WhereIf(input.RecordDateStart.HasValue, x => x.RecordDate.Date >= input.RecordDateStart.Value.Date)
                .WhereIf(input.RecordDateEnd.HasValue, x => x.RecordDate.Date <= input.RecordDateEnd.Value.Date)
                ;
                

            return (_ObjectMapper.Map<List<EmployeeTemperatureDto>>(data));
        }


        public async Task<EmployeeTemperatureDto> GetEmployeeTemperatureById(long Id)
        {
            return _ObjectMapper.Map<EmployeeTemperatureDto>
                    ((await _iUnitOfWork.EmployeeTemperature.GetAll(c => c.Id == Id)).FirstOrDefault());
        }

        public async Task<EmployeeTemperatureDto> Add(CreateEditEmployeeTemperatureInputDto employeeTemp)
        {
            var data = _ObjectMapper.Map<EmployeeTemperature>(employeeTemp);

            if (data.Id == null || data.Id == 0)
            {
                await _iUnitOfWork.EmployeeTemperature.CreateAsync(data);

                await _iUnitOfWork.Save();

                return (await this.GetEmployeeTemperatureById(data.Id));
            }
            else
            {

                throw new Exception("Error creating employee!");
            }
        }


        public async Task<EmployeeTemperatureDto> Update(CreateEditEmployeeTemperatureInputDto employeeTemp)
        {
            var data = _ObjectMapper.Map<EmployeeTemperature>(employeeTemp);

            await _iUnitOfWork.EmployeeTemperature.UpdateAsync(data);

            await _iUnitOfWork.Save();

            return (await this.GetEmployeeTemperatureById(data.Id));

        }
    }
}
