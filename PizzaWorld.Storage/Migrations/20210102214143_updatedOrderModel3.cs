using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class updatedOrderModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "StoreId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "StoreId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 4L,
                column: "StoreId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "UserId",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "EntityId",
                keyValue: 4L,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "UserId",
                value: 0);
        }
    }
}
