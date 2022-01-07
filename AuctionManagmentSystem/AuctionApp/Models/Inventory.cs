using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models
{
    public class Inventory : IValidatableObject
    {
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        [Display(Name = "Product Name")]
        public string InventoryName{ get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Decade is required")]
        [Display (Name = "Decade Made")]
        public string DecadeMade { get; set; }

        [Required(ErrorMessage = "Price must be entered")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Price must be entered")]
        [Display (Name = "Selling Price")]
        public decimal Price { get; set; }

        public string Image { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime AddedOn { get; set; }

        public Inventory()
        {
            AddedOn = DateTime.Now;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Price < Cost)
            {
                yield return new ValidationResult("Selling Price cannot be less than he cost");
            }
        }

    }
}
