using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceWebSite.Migrations
{
    public partial class AddOrderInvoiceWithRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TbOrderInvoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TbUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderInvoice_UserId",
                table: "TbOrderInvoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbOrderInvoices_TbUsers_UserId",
                table: "TbOrderInvoices",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbOrderInvoices_TbUsers_UserId",
                table: "TbOrderInvoices");

            migrationBuilder.DropIndex(
                name: "IX_TbOrderInvoice_UserId",
                table: "TbOrderInvoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TbOrderInvoices");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TbUsers");
        }
    }
}
