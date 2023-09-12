using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderID { get; set; }

        [Required]
        [Column("shipping_add")]
        public string? ShippingAdd { get; set; }

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("deliverydate")]
        public DateTime? Deliverydate { get; set; }

        [Required]
        [Column("cust_id")]
        public int CustID { get; set; }

        [Required]
        [Column("invoiceid")]
        public int InvoiceID { get; set; }

        [ForeignKey("CustID")]

        public Customer? Customer { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice? Invoice { get; set; }
    }
}
