using System.ComponentModel.DataAnnotations;

namespace RestrauntApp.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Phone is required")]
		[MaxLength(11)]
		public int Phone { get; set; }
		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

	}
}
