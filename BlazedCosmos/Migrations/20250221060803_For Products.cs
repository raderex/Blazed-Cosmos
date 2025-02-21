using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazedCosmos.Migrations
{
    public partial class ForProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A stunning galaxy art print", "/images/1.jpg", "Galaxy Print", 2000m },
                    { 2, "A vibrant nebula art print", "/images/2.jpg", "Cosmic Nebula", 3000m },
                    { 3, "A mesmerizing starry night print", "/images/3.jpg", "Starry Night", 2500m },
                    { 4, "A dramatic solar flare art print", "/images/4.jpg", "Solar Flare", 2100m },
                    { 5, "A beautiful aurora borealis print", "/images/5.jpg", "Aurora Borealis", 1000m },
                    { 6, "A breathtaking Milky Way art print", "/images/6.jpg", "Milky Way", 1500m },
                    { 7, "A unique planetary orbit print", "/images/7.jpg", "Planetary Orbit", 1800m },
                    { 8, "A mysterious black hole art print", "/images/8.jpg", "Black Hole", 2000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
