using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
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
                    return NotFound(new
                    {
                        message = "Category not found."
                    });
                }
                return Ok(ser);
            }
            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllCategory(finalPageNumber, finalPageSize);
            return Ok(serv);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var serv = await _services.CreateCategory(request);

            return CreatedAtAction(nameof(GetCategory), new { categoryId = serv }, new
            {
                message = "Category created successfully.",
                categoryId = serv
            });
        }

        [HttpPatch("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryRequest request)
        {
            var serv = await _services.UpdateCategory(categoryId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Category not found"
                });
            }

            return Ok(new
            {
                message = "Category updated successfully"
            });
        }
    }
}
