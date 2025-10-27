using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clothing.Models
{
    public class Category
    {
        
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Category Name")]
        [Required, StringLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        // Relationship: One category has many products
        public List<Product> Products { get; set; }
    }
}
