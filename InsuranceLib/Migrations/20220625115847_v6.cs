using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceAccount_AspNetUsers_AgentId1",
                        column: x => x.AgentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceAccount_AspNetUsers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceAccount_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    InsuranceTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceSchemeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyTerm = table.Column<int>(type: "int", nullable: false),
                    TotalPremiumAmount = table.Column<double>(type: "float", nullable: false),
                    ProfitRatio = table.Column<int>(type: "int", nullable: false),
                    SumAssured = table.Column<double>(type: "float", nullable: false),
                    AgentCommission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_AgentId1",
                table: "InsuranceAccount",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAccount_CustomerId1",
                table: "InsuranceAccount",
                column: "CustomerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceAccount");

            migrationBuilder.DropTable(
                name: "Policy");
        }
    }
}
