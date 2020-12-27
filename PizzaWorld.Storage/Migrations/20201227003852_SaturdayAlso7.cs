using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class SaturdayAlso7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaModel_Order_OrderEntityId",
                table: "APizzaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AToppingModel_APizzaModel_APizzaModelEntityId",
                table: "AToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APizzaModel",
                table: "APizzaModel");

            migrationBuilder.RenameTable(
                name: "APizzaModel",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_APizzaModel_OrderEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_OrderEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AToppingModel_Pizzas_APizzaModelEntityId",
                table: "AToppingModel",
                column: "APizzaModelEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AToppingModel_Pizzas_APizzaModelEntityId",
                table: "AToppingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "APizzaModel");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "APizzaModel",
                newName: "IX_APizzaModel_OrderEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APizzaModel",
                table: "APizzaModel",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaModel_Order_OrderEntityId",
                table: "APizzaModel",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AToppingModel_APizzaModel_APizzaModelEntityId",
                table: "AToppingModel",
                column: "APizzaModelEntityId",
                principalTable: "APizzaModel",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
