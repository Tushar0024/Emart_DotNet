using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Customer
    {
        [Key]
        [Column("cust_id")]
        public int custId { get; set; }

        [Column("cust_name")]
        public string? custName { get; set; }

        [Column("cust_address")]
        public string? custAddress { get; set; }

        [Column("cust_phone")]
        public string? custPhone { get; set; }

        [Column("cust_email")]
        public string? custEmail { get; set; }

        [Column("cust_password")]
        public string? custPassword { get; set; }

        [Column("card_holder")]
        public bool cardHolder { get; set; }

        [Column("points")]
        public int points { get; set; }

        public ICollection<Invoice>? invoiceList { get; set; }
        public ICollection<Order>? orderList { get; set; }
        public ICollection<Cart>? cartList { get; set; }
    }
}
