namespace RestrauntApp.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
