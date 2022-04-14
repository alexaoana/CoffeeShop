using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Infrastructure.Migrations
{
    public partial class SettersForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfProducts",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfProducts",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");
        }
    }
}
