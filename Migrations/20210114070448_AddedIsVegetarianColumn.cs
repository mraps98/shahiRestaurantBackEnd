using Microsoft.EntityFrameworkCore.Migrations;

namespace shahiRestaurant.Migrations
{
    public partial class AddedIsVegetarianColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVegetarian",
                table: "FoodItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVegetarian",
                table: "FoodItems");
        }
    }
}
