using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Invoicefolder
{
    public interface IInvoiceRepository
    {
        Task<Invoice> AddInvoice(Invoice invoice);

        Task<Invoice?> DeleteInvoice(int invoiceId);

        Task<IEnumerable<Invoice>> GetAllInvoices();

        Task<Invoice?> GetInvoiceById(int invoiceId);

        Task<Invoice?> UpdateInvoice(int invoiceId, Invoice updatedInvoice);
    }
}
