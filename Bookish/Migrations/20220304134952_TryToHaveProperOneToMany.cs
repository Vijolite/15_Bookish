using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookish.Migrations
{
    public partial class TryToHaveProperOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CopyDbModelCopyId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberDbModelId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Copies");

            migrationBuilder.RenameColumn(
                name: "BookDbModelIsbn",
                table: "Copies",
                newName: "BookIsbn");

            migrationBuilder.RenameIndex(
                name: "IX_Copies_BookDbModelIsbn",
                table: "Copies",
                newName: "IX_Copies_BookIsbn");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CopyId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CopyId",
                table: "Loans",
                column: "CopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookIsbn",
                table: "Copies",
                column: "BookIsbn",
                principalTable: "Books",
                principalColumn: "Isbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Copies_CopyId",
                table: "Loans",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberId",
                table: "Loans",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookIsbn",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Copies_CopyId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CopyId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_MemberId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "BookIsbn",
                table: "Copies",
                newName: "BookDbModelIsbn");

            migrationBuilder.RenameIndex(
                name: "IX_Copies_BookIsbn",
                table: "Copies",
                newName: "IX_Copies_BookDbModelIsbn");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CopyId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "Isbn",
                table: "Copies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CopyDbModelCopyId",
                table: "Loans",
                column: "CopyDbModelCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberDbModelId",
                table: "Loans",
                column: "MemberDbModelId");

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
    }
}
