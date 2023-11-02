using System.ComponentModel.DataAnnotations;

namespace LuxiCart.UI.Models.ViewModels
{
    public class CreateRoleViewModel
    {

        [Required]
        public string? RoleName { get; set; }
    }
}
