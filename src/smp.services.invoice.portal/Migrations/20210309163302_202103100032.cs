using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smp.services.invoice.portal.Migrations
{
    public partial class _202103100032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDate",
                table: "InvoiceOrders",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "InvoiceOrders",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
