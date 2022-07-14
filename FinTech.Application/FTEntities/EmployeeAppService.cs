using AutoMapper;
using FinTech.Application.Dto;
using FinTech.Application.Repository;
using FinTech.Core.FTEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTech.Application.Extension;

namespace FinTech.Application.FTEntities
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IUnitOfWork _iUnitOfWork;        
        private readonly IMapper _ObjectMapper;

        public EmployeeAppService
            (
                IUnitOfWork iUnitOfWork,
                 IMapper ObjectMapper
            )

        {
            _iUnitOfWork = iUnitOfWork;
            _ObjectMapper = ObjectMapper;
        }

        public async Task<List<EmployeeDto>> GetAll(GetAllEmployeeFilterDto input)
        {
            var data = (await _iUnitOfWork.Employee
                .GetAll())
                .Include(x => x.EmployeeTemperatures)
                .WhereIf(!string.IsNullOrEmpty(input.FirstName), x => x.FirstName.ToLower().Contains(input.FirstName.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(input.LastName), x => x.LastName.ToLower().Contains(input.LastName.ToLower()))
                .WhereIf(input.Id > 0, x => x.Id == input.Id)
                ;
                

            return (_ObjectMapper.Map<List<EmployeeDto>>(data));
        }
        public async Task<EmployeeDto> GetEmployeeById(long Id)
        {
            return _ObjectMapper.Map<EmployeeDto>
                    ((await _iUnitOfWork.Employee.GetAll(c => c.Id == Id)).FirstOrDefault());
        }


        public async Task<EmployeeDto> Add(CreateEditEmployeeInputDto employee)
        {
            var data = _ObjectMapper.Map<Employee>(employee);

            if (data.Id == null || data.Id == 0)
            {
                await _iUnitOfWork.Employee.CreateAsync(data);

                await _iUnitOfWork.Save();

                return (await this.GetEmployeeById(data.Id));
            }
            else
            {

                throw new Exception("Error creating employee!");
            }
        }


        public async Task<EmployeeDto> Update(CreateEditEmployeeInputDto employee)
        {
            var data = _ObjectMapper.Map<Employee>(employee);

            await _iUnitOfWork.Employee.UpdateAsync(data);

            await _iUnitOfWork.Save();

            return(await this.GetEmployeeById(data.Id));

        }
    }
}
