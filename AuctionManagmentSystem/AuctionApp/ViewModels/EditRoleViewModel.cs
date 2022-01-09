using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp.ViewModels
{
    public class EditRoleViewModel
    {
        public List<string> Users { get; set; }

        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }

    }
}
