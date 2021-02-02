using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using shahiRestaurant.Data;
using shahiRestaurant.Models;
using System.Linq;
namespace shahiRestaurant.Controllers{
	[ApiController]
	[Route("[controller]")]
	public class CategoriesController: ControllerBase{

		private readonly RestaurantContext _context;

		public CategoriesController(RestaurantContext context){
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Category>>> GetCategories(){
			return await _context.Categories.ToListAsync(); 
		}

		[HttpGet("{Id}")]
		public Category GetCategory(int Id){
			// return await _context.Categorys.Where(item => item.Id == Id).FirstOrDefault();
			return _context.Categories.Where(item=> item.Id==Id).FirstOrDefault();
		}

		[HttpPost]
		public async Task<ActionResult<Category>> CreateCategory(Category item){
			_context.Categories.Add(item);
			await _context.SaveChangesAsync();
            return item;
		}

        [HttpPut("{id}")]
		public async Task<ActionResult<Category>> UpdateCategory(int id, Category item){
            var Item = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if(item == null){
                return NotFound();
            }
			Item.Name = item.Name;
			await _context.SaveChangesAsync();
            return Item;
		}

        [HttpDelete("{id:int}")]
		public async Task<ActionResult<Category>> DeleteCategory(int id){
            var Item = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if(Item == null){
                return NotFound();
            }
			_context.Categories.Remove(Item);
            await _context.SaveChangesAsync();
            return NoContent();
		}
	}
}
