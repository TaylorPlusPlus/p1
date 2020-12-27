using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class SaturdayAlso4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Orders_OrderEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Store_StoreEntityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserEntityId",
                table: "Order",
                newName: "IX_Order_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Order",
                newName: "IX_Order_StoreEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Order_OrderEntityId",
                table: "APizzaModel",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Store_StoreEntityId",
                table: "Order",
                column: "StoreEntityId",
                principalTable: "Store",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Order_OrderEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Store_StoreEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserEntityId",
                table: "Orders",
                newName: "IX_Orders_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StoreEntityId",
                table: "Orders",
                newName: "IX_Orders_StoreEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Orders_OrderEntityId",
                table: "APizzaModel",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Store_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId",
                principalTable: "Store",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
