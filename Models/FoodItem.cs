namespace shahiRestaurant.Models{
	public class FoodItem{
		public int Id{get;set;}
		public string Name{get;set;}
		public int CategoryId{get;set;}
		public double Price{get;set;}
		public int SpiceLevel{get;set;}
		public bool IsVegetarian{get;set;}
	}
}
