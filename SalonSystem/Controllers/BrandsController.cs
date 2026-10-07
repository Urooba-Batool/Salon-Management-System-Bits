using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandServices _services;

        public BrandsController(BrandServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands(int? brandId)
        {
            if (brandId.HasValue)
            {
                var ser = await _services.GetBrandsById(brandId.Value);
                if (ser is null)
                {
                    return NotFound(new
                    {
                        message = "Brand not found."
                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllBrands();
            return Ok(serv);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBrands(CreateBrandRequest request)
        {
            var serv = await _services.CreateBrand(request);

            return CreatedAtAction(nameof(GetBrands), new { brandId = serv }, new
            {
                message = "Brand created successfully.",
                categoryId = serv
            });
        }

        [HttpPatch("{brandId}")]
        public async Task<IActionResult> UpdateBrands(int brandId, UpdateBrandRequest request)
        {
            var serv = await _services.UpdateBrand(brandId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "Brand not found"
                });
            }

            return Ok(new
            {
                message = "Brand updated successfully"
            });
        }
    }
}
