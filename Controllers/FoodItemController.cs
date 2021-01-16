using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using shahiRestaurant.Data;
using shahiRestaurant.Models;
using System.Linq;
namespace shahiRestaurant.Controllers{
	[ApiController]
	[Route("[controller]")]
	public class FoodItemController: ControllerBase{

		private readonly RestaurantContext _context;

		public FoodItemController(RestaurantContext context){
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItem(){
			return await _context.FoodItems.ToListAsync(); 
		}

		[HttpGet("{Id}")]
		public FoodItem GetFoodItem(int Id){
			// return await _context.FoodItems.Where(item => item.Id == Id).FirstOrDefault();
			return _context.FoodItems.Where(item=> item.Id==Id).FirstOrDefault();
		}

		[HttpGet]
		[Route("category/{category}")]
		public IEnumerable<FoodItem> GetFoodItemByCategory(FoodItemCategory category){
			return _context.FoodItems.Where(item=> item.Category == category);
		}

		[HttpPost]
		public async void CreateFoodItem(FoodItem item){
			_context.FoodItems.Add(item);
			await _context.SaveChangesAsync();
		}
	}
}
