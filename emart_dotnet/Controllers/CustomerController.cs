using Emart_final.Models;
using Emart_final.Models.Repository.Customerfolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _repository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _repository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("byEmail/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            var customer = await _repository.GetCustomerByEmail(email);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("prime")]
        public async Task<ActionResult<List<Customer>>> GetPrimeCustomers()
        {
            var primeCustomers = await _repository.GetPrimeCustomers();
            return Ok(primeCustomers);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            var addedCustomer = await _repository.SaveCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = addedCustomer.custId }, addedCustomer);
        }

        [HttpPut("{Customerid}")]
        public async Task<IActionResult> EditCustomer(int id, Customer customer)
        {
            var updatedCustomer = await _repository.Update(customer, id);

            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{Customerid}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _repository.DeleteCustomer(id);
            return NoContent();
        }

        [HttpPost("check")]
        public async Task<IActionResult> CheckCustomer(Auth auth)
        {
            var result = await _repository.CheckCust(auth.custEmail, auth.custPassword);
            return Ok(result);
        }

        [HttpGet("isCardHolder/{cid}")]
        public async Task<ActionResult<bool>> CheckCardHolder(int cid)
        {
            var isCardHolder = await _repository.CheckCardHolder(cid);
            return Ok(isCardHolder);
        }

        [HttpGet("points/{cid}")]
        public async Task<ActionResult<int>> GetPointsByID(int cid)
        {
            var points = await _repository.GetPointsByID(cid);
            return Ok(points);
        }
    }
}
