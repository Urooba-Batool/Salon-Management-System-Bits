using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalonSystem.Models.Configurations;
using SalonSystem.Models.DTOs.RequestModels;
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
                    return NotFound(new
                    {
                        message = "Order not found."
                    });
                }
                return Ok(ser);
            }

            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;

            var serv = await _services.GetAllOrders(finalPageNumber, finalPageSize);
            return Ok(serv);
        }


        [HttpGet("future")]
        public async Task<IActionResult> GetFutureOrders([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            int finalPageNumber = pageNumber ?? _paginationSettings.DefaultPageNumber;
            int finalPageSize = pageSize ?? _paginationSettings.DefaultPageSize;
            
            var serv = await _services.GetFutureOrders(finalPageNumber, finalPageSize);
            return Ok(serv);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var serv = await _services.CreateOrder(request);

            return CreatedAtAction(nameof(GetOrders), new { orderId = serv }, new
            {
                message = "order created successfully.",
                orderId = serv
            });
        }

        [HttpPatch("{orderId}")]
        public async Task<IActionResult> UpdateOrder( int orderId, UpdateOrderRequest request)
        {
            var serv = await _services.UpdateOrders(orderId, request);

            if (!serv)
            {
                return NotFound(new
                {
                    message = "order not found"
                });
            }

            return Ok(new
            {
                message = "order updated successfully"
            });
        }
    }
}
