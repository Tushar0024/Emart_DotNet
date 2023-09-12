using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Category
    {
        [Key]
        [Column("catmaster_id")]
        public int catmasterID { get; set; }

        [Column("category_name")]
        public string? categoryName { get; set; }

        [Column("childflag")]
        public bool childflag { get; set; }

        [Column("parent_catid")]
        public int parentCatID { get; set; }

        [Column("cat_img_path")]
        public string? catImgPath { get; set; }

        public ICollection<Product>? Product { get; set; }
    }
}
