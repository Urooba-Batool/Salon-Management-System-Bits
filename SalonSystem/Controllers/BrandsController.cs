using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;
using Microsoft.Extensions.Options;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandServices _services;
        private readonly PaginationSettings _paginationSettings;

        public BrandsController(BrandServices services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands(int? brandId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if (brandId.HasValue)
            {
                var ser = await _services.GetBrandsById(brandId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<BrandResponse>
                    {
                        Success = false,
                        Message = "Brand not found."
                    });
                }
                return Ok(new ApiResponse<BrandResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllBrands(finalPageNumber, finalPageSize);

            return Ok(new ApiResponse<IEnumerable<BrandResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateBrands(CreateBrandRequest request)
        {
            var serv = await _services.CreateBrand(request);

            return CreatedAtAction(nameof(GetBrands), new { brandId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Brand created successfully."
                
            });
        }

        [HttpPatch("{brandId}")]
        public async Task<IActionResult> UpdateBrands(int brandId, UpdateBrandRequest request)
        {
            var serv = await _services.UpdateBrand(brandId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<BrandResponse>
                {
                    Success = false,
                    Message = "Brand not found."

                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Brand updated successfully."

            });
        }
    }
}
