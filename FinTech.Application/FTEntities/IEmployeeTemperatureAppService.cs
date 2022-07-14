using FinTech.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinTech.Application.FTEntities
{
    public interface IEmployeeTemperatureAppService
    {
        Task<List<EmployeeTemperatureDto>> GetAll(GetAllTemperatureEmployeeFilterDto input);

        Task<EmployeeTemperatureDto> GetEmployeeTemperatureById(long Id);

        Task<EmployeeTemperatureDto> Add(CreateEditEmployeeTemperatureInputDto employeeTemp);

        Task<EmployeeTemperatureDto> Update(CreateEditEmployeeTemperatureInputDto employeeTemp);
    }
}