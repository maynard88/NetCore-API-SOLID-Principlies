using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTech.Application.Dto;
using FinTech.Application.FTEntities;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace FinTech.Application.Controllers
{
    [Route("api/employeetemperature")]
    [ApiController]
    public class EmployeeTemperatureController : ControllerBase
    {

        private IEmployeeTemperatureAppService _employeeTemperatureAppService;
        private readonly IMapper _ObjectMapper;
        private readonly ILogger _logger;

        public EmployeeTemperatureController(
            IEmployeeTemperatureAppService employeeTemperatureAppService,
             IMapper ObjectMapper,
             ILogger<EmployeeController> logger
            )
        {
            _employeeTemperatureAppService = employeeTemperatureAppService;
            _ObjectMapper = ObjectMapper;
            _logger = logger;
        }

        //GET api/employeetemperature
        [HttpGet]
        public async Task<ActionResult<List<EmployeeTemperatureDto>>> GetAll(GetAllTemperatureEmployeeFilterDto input)
        {
            _logger.LogInformation("Get all employee temperature.");

            var EmployeeList = await _employeeTemperatureAppService.GetAll(input);

            return Ok(EmployeeList);
        }



        //GET api/employeetemperature/{id}
        [HttpGet("{id}", Name = "GetEmployeeTemperatureById")]
        public async Task<ActionResult<EmployeeTemperatureDto>> GetEmployeeTemperatureById(int id)
        {
            _logger.LogInformation("Get all employee temperature by id.");

            var employeeTemp = await _employeeTemperatureAppService.GetEmployeeTemperatureById(id);
            if (employeeTemp != null)
            {
                return Ok(employeeTemp);
            }

            return NotFound();
        }

        //POST api/employeetemperature
        [HttpPost]
        public async Task<ActionResult<EmployeeTemperatureDto>> Create(CreateEditEmployeeTemperatureInputDto input)
        {
            _logger.LogInformation("Create employee temperature.");

            var employee = await _employeeTemperatureAppService.Add(input);

            if (employee != null)
            {
                return CreatedAtRoute(nameof(GetEmployeeTemperatureById), new { Id = employee.Id }, employee);
            }

            return NotFound();
        }


        //PUT api/employeetemperature/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeTemperatureDto>> Update(int id, CreateEditEmployeeTemperatureInputDto input)
        {
            _logger.LogInformation("Update employee temperature.");

            var employee = await _employeeTemperatureAppService.GetEmployeeTemperatureById(id);

            if (employee == null)
            {
                return NotFound();
            }

            input.Id = employee.Id; 
            return (await _employeeTemperatureAppService.Update(input));

            
        }
        
    }
}
