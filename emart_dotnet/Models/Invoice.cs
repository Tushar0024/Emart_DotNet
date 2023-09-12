using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Emart_final.Models
{
    public class Invoice
    {
        [Key]
        [Column("invoice_id")]
        public int invoiceID { get; set; }

        [Column("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [Column("total_amt")]
        public double totalAmt { get; set; }

        [Column("tax")]
        public double tax { get; set; }

        [Column("delivery_charges")]
        [DefaultValue(100)] // Set the default value to 100
        public double deliveryCharge { get; set; }

        [Column("total_bill")]
        public double TotalBill { get; set; }

        [Column("custid")]
        public int custID { get; set; }

        [ForeignKey("custID")]
        public Customer? Customer { get; set; }

        public ICollection<InvoiceDetails>? InvoiceDtList { get; set; }
        public ICollection<Order>? Olist { get; set; }

        public Invoice()
        {
            // Set the default value for deliveryCharge in the constructor
            deliveryCharge = 100;
        }
    }
}
