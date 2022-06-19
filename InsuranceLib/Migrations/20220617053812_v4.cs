using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IsActive",
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
                name: "StateName",
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

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BaseEntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseEntityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_BaseEntity_BaseEntityId1",
                        column: x => x.BaseEntityId1,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceSchemeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionNewRegistration = table.Column<int>(type: "int", nullable: false),
                    CommissionPerInstallment = table.Column<int>(type: "int", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceScheme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceScheme_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceType_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceSchemeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceSchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolicyTermMin = table.Column<int>(type: "int", nullable: false),
                    PolicyTermMax = table.Column<int>(type: "int", nullable: false),
                    AgeMin = table.Column<int>(type: "int", nullable: false),
                    AgeMax = table.Column<int>(type: "int", nullable: false),
                    InvestmentMin = table.Column<int>(type: "int", nullable: false),
                    InvestmentMax = table.Column<int>(type: "int", nullable: false),
                    ProfitRatio = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePlan_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurancePlan_InsuranceScheme_InsuranceSchemeId",
                        column: x => x.InsuranceSchemeId,
                        principalTable: "InsuranceScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurancePlan_InsuranceType_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "InsuranceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BaseEntityId1",
                table: "Image",
                column: "BaseEntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlan_InsuranceSchemeId",
                table: "InsurancePlan",
                column: "InsuranceSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlan_InsuranceTypeId",
                table: "InsurancePlan",
                column: "InsuranceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "InsurancePlan");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "InsuranceScheme");

            migrationBuilder.DropTable(
                name: "InsuranceType");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BaseEntity",
                type: "bit",
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
                name: "StateName",
                table: "BaseEntity",
                type: "nvarchar(max)",
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
    }
}
