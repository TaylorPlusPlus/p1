using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class SaturdayAlso5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Order",
                newName: "UserEntityId1");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserEntityId",
                table: "Order",
                newName: "IX_Order_UserEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityId1",
                table: "Order",
                column: "UserEntityId1",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityId1",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "UserEntityId1",
                table: "Order",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserEntityId1",
                table: "Order",
                newName: "IX_Order_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
