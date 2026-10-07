using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;

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
                    return NotFound(new
                    {
                        message = "Role not found."
                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllRoles();

            return Ok(serv);
        }


        //creating roles
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            var serv = await _services.CreateRole(request);

            return CreatedAtAction(nameof(GetRoles), new {roleId = serv}, new
            {
                message = "Role created successfully.",
                roleId = serv
            });
        }


        //updating roles and status
        [HttpPatch("{roleId}")]
        public async Task<IActionResult> UpdateRoles(int roleId, UpdateRolesRequest request)
        {
            var serv = await _services.UpdateRole(roleId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Role not found"
                });
            }

            return Ok(new
            {
                message = "Role updated successfully"
            });
        }


    }
}
