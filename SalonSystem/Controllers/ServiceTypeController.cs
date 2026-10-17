using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Services;
using System.Collections;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly ServiceTypeServices _services;

        public ServiceTypeController(ServiceTypeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceTypes(int? serviceTypeId)
        {
            if (serviceTypeId.HasValue)
            {
                var ser = await _services.GetServiceTypeById(serviceTypeId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<ServiceTypeResponse>
                    {
                        Success = false,
                        Message = "Service type not found."
                    });
                }
                return Ok(new ApiResponse<ServiceTypeResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            var serv = await _services.GetAllServiceType();

            return Ok(new ApiResponse<IEnumerable<ServiceTypeResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateServiceType(CreateServiceTypeRequest request)
        {
            var serv = await _services.CreateServiceType(request);

            return CreatedAtAction(nameof(GetServiceTypes), new { serviceTypeId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Service type created successfully."
            });
        }

        [HttpPatch("{serviceTypeId}")]
        public async Task<IActionResult> UpdateServiceType(int serviceTypeId, UpdateServiceTypeRequest request)
        {
            var serv = await _services.UpdateServiceType(serviceTypeId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<ServiceTypeResponse>
                {
                    Success = false,
                    Message = "Service type not found."
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Service type updated successfully"
            });
        }
    }
}
