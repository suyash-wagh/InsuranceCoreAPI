using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_AgentId1",
                table: "InsuranceAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_CustomerId1",
                table: "InsuranceAccount");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_AgentId1",
                table: "InsuranceAccount");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_CustomerId1",
                table: "InsuranceAccount");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "InsuranceAccount");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "InsuranceAccount");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Policy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_AccountId",
                table: "Policy",
                column: "AccountId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Policy_InsuranceAccount_AccountId",
                table: "Policy",
                column: "AccountId",
                principalTable: "InsuranceAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_AgentId",
                table: "InsuranceAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_CustomerId",
                table: "InsuranceAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Policy_InsuranceAccount_AccountId",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_Policy_AccountId",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_AgentId",
                table: "InsuranceAccount");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAccount_CustomerId",
                table: "InsuranceAccount");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Policy");

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Policy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "InsuranceAccount",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "InsuranceAccount",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentId1",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "InsuranceAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_AgentId1",
                table: "InsuranceAccount",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_CustomerId1",
                table: "InsuranceAccount",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_AgentId1",
                table: "InsuranceAccount",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAccount_AspNetUsers_CustomerId1",
                table: "InsuranceAccount",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
