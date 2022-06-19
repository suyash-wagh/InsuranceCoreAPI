using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "InsurancePlans");

            migrationBuilder.DropTable(
                name: "InsuranceSchemes");

            migrationBuilder.DropTable(
                name: "InsuranceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "BaseEntity");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BaseEntity",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "AgeMax",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgeMin",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseEntityId",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseEntityId1",
                table: "BaseEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionNewRegistration",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionPerInstallment",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "BaseEntity",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InsurancePlan_IsActive",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceSchemeId",
                table: "BaseEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceSchemeTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceSchemeTitle1",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceScheme_InsuranceTypeTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InsuranceScheme_IsActive",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceTypeId",
                table: "BaseEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceTypeTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InsuranceType_IsActive",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestmentMax",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestmentMin",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyTermMax",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyTermMin",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitRatio",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "BaseEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State_IsActive",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeTitle",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_BaseEntityId1",
                table: "BaseEntity",
                column: "BaseEntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_InsuranceSchemeId",
                table: "BaseEntity",
                column: "InsuranceSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_InsuranceTypeId",
                table: "BaseEntity",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StateId",
                table: "BaseEntity",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_BaseEntityId1",
                table: "BaseEntity",
                column: "BaseEntityId1",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_InsuranceSchemeId",
                table: "BaseEntity",
                column: "InsuranceSchemeId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_InsuranceTypeId",
                table: "BaseEntity",
                column: "InsuranceTypeId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_StateId",
                table: "BaseEntity",
                column: "StateId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_BaseEntityId1",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_InsuranceSchemeId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_InsuranceTypeId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_StateId",
                table: "BaseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_BaseEntityId1",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_InsuranceSchemeId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_InsuranceTypeId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_StateId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "AgeMax",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "AgeMin",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "BaseEntityId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "BaseEntityId1",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CommissionNewRegistration",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CommissionPerInstallment",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsurancePlan_IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceSchemeId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceSchemeTitle",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceSchemeTitle1",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceScheme_InsuranceTypeTitle",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceScheme_IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeTitle",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InsuranceType_IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InvestmentMax",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "InvestmentMin",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PolicyTermMax",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PolicyTermMin",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProfitRatio",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StateTitle",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "State_IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TypeTitle",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "States");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "States",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceSchemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommissionNewRegistration = table.Column<int>(type: "int", nullable: false),
                    CommissionPerInstallment = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceSchemeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgeMax = table.Column<int>(type: "int", nullable: false),
                    AgeMin = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceSchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceSchemeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentMax = table.Column<int>(type: "int", nullable: false),
                    InvestmentMin = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PolicyTermMax = table.Column<int>(type: "int", nullable: false),
                    PolicyTermMin = table.Column<int>(type: "int", nullable: false),
                    ProfitRatio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePlans_InsuranceSchemes_InsuranceSchemeId",
                        column: x => x.InsuranceSchemeId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurancePlans_InsuranceTypes_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "InsuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_InsuranceSchemeId",
                table: "InsurancePlans",
                column: "InsuranceSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_InsuranceTypeId",
                table: "InsurancePlans",
                column: "InsuranceTypeId");
        }
    }
}
