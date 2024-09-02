using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrauntApp.Models
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
		
		public List<Item> Items { get; set; }
		public DateTime OrderDate { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public List<OrderItem> OrderItems { get; set; }

	}
}
