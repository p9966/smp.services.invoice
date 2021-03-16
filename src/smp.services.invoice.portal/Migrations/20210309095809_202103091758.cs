using Microsoft.EntityFrameworkCore.Migrations;

namespace smp.services.invoice.portal.Migrations
{
    public partial class _202103091758 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "InvoiceOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Taxrate",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Spbm",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hsbz",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Goodsname",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fphxz",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "InvoiceOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Taxrate",
                table: "InvoiceDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Spbm",
                table: "InvoiceDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Hsbz",
                table: "InvoiceDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Goodsname",
                table: "InvoiceDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Fphxz",
                table: "InvoiceDetails",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
