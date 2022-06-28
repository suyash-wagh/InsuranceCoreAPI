using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "WithdrawAccount",
                newName: "AgentId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Commission",
                newName: "CommissionAmount");

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Commission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PolicyId",
                table: "Commission",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Commission");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "WithdrawAccount",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "CommissionAmount",
                table: "Commission",
                newName: "Amount");

            migrationBuilder.AddColumn<double>(
                name: "TransactionAmount",
                table: "Payment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
