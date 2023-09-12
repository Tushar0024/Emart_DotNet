using Emart_final.Models;
using Emart_final.Models.Repository.InvoiceDetailsFolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[EnableCors]
public class InvoiceDetailsController : ControllerBase
{
    private readonly IInvoiceDetailsRepository _repository;

    public InvoiceDetailsController(IInvoiceDetailsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceDetails>>> GetAllInvoiceDetails()
    {
        var invoiceDetails = await _repository.GetAllInvoiceDetails();
        return Ok(invoiceDetails);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceDetails>> GetInvoiceDetailsById(int id)
    {
        var invoiceDetails = await _repository.GetInvoiceDetailsById(id);

        if (invoiceDetails == null)
        {
            return NotFound();
        }

        return Ok(invoiceDetails);
    }

    [HttpPost]
    public async Task<ActionResult<InvoiceDetails>> AddInvoiceDetails(InvoiceDetails invoiceDetails)
    {
        var addedInvoiceDetails = await _repository.AddInvoiceDetails(invoiceDetails);
        return CreatedAtAction(nameof(GetInvoiceDetailsById), new { id = addedInvoiceDetails.InvoiceDtID }, addedInvoiceDetails);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoiceDetails(int id, InvoiceDetails invoiceDetails)
    {
        if (id != invoiceDetails.InvoiceDtID)
        {
            return BadRequest();
        }

        var updatedInvoiceDetails = await _repository.UpdateInvoiceDetails(id, invoiceDetails);

        if (updatedInvoiceDetails == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoiceDetails(int id)
    {
        var invoiceDetailsToDelete = await _repository.DeleteInvoiceDetails(id);

        if (invoiceDetailsToDelete == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("InvoiceID/{invID}/Details")]
    public async Task<ActionResult<IEnumerable<InvoiceDetails>>> GetDetails(int invID)
    {
        var details = await _repository.GetDetails(invID);
        return Ok(details);
    }
}
