using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Config
    {
        [Key]
        [Column("config_id")]
        public int ConfigID { get; set; }

        [Required]
        [Column("config_name")]
        public string? ConfigName { get; set; }

        public ICollection<ConfigDetails>? config_details { get; set; }
    }
}
