using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonServiceController : ControllerBase
    {
        private readonly ServiceSalonServices _services;
        private readonly PaginationSettings _paginationSettings;

        public SalonServiceController(ServiceSalonServices services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices(int? serviceId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
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

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllSalonServices(finalPageNumber, finalPageSize);
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
