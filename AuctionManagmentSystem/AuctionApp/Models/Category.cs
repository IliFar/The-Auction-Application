using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

    }
}
