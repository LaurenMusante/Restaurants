namespace Restaurants.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool KidFriendly { get; set; }
        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }
    }
}
