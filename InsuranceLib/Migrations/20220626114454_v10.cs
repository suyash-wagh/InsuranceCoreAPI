using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_AgentId",
                table: "InsuranceAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_CustomerId",
                table: "InsuranceAccount");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_AgentId",
                table: "InsuranceAccount");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_CustomerId",
                table: "InsuranceAccount");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "InsuranceAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "InsuranceAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_AgentId",
                table: "InsuranceAccount",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_CustomerId",
                table: "InsuranceAccount",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_AgentId",
                table: "InsuranceAccount",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_CustomerId",
                table: "InsuranceAccount",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
