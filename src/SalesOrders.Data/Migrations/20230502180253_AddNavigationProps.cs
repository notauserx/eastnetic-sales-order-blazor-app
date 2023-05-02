using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrders.Data.Migrations
{
    public partial class AddNavigationProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Windows",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WindowId",
                table: "SubElements",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements",
                column: "WindowId",
                principalTable: "Windows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Windows",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "WindowId",
                table: "SubElements",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_SubElements_Windows_WindowId",
                table: "SubElements",
                column: "WindowId",
                principalTable: "Windows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
