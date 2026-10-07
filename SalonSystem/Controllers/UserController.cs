using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _services;

        public UserController(UserService service)
        {
            _services = service;
        }

        //get all users or get user by id
        [HttpGet]
        public async Task<IActionResult> GetUsers(int? userId)
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

            var serv = await _services.GetAllUsers();

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
