using Microsoft.EntityFrameworkCore;
using shahiRestaurant.Models;
namespace shahiRestaurant.Data{
	public class RestaurantContext: DbContext{
		public RestaurantContext(DbContextOptions<RestaurantContext> options) :base(options){

		}
		
		public DbSet<FoodItem> FoodItems{get;set;}
	}
}
