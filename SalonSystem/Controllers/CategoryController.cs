using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Models.Entities;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServices _services;
        private readonly PaginationSettings _paginationSettings;

        public CategoryController(CategoryServices services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int? categoryId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if(categoryId.HasValue)
            {
                var ser = await _services.GetCategoryById(categoryId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<CategoryResponse>
                    {
                        Success = false,
                        Message = "Category not found."
                    });
                }
                return Ok(new ApiResponse<CategoryResponse>
                {
                    Success = true,
                    Data = ser
                });
            }
            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllCategory(finalPageNumber, finalPageSize);

            return Ok(new ApiResponse<IEnumerable<CategoryResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var serv = await _services.CreateCategory(request);

            return CreatedAtAction(nameof(GetCategory), new { categoryId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Category created successfully."
            });
        }

        [HttpPatch("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryRequest request)
        {
            var serv = await _services.UpdateCategory(categoryId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<CategoryResponse>
                {
                    Success = false, 
                    Message = "Category not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Category updated successfully"
            });
        }
    }
}
