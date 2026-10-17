using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;
using Microsoft.Extensions.Options;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _services;
        private readonly PaginationSettings _paginationSettings;

        public EmployeesController(EmployeeService services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int? employeeId, [FromQuery]  int? pageNumber, [FromQuery] int? pageSize)
        {
            if (employeeId.HasValue)
            {
                var ser = await _services.GetEmployeeById(employeeId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<EmployeeResponse>
                    {
                        Success = false,
                        Message = "Employee not found."
                    });
                }
                return Ok(new ApiResponse<EmployeeResponse>
                {
                    Success = true, 
                    Data = ser
                });
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllEmployees(finalPageNumber, finalPageSize);

            return Ok(new ApiResponse<IEnumerable<EmployeeResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest request)
        {
            var serv = await _services.CreateEmployee(request);

            return CreatedAtAction(nameof(GetEmployees), new { employeeId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Employee created successfully.",
            });
        }

        [HttpPatch("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, UpdateEmployeeRequest request)
        {
            var serv = await _services.UpdateEmployee(employeeId, request);
            if (!serv)
            {
                return NotFound(new ApiResponse<EmployeeResponse>
                {
                    Success = false,
                    Message = "Employee not found."
                });
            }
            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Employee updated successfully."
            });
        }
    }
}
