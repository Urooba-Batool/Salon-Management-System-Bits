using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;
using SalonSystem.Models.DTOs.ResponseModels;

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
                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Record not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Status updated successfully"
            });

        }

    }
}
