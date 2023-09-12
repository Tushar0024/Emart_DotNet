using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class ConfigDetails
    {
        [Key]
        [Column("config_detailsid")]
        public int Config_DetailsID { get; set; }

        [Required]
        [Column("configid")]
        public int ConfigID { get; set; }

        [Required]
        [Column("config_details")]
        public string? Config_details { get; set; }

        [Required]
        [Column("prodid")]
        public int ProdID { get; set; }

        [ForeignKey("ConfigID")]
        public Config? Config { get; set; }

        [ForeignKey("ProdID")]
        public Product? Product { get; set; }
    }
}
