using Emart_final.Models;
using Emart_final.Models.Repository.Productfolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var addedProduct = await _repository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.prodID }, addedProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.prodID)
            {
                return BadRequest();
            }

            var updatedProduct = await _repository.UpdateProduct(id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productToDelete = await _repository.DeleteProduct(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ByPriceRange")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(double minPrice, double maxPrice)
        {
            var products = await _repository.GetProductsByPriceRange(minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("WithValidDiscount")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithValidDiscount()
        {
            var products = await _repository.GetProductsWithValidDiscount();
            return Ok(products);
        }

        [HttpGet("ByCategory/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int id)
        {
            var products = await _repository.FindByCatID(id);
            return Ok(products);
        }
    }
}
