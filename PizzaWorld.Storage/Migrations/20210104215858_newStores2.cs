using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class newStores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 5L, "Four" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 6L, "Five" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 7L, "Six" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 7L);
        }
    }
}
