using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        // Foreign Key to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Stock quantity
        public int Stock { get; set; }

        // Size and color
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
