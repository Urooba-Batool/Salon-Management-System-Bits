using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Services;

namespace SalonSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrdersServices _services;

        public OrderController(OrdersServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int? orderId)
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

            var serv = await _services.GetAllOrders();
            return Ok(serv);
        }


        [HttpGet("future")]
        public async Task<IActionResult> GetFutureOrders()
        {
            var serv = await _services.GetFutureOrders();
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
