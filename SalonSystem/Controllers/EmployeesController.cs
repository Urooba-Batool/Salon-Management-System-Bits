using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _services;

        public EmployeesController(EmployeeService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int? employeeId)
        {
            if (employeeId.HasValue)
            {
                var ser = await _services.GetEmployeeById(employeeId.Value);
                if (ser is null)
                {
                    return NotFound(new
                    {
                        message = "Employee not found."
                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllEmployees();

            return Ok(serv);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest request)
        {
            var serv = await _services.CreateEmployee(request);

            return CreatedAtAction(nameof(GetEmployees), new { employeeId = serv }, new
            {
                message = "employee created successfully.",
                employeeId = serv
            });
        }

        [HttpPatch("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, UpdateEmployeeRequest request)
        {
            var serv = await _services.UpdateEmployee(employeeId, request);
            if (!serv)
            {
                return NotFound(new
                {
                    message = "Employee not found."
                });
            }
            return Ok(new
            {
                message = "Employee updated successfully."
            });
        }
    }
}
