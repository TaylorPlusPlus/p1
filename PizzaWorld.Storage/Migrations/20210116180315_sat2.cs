using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class sat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACrustModel",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACrustModel", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedStoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentOrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Users_Store_SelectedStoreEntityId",
                        column: x => x.SelectedStoreEntityId,
                        principalTable: "Store",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEntityId = table.Column<long>(type: "bigint", nullable: true),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Store",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_ACrustModel_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "ACrustModel",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Order_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Order",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AToppingModel",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AToppingModel", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_AToppingModel_Pizzas_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 2L, "One" },
                    { 3L, "Two" },
                    { 4L, "Three" },
                    { 5L, "Four" },
                    { 6L, "Five" },
                    { 7L, "Six" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityId", "CurrentOrderId", "SelectedStoreEntityId", "Username" },
                values: new object[] { 5L, 0L, null, "First" });

            migrationBuilder.CreateIndex(
                name: "IX_AToppingModel_APizzaModelEntityId",
                table: "AToppingModel",
                column: "APizzaModelEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityId",
                table: "Order",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserEntityId",
                table: "Order",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityId",
                table: "Users",
                column: "SelectedStoreEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AToppingModel");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "ACrustModel");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
