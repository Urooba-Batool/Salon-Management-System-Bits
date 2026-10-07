using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public CategoryController(CategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int? categoryId)
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

            var serv = await _services.GetAllCategory();
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
