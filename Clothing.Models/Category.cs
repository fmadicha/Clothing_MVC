using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clothing.Models
{
    public class Category
    {
        [Key]
        public int Id{ get; set; }
        [Required]// string willhave a not null section coz of required.
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string ?Name{ get; set; }

        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder{ get; set; }
    }
}
