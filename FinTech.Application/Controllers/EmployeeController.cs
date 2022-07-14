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
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IEmployeeAppService _employeeAppService;
        private readonly IMapper _ObjectMapper;
        private readonly ILogger _logger;

        public EmployeeController(         
            IEmployeeAppService employeeAppService,
             IMapper ObjectMapper,
             ILogger<EmployeeController> logger
            )
        {      
            _employeeAppService = employeeAppService;
            _ObjectMapper = ObjectMapper;
            _logger = logger;
        }

        //GET api/employee
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll(GetAllEmployeeFilterDto input)
        {
            _logger.LogInformation("Get all employee.");

            var EmployeeList = await _employeeAppService.GetAll(input);
            return Ok(EmployeeList);
        }


        //GET api/employee/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            _logger.LogInformation($"Get all employee by id");

            var employee = await _employeeAppService.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound();
        }

        //POST api/employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(CreateEditEmployeeInputDto input)
        {

            _logger.LogInformation($"Create Employee");

            var employee = await _employeeAppService.Add(input);

            if (employee != null)
            {
                return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employee.Id }, employee);
            }

            return NotFound();
        }


        //PUT api/employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Update(int id, CreateEditEmployeeInputDto input)
        {

            _logger.LogInformation($"Update Employee");

            var employee = await _employeeAppService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            input.Id = employee.Id; 
            return (await _employeeAppService.Update(input));

            
        }

    }
}
