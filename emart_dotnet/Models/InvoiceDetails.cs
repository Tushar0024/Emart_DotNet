using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class InvoiceDetails
    {
        [Key]
        [Column("invoice_dt_id")]
        public int InvoiceDtID { get; set; }

        [Column("mrp")]
        public double mrp { get; set; }

        [Column("card_holder_price")]
        public double CardHolderPrice { get; set; }

        [Column("points_redeem")]
        public int PointsRedeem { get; set; }

        [Column("invoiceid")]
        public int invoiceID { get; set; }

        [Column("prodid")]
        public int ProdID { get; set; }

        [ForeignKey("invoiceID")]
        [Column("invoiceid")]
        public Invoice? Invoice { get; set; }

        [ForeignKey("ProdID")]
        [Column("prodid")]
        public Product? Product { get; set; }

        [Column("prod_name")]
        public string? ProdName { get; set; }
    }
}
