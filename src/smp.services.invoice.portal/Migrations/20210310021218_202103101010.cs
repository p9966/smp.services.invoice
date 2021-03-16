using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smp.services.invoice.portal.Migrations
{
    public partial class _202103101010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fpqqlsh",
                table: "InvoiceOrders");

            migrationBuilder.AddColumn<string>(
                name: "SerialNum",
                table: "InvoiceOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceOrderResults",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InvoiceOrderId = table.Column<string>(nullable: true),
                    terminalNumber = table.Column<string>(nullable: true),
                    c_hjje = table.Column<int>(nullable: false),
                    c_address = table.Column<string>(nullable: true),
                    c_telephone = table.Column<string>(nullable: true),
                    c_mail = table.Column<string>(nullable: true),
                    c_yfpdm = table.Column<string>(nullable: true),
                    c_buyername = table.Column<string>(nullable: true),
                    c_payee = table.Column<string>(nullable: true),
                    c_taxnum = table.Column<string>(nullable: true),
                    c_phone = table.Column<string>(nullable: true),
                    c_yfphm = table.Column<string>(nullable: true),
                    c_salerTel = table.Column<string>(nullable: true),
                    c_remark = table.Column<string>(nullable: true),
                    cipherText = table.Column<string>(nullable: true),
                    qrCode = table.Column<string>(nullable: true),
                    c_invoice_line = table.Column<string>(nullable: true),
                    c_resultmsg = table.Column<string>(nullable: true),
                    c_qdbz = table.Column<int>(nullable: false),
                    c_salerAccount = table.Column<string>(nullable: true),
                    c_status = table.Column<string>(nullable: true),
                    c_kprq = table.Column<long>(nullable: false),
                    c_checker = table.Column<string>(nullable: true),
                    c_orderno = table.Column<string>(nullable: true),
                    c_saleName = table.Column<string>(nullable: true),
                    c_salerTaxNum = table.Column<string>(nullable: true),
                    c_imgUrls = table.Column<string>(nullable: true),
                    machineCode = table.Column<string>(nullable: true),
                    c_jpg_url = table.Column<string>(nullable: true),
                    c_invoiceid = table.Column<string>(nullable: true),
                    c_hjse = table.Column<float>(nullable: false),
                    c_clerkId = table.Column<string>(nullable: true),
                    c_qdxmmc = table.Column<string>(nullable: true),
                    c_salerAddress = table.Column<string>(nullable: true),
                    c_deptId = table.Column<string>(nullable: true),
                    c_fphm = table.Column<string>(nullable: true),
                    c_clerk = table.Column<string>(nullable: true),
                    c_url = table.Column<string>(nullable: true),
                    c_fpqqlsh = table.Column<string>(nullable: true),
                    c_fpdm = table.Column<string>(nullable: true),
                    productOilFlag = table.Column<string>(nullable: true),
                    extensionNumber = table.Column<string>(nullable: true),
                    c_bhsje = table.Column<float>(nullable: false),
                    c_msg = table.Column<string>(nullable: true),
                    c_bankAccount = table.Column<string>(nullable: true),
                    c_jym = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceOrderResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceOrderResults");

            migrationBuilder.DropColumn(
                name: "SerialNum",
                table: "InvoiceOrders");

            migrationBuilder.AddColumn<string>(
                name: "Fpqqlsh",
                table: "InvoiceOrders",
                type: "text",
                nullable: true);
        }
    }
}
