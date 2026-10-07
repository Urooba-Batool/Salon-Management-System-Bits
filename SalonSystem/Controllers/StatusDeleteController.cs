using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusDeleteController : ControllerBase
    {
        private readonly StatusDeleteServices _services;

        public StatusDeleteController(StatusDeleteServices services)
        {
            _services = services;
        }

        [HttpPatch]
        public async Task<IActionResult> StatusDelete(UpdateStatusDeleteRequest request)
        {
            var serv = await _services.DeleteStatus(request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Record not found"
                });
            }

            return Ok(new
            {
                message = "Status updated successfully"
            });

        }

    }
}
