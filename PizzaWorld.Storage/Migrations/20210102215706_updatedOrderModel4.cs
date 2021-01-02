﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storage.Migrations
{
    public partial class updatedOrderModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Store_StoreEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "UserEntityId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                name: "FK_Order_Store_StoreEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "UserEntityId",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityId",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Store_StoreEntityId",
                table: "Order",
                column: "StoreEntityId",
                principalTable: "Store",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityId",
                table: "Order",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
