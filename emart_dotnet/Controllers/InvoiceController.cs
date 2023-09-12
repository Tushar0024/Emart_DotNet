using Emart_final.Models;
using Emart_final.Models.Repository.Invoicefolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceController(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            var invoices = await _repository.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
        {
            var invoice = await _repository.GetInvoiceById(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            

            var addedInvoice = await _repository.AddInvoice(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = addedInvoice.invoiceID }, addedInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.invoiceID)
            {
                return BadRequest();
            }

            var updatedInvoice = await _repository.UpdateInvoice(id, invoice);

            if (updatedInvoice == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoiceToDelete = await _repository.DeleteInvoice(id);

            if (invoiceToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
