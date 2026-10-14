using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;
using Microsoft.Extensions.Options;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _services;
        private readonly PaginationSettings _paginationSettings;

        public UserController(UserService service, IOptions<PaginationSettings> paginationSettings)
        {
            _services = service;
            _paginationSettings = paginationSettings.Value;
        }

        //get all users or get user by id
        [HttpGet]
        public async Task<IActionResult> GetUsers(int? userId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if(userId.HasValue)
            {
                var ser = await _services.GetUserById(userId.Value);
                if(ser is null)
                {
                    return NotFound(new
                    {
                        message = "User not found."
                    });
                }
                return Ok(ser);
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllUsers(finalPageNumber, finalPageSize);

            return Ok(serv);
        }

        //create user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var serv = await _services.CreateUser(request);

            return CreatedAtAction(nameof(GetUsers), new { userId = serv }, new
            {
                message = "User created successfully.",
                userId = serv
            });
        }


        //update user
        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserRequest request)
        {
            var serv = await _services.UpdateUser(userId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(new
            {
                message = "User updated successfully"
            });
        }

    }
}
