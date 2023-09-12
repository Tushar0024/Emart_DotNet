using Emart_final.Models;
using Emart_final.Models.Repository.Orderfolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                var addedOrder = await _orderRepository.SaveOrder(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = addedOrder.OrderID }, addedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            try
            {
                var updatedOrder = await _orderRepository.UpdateOrder(order, id);

                if (updatedOrder == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderRepository.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
