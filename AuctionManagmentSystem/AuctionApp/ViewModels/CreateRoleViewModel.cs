using System.ComponentModel.DataAnnotations;

namespace AuctionApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
