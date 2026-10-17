using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;
using System.Runtime.ConstrainedExecution;

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
                    return NotFound(new ApiResponse<UserResponse>
                    {
                        Success = false,
                        Message = "User not found."
                    });
                }
                return Ok(new ApiResponse<UserResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllUsers(finalPageNumber, finalPageSize);

            return Ok(new ApiResponse<IEnumerable<UserResponse>>
            {
                Success = true,
                Data = serv
            });
        }

        //create user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var serv = await _services.CreateUser(request);

            return CreatedAtAction(nameof(GetUsers), new { userId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "User created successfully"
            });
        }


        //update user
        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserRequest request)
        {
            var serv = await _services.UpdateUser(userId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<UserResponse>
                {
                    Success = false,
                    Message = "User not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "User updated successfully"
            });
        }

    }
}
