using AutoMapper;
using FinishProject.API.Models;
using FinishProject.Core;
using FinishProject.Core.DTOs;
using FinishProject.Core.Models;
using FinishProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinishProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _employeeService.GetListAsync();
                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeAsync(id);
                if (employee == null) return NotFound($"Employee with ID {id} not found");
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeePostModel employee)
        {
            if (employee == null)
                return BadRequest("Invalid employee data");

            
                var employeeToAdd = new Employee
                {
                    Tz = employee.Tz,
                    Name = employee.Name,
                    Password = employee.Password,
                    Email = employee.Email,
                    Position = employee.Position
                };
                var newEmployee = await _employeeService.AddAsync(employeeToAdd);
                return CreatedAtAction(nameof(GetEmployeeAsync), new { id = newEmployee.Id }, newEmployee);
            }
         
                
        

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee updatedEmployee)
        {
            if (updatedEmployee == null || id != updatedEmployee.Id)
                return BadRequest("Invalid employee data");

            try
            {
                var existingEmployee = await _employeeService.GetEmployeeAsync(id);
                if (existingEmployee == null)
                    return NotFound($"Employee with ID {id} not found");

                await _employeeService.UpdateAsync(updatedEmployee);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                var existingEmployee = await _employeeService.GetEmployeeAsync(id);
                if (existingEmployee == null)
                    return NotFound($"Employee with ID {id} not found");

                await _employeeService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
