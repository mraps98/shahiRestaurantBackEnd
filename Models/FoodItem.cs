namespace shahiRestaurant.Models{
	public class FoodItem{
		public int Id{get;set;}
		public string Name{get;set;}
		public FoodItemCategory Category{get;set;}
		public double Price{get;set;}
		public int SpiceLevel{get;set;}
		public bool IsVegetarian{get;set;}
	}
}
