using System.Collections.Generic;

namespace Restaurants.Models
{
    public class Cuisine
    {
        public Cuisine()
        {
            this.Restaurants = new HashSet<Restaurant>();
        } 

        public string Name { get; set; }
        public bool Spicy { get; set; }
        public int CuisineId { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}