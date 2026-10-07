using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonServiceController : ControllerBase
    {
        private readonly ServiceSalonServices _services;

        public SalonServiceController(ServiceSalonServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices(int? serviceId)
        {
            if (serviceId.HasValue)
            {
                var ser = await _services.GetSalonServiceById(serviceId.Value);
                if (ser is null)
                {
                    return NotFound(new
                    {
                        message = "Service not found."
                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllSalonServices();
            return Ok(serv);
        }


        [HttpPost]
        public async Task<IActionResult> CreateService(CreateSalonServiceRequest request)
        {
            var serv = await _services.CreateService(request);

            return CreatedAtAction(nameof(GetServices), new { serviceId = serv }, new
            {
                message = "Service created successfully.",
                serviceId = serv
            });
        }

        [HttpPatch("{serviceId}")]
        public async Task<IActionResult> UpdateService(int serviceId, UpdateSalonServiceRequest request)
        {
            var serv = await _services.UpdateService(serviceId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Service not found"
                });
            }

            return Ok(new
            {
                message = "Service updated successfully"
            });
        }
    }
}
