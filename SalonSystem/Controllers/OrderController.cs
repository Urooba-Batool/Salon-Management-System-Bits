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
    public class OrderController : ControllerBase
    {
        private readonly OrdersServices _services;
        private readonly PaginationSettings _paginationSettings;

        public OrderController(OrdersServices services, IOptions<PaginationSettings> paginationOptions)
        {
            _services = services;
            _paginationSettings = paginationOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int? orderId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            if (orderId.HasValue)
            {
                var ser = await _services.GetOrderById(orderId.Value);
                if (ser is null)
                {
                    return NotFound(new ApiResponse<OrderResponse>
                    {
                        Success = false,
                        Message = "Order not found."
                    });
                }
                return Ok(new ApiResponse<OrderResponse>
                {
                    Success = true,
                    Data = ser
                });
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllOrders(finalPageNumber, finalPageSize);

            return Ok(new ApiResponse<IEnumerable<OrderResponse>>
            {
                Success = true,
                Data = serv
            });
        }


        [HttpGet("future")]
        public async Task<IActionResult> GetFutureOrders([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;
            
            var serv = await _services.GetFutureOrders(finalPageNumber, finalPageSize);
            return Ok(new ApiResponse<IEnumerable<OrderResponse>>
            {
                Success = true,
                Data = serv
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var serv = await _services.CreateOrder(request);

            return CreatedAtAction(nameof(GetOrders), new { orderId = serv }, new ApiResponse<int>
            {
                Success = true,
                Data = serv,
                Message = "Order created successfully"
            });
        }

        [HttpPatch("{orderId}")]
        public async Task<IActionResult> UpdateOrder( int orderId, UpdateOrderRequest request)
        {
            var serv = await _services.UpdateOrders(orderId, request);

            if (!serv)
            {
                return NotFound(new ApiResponse<OrderResponse>
                {
                    Success = false,
                    Message = "Order not found"
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Order updated successfully"
            });
        }
    }
}
