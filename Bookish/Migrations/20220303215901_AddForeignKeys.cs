using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookish.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CopyDbModelCopyId",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberDbModelId",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookDbModelIsbn",
                table: "Copies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CopyDbModelCopyId",
                table: "Loans",
                column: "CopyDbModelCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberDbModelId",
                table: "Loans",
                column: "MemberDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookDbModelIsbn",
                table: "Copies",
                column: "BookDbModelIsbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookDbModelIsbn",
                table: "Copies",
                column: "BookDbModelIsbn",
                principalTable: "Books",
                principalColumn: "Isbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Copies_CopyDbModelCopyId",
                table: "Loans",
                column: "CopyDbModelCopyId",
                principalTable: "Copies",
                principalColumn: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberDbModelId",
                table: "Loans",
                column: "MemberDbModelId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookDbModelIsbn",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Copies_CopyDbModelCopyId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberDbModelId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CopyDbModelCopyId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_MemberDbModelId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Copies_BookDbModelIsbn",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "CopyDbModelCopyId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberDbModelId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BookDbModelIsbn",
                table: "Copies");
        }
    }
}
