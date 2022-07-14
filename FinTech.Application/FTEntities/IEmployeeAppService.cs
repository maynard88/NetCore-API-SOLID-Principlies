using FinTech.Application.Dto;
using FinTech.Application.Repository;
using FinTech.Core.FTEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinTech.Application.FTEntities
{
    public interface IEmployeeAppService 
    {
        Task<List<EmployeeDto>> GetAll(GetAllEmployeeFilterDto input);

        Task<EmployeeDto> GetEmployeeById(long Id);

        Task<EmployeeDto> Add(CreateEditEmployeeInputDto employee);

        Task<EmployeeDto> Update(CreateEditEmployeeInputDto employee);
    }
}