using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Cart
    {
        [Key]
        [Column("cart_id")]
        public int CartID { get; set; }

        [Required]
        [Column("custid")]
        public int CustID { get; set; }

        [Required]
        [Column("qty")]
        public int Qty { get; set; }

        [Column("prodid")]
        public int ProdID { get; set; }

        [ForeignKey("CustID")]
        public Customer? Customer { get; set; }

        [ForeignKey("ProdID")]
        public Product? Product { get; set; }
    }
}
