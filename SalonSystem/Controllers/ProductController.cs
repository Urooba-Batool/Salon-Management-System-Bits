using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _services;

        public ProductController(ProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? productId)
        {
            if (productId.HasValue)
            {
                var ser = await _services.GetProductById(productId.Value);
                if (ser is null)
                {
                    return NotFound(new
                    {
                        message = "Product not found."

                    });
                }
                return Ok(ser);
            }

            var serv = await _services.GetAllProducts();
            return Ok(serv);
        }




        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductRequest request)
        {
            var serv = await _services.CreateProduct(request);

            return CreatedAtAction(nameof(GetProducts), new { productId = serv }, new
            {
                message = "Product created successfully.",
                productId = serv
            });
        }


        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductRequest request)
        {
            var serv = await _services.UpdateProducts(productId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "product not found"
                });
            }

            return Ok(new
            {
                message = "Product updated successfully"
            });
        }

        [HttpPatch("{productId}/quantity")]
        public async Task<IActionResult> UpdateProductQuantity(int productId, UpdateProductRequest request)
        {
            var serv = await _services.UpdateProductQuantity(productId, request);

            if (!serv)
            {

                return NotFound(new
                {
                    message = "product not found"
                });
            }

            return Ok(new
            {
                message = "Product quantity updated successfully"
            });
        }
    }

    
}
