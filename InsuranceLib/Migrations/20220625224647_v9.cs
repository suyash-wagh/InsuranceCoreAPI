using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policy_InsuranceAccount_AccountId",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_Policy_AccountId",
                table: "Policy");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Policy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Policy",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_AccountId",
                table: "Policy",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policy_InsuranceAccount_AccountId",
                table: "Policy",
                column: "AccountId",
                principalTable: "InsuranceAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
