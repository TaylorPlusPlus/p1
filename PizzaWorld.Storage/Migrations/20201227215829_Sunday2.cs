using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class Sunday2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crust",
                table: "Pizzas");

            migrationBuilder.AddColumn<long>(
                name: "CrustEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AToppingModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_ACrustModel_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "ACrustModel",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_ACrustModel_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "ACrustModel");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CrustEntityId",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "Crust",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "AToppingModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
