using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _services;
        private readonly PaginationSettings _paginationSettings;

        public ProductController(ProductServices services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? productId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if (productId.HasValue)
            {
                var ser = await _services.GetProductById(productId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<ProductResponse>
                    {
                        Success = false,
                        Message = "Product not found."

                    });
                }
                return Ok(new ApiResponse<ProductResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllProducts(finalPageNumber, finalPageSize);
            return Ok(new ApiResponse<IEnumerable<ProductResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductRequest request)
        {
            var serv = await _services.CreateProduct(request);

            return CreatedAtAction(nameof(GetProducts), new { productId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Product created successfully."
            });
        }


        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductRequest request)
        {
            var serv = await _services.UpdateProducts(productId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<ProductResponse>
                {
                    Success = false,
                    Message = "product not found"
                });
            }

            return Ok(new ApiResponse<bool>{
                    Success = true,
                    Data = true,
                    Message = "Product updated successfully"
            });
        }

        [HttpPatch("{productId}/quantity")]
        public async Task<IActionResult> UpdateProductQuantity(int productId, UpdateProductRequest request)
        {
            var serv = await _services.UpdateProductQuantity(productId, request);

            if (!serv)
            {

                return NotFound(new ApiResponse<ProductResponse>
                {
                    Success = false,
                    Message = "product not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Product quantity updated successfully"
            });
        }
    }

    
}
