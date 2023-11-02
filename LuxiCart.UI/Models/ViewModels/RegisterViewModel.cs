using System.ComponentModel.DataAnnotations;

namespace LuxiCart.UI.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Please Enter Your First Name and Last Name")]
		[MaxLength(30)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
		[MaxLength(40, ErrorMessage = "Max 40 char")]
		[EmailAddress(ErrorMessage = "example:  user@gmail.com")]
		public string? Email { get; set; }


		[Required(ErrorMessage = "Please Enter Password")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }


		[Required(ErrorMessage = "Please Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Miss Match")]
		public string? ConfirmPassword { get; set; }
		[Required(ErrorMessage ="Please enter your Phone Number")]
		[DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }


    }
}
