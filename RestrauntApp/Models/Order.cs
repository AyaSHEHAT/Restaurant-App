namespace RestrauntApp.Models
{
	public class Order
	{
		public int Id { get; set; }
		public decimal TotalPrice { get; set; }
		public List<Item> Items { get; set; }
		public DateTime OrderDate { get; set; }

	}
}
