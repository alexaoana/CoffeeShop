using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Infrastructure.Migrations
{
    public partial class ModifyingProductOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoffeeIntensity",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductOrders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "CoffeeIntensity",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductOrders");
        }
    }
}
