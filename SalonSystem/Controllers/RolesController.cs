using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;
using System.Runtime.ConstrainedExecution;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleServices _services;

        public RolesController(RoleServices services)
        {
            _services = services;
        }


        // getting all roles and a specific role by id
        [HttpGet]
        public async Task<IActionResult> GetRoles(int? roleId)
        {
            if(roleId.HasValue)
            {
                var ser = await _services.GetRoleById(roleId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<RolesResponse>
                    {
                        Success = false,
                        Message = "Role not found."
                    });
                }
                return Ok(new ApiResponse<RolesResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            var serv = await _services.GetAllRoles();

            return Ok(new ApiResponse<IEnumerable<RolesResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        //creating roles
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            var serv = await _services.CreateRole(request);

            return CreatedAtAction(nameof(GetRoles), new {roleId = serv}, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Role created successfully."
            });
        }


        //updating roles and status
        [HttpPatch("{roleId}")]
        public async Task<IActionResult> UpdateRoles(int roleId, UpdateRolesRequest request)
        {
            var serv = await _services.UpdateRole(roleId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<RolesResponse>
                {
                    Success = false,
                    Message = "Role not found."
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Role updated successfully"
            });
        }


    }
}
