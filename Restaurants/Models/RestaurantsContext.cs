using Microsoft.EntityFrameworkCore;

namespace Restaurants.Models
{
  public class RestaurantsContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisines { get; set; } 
    public DbSet<Restaurant> Restaurants { get; set; }

    public RestaurantsContext(DbContextOptions options) : base(options) { }
  }
}