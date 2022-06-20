using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookRentageWeb.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be between 1 to 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
