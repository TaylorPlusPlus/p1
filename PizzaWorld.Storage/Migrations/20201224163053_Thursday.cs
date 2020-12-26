using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class Thursday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 2L, "One" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 3L, "Two" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 4L, "Three" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Store");
        }
    }
}
