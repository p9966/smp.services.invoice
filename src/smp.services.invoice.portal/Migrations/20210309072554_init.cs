using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smp.services.invoice.portal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceOrders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    Taxnum = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    OutOrderNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    SaletaxNum = table.Column<string>(nullable: true),
                    SaleAccount = table.Column<string>(nullable: true),
                    SalePhone = table.Column<string>(nullable: true),
                    SaleAddress = table.Column<string>(nullable: true),
                    KpType = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Clerk = table.Column<string>(nullable: true),
                    Payee = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Fpdm = table.Column<string>(nullable: true),
                    Fphm = table.Column<string>(nullable: true),
                    Tsfs = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Qdbz = table.Column<string>(nullable: true),
                    Qdxmmc = table.Column<string>(nullable: true),
                    Dkbz = table.Column<string>(nullable: true),
                    Deptid = table.Column<string>(nullable: true),
                    Clerkid = table.Column<string>(nullable: true),
                    InvoiceLine = table.Column<string>(nullable: true),
                    Cpybz = table.Column<string>(nullable: true),
                    BillInfoNo = table.Column<string>(nullable: true),
                    CallbackUrl = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Client = table.Column<byte[]>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    StateMessage = table.Column<string>(nullable: true),
                    Fpqqlsh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InvoiceOrderId = table.Column<string>(nullable: true),
                    Goodsname = table.Column<string>(nullable: true),
                    Num = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Hsbz = table.Column<string>(nullable: true),
                    Taxrate = table.Column<string>(nullable: true),
                    Spec = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Spbm = table.Column<string>(nullable: true),
                    Zsbm = table.Column<string>(nullable: true),
                    Fphxz = table.Column<string>(nullable: true),
                    Yhzcbs = table.Column<string>(nullable: true),
                    Zzstsgl = table.Column<string>(nullable: true),
                    Lslbs = table.Column<string>(nullable: true),
                    Kce = table.Column<string>(nullable: true),
                    Taxfreeamt = table.Column<string>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    Taxamt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceOrders_InvoiceOrderId",
                        column: x => x.InvoiceOrderId,
                        principalTable: "InvoiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceOrderId",
                table: "InvoiceDetails",
                column: "InvoiceOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceOrders");
        }
    }
}
