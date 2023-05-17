using JustEatIt.OrderAPI.Models;
using JustEatIt.OrderAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustEatIt.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            var orders = await _orderService.GetAllOrders();
            return orders;
        }
        
        // GET: api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        
        // POST: api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            await _orderService.CreateOrder(order);

            return Ok();
        }

        // PUT: api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            var existingOrder = await _orderService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            
            await _orderService.UpdateOrder(order);
            return Ok();
        }

        // DELETE: api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingOrder = await _orderService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}