using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class SaturdayAlso2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AToppingModel",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AToppingModel", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_AToppingModel_APizzaModel_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "APizzaModel",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AToppingModel_APizzaModelEntityId",
                table: "AToppingModel",
                column: "APizzaModelEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AToppingModel");
        }
    }
}
