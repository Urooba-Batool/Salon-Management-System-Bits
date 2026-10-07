using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

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
                    return NotFound(new
                    {
                        message = "Service Type not found."
                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllServiceType();
            return Ok(serv);
        }


        [HttpPost]
        public async Task<IActionResult> CreateServiceType(CreateServiceTypeRequest request)
        {
            var serv = await _services.CreateServiceType(request);

            return CreatedAtAction(nameof(GetServiceTypes), new { serviceTypeId = serv }, new
            {
                message = "Service type created successfully.",
                serviceTypeId = serv
            });
        }

        [HttpPatch("{serviceTypeId}")]
        public async Task<IActionResult> UpdateServiceType(int serviceTypeId, UpdateServiceTypeRequest request)
        {
            var serv = await _services.UpdateServiceType(serviceTypeId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Service type not found"
                });
            }

            return Ok(new
            {
                message = "Service type updated successfully"
            });
        }
    }
}
