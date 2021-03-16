using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smp.services.invoice.portal.Migrations
{
    public partial class _202103101631 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Client",
                table: "InvoiceOrders",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "c_hjje",
                table: "InvoiceOrderResults",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Client",
                table: "InvoiceOrders",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "c_hjje",
                table: "InvoiceOrderResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
