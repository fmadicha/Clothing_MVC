using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Key]
        public int ProductId { get; set; }
        [Required, StringLength(150)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Display(Name= "List Price")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,2000)]
        public decimal? ListPrice { get; set; }
        [Display(Name = " Price  for 1-50")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 2000)]
        public decimal Price { get; set; }
        [Display(Name = " Price for 50+")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 2000)]
        public decimal? Price50 { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

        // Foreign Key to Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }

        // Stock quantity
        public int Stock { get; set; }

        // Size and color
        public string? Size { get; set; }
        public string? Color { get; set; }
    }
}
