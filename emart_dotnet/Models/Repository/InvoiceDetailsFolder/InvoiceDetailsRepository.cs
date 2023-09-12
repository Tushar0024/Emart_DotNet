using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.InvoiceDetailsFolder
{
    public class Invoice_detailsRepository : IInvoiceDetailsRepository
    {
        private readonly AppDbContext context;

        public Invoice_detailsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<InvoiceDetails> AddInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            context.Invoice_Details.Add(invoiceDetails);
            await context.SaveChangesAsync();
            return invoiceDetails;
        }

        public async Task<InvoiceDetails?> DeleteInvoiceDetails(int invoiceDetailsId)
        {
            InvoiceDetails invoiceDetails = await context.Invoice_Details.FindAsync(invoiceDetailsId);
            if (invoiceDetails != null)
            {
                context.Invoice_Details.Remove(invoiceDetails);
                await context.SaveChangesAsync();
            }
            return invoiceDetails;
        }

        public async Task<IEnumerable<InvoiceDetails>> GetAllInvoiceDetails()
        {
            var invoiceDetails = await context.Invoice_Details.ToListAsync();
            return invoiceDetails;
        }

        public async Task<InvoiceDetails> GetInvoiceDetailsById(int invoiceDetailsId)
        {
            var invoiceDetails = await context.Invoice_Details.FindAsync(invoiceDetailsId);
            return invoiceDetails;
        }

        public async Task<InvoiceDetails?> UpdateInvoiceDetails(int invoiceDetailsId, InvoiceDetails updatedInvoiceDetails)
        {
            var existingInvoiceDetails = await context.Invoice_Details.FindAsync(invoiceDetailsId);

            if (existingInvoiceDetails != null)
            {
                // Update fields with values from updatedInvoiceDetails
                existingInvoiceDetails.mrp = updatedInvoiceDetails.mrp;
                existingInvoiceDetails.CardHolderPrice = updatedInvoiceDetails.CardHolderPrice;
                existingInvoiceDetails.PointsRedeem = updatedInvoiceDetails.PointsRedeem;
                existingInvoiceDetails.invoiceID = updatedInvoiceDetails.invoiceID;
                existingInvoiceDetails.ProdID = updatedInvoiceDetails.ProdID;

                await context.SaveChangesAsync();
                return existingInvoiceDetails;
            }

            return null;
        }

        public async Task<IEnumerable<InvoiceDetails>> GetDetails(int invoiceID)
        {
            var invoiceDetails = await context.Invoice_Details
                .Where(i => i.invoiceID == invoiceID)
                .ToListAsync();

            return invoiceDetails;
        }
    }
}
