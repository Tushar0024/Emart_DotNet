using Emart_final.Models;
using Emart_final.Models.Repository.Cartfolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            var carts = await _repository.GetAllCart();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartById(int id)
        {
            var cart = await _repository.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            var addedCart = await _repository.SaveCart(cart);
            return CreatedAtAction(nameof(GetCartById), new { id = addedCart.CartID }, addedCart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.CartID)
            {
                return BadRequest();
            }

            var updatedCart = await _repository.UpdateCart(cart, id);

            if (updatedCart == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _repository.DeleteCart(id);
            return NoContent();
        }

        [HttpGet("cust/{cid}")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCartsByCustomerId(int cid)
        {
            var carts = await _repository.FindProdByCustID(cid);
            return Ok(carts);
        }

        [HttpPut("{qty}/{Cartid}")]
        public async Task<IActionResult> UpdateCartQuantity(int qty, int Cartid)
        {
            var result = await _repository.UpdateQty(qty, Cartid);

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("Deletecust/{customerId}")]
        public async Task<IActionResult> DeleteCartByCustomerId(int customerId)
        {
            await _repository.DeleteCartByCustomerId(customerId);
            return NoContent();
        }

    }
}
