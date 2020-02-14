using Microsoft.EntityFrameworkCore.Migrations;

namespace PANDA.Migrations
{
    public partial class FixedMissingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Users_ReceiptId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_ReceiptId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Package");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Package",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_RecipientId",
                table: "Package",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Users_RecipientId",
                table: "Package",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Users_RecipientId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_RecipientId",
                table: "Package");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Package",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptId",
                table: "Package",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_ReceiptId",
                table: "Package",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Users_ReceiptId",
                table: "Package",
                column: "ReceiptId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
