using System.ComponentModel.DataAnnotations.Schema;

namespace RestrauntApp.Models
{
    public class Item
    {         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

		public List<OrderItem> OrderItems { get; set; }
	}

}
