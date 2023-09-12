using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Product
    {
        [Key]
        [Column("prod_id")]
        public int prodID { get; set; }

        [Column("prod_name")]
        public string? prodName { get; set; }

        [Column("prod_short_desc")]
        public string? prodShortDesc { get; set; }

        [Column("prod_long_desc")]
        public string? prodLongDesc { get; set; }

        [Column("mrp_price")]
        public double mrpPrice { get; set; }

        [Column("offer_price")]
        public double offerPrice { get; set; }

        [Column("card_holder_price")]
        public double cardHolderPrice { get; set; }

        [Column("points_redeem")]
        public int pointsRedeem { get; set; }

        [Column("imgpath")]
        public string? imgPath { get; set; }

        [Column("inventory_quantity")]
        public int inventoryQuantity { get; set; }

        [Column("catmasterid")]
        public int catmasterID { get; set; }

        [ForeignKey("catmasterID")]
        public Category? Category { get; set; }

        public ICollection<ConfigDetails>? configDetailsList { get; set; }

        public ICollection<InvoiceDetails>? invoiceDetailsList { get; set; }

        public ICollection<Cart>? CartList { get; set; }
    }
}
