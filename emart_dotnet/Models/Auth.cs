using System.ComponentModel.DataAnnotations;

namespace Emart_final.Models
{
    public class Auth
    {
        [Key]
        public int AuthId { get; set; }

        [Required]
        public string? custEmail { get; set; }

        [Required]
        public string? custPassword { get; set; }
    }
}
