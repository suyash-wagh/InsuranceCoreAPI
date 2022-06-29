using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_BaseEntity_Id",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Commission_BaseEntity_Id",
                table: "Commission");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_BaseEntity_BaseEntityId1",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_BaseEntity_Id",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAccount_BaseEntity_Id",
                table: "InsuranceAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceClaim_BaseEntity_Id",
                table: "InsuranceClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePlan_BaseEntity_Id",
                table: "InsurancePlan");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceScheme_BaseEntity_Id",
                table: "InsuranceScheme");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceType_BaseEntity_Id",
                table: "InsuranceType");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BaseEntity_Id",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Policy_BaseEntity_Id",
                table: "Policy");

            migrationBuilder.DropForeignKey(
                name: "FK_Query_BaseEntity_Id",
                table: "Query");

            migrationBuilder.DropForeignKey(
                name: "FK_State_BaseEntity_Id",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_WithdrawAccount_BaseEntity_Id",
                table: "WithdrawAccount");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_Image_BaseEntityId1",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "BaseEntityId1",
                table: "Image");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WithdrawAccount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "State",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Query",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Policy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InsuranceType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeImageId",
                table: "InsuranceType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InsuranceScheme",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InsurancePlan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InsuranceClaim",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InsuranceAccount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Commission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceType_TypeImageId",
                table: "InsuranceType",
                column: "TypeImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceType_Image_TypeImageId",
                table: "InsuranceType",
                column: "TypeImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceType_Image_TypeImageId",
                table: "InsuranceType");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceType_TypeImageId",
                table: "InsuranceType");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WithdrawAccount");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "State");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Query");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InsuranceType");

            migrationBuilder.DropColumn(
                name: "TypeImageId",
                table: "InsuranceType");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InsuranceScheme");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InsurancePlan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InsuranceClaim");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InsuranceAccount");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Commission");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "City");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseEntityId1",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_BaseEntityId1",
                table: "Image",
                column: "BaseEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_City_BaseEntity_Id",
                table: "City",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commission_BaseEntity_Id",
                table: "Commission",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_BaseEntity_BaseEntityId1",
                table: "Image",
                column: "BaseEntityId1",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_BaseEntity_Id",
                table: "Image",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAccount_BaseEntity_Id",
                table: "InsuranceAccount",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceClaim_BaseEntity_Id",
                table: "InsuranceClaim",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePlan_BaseEntity_Id",
                table: "InsurancePlan",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceScheme_BaseEntity_Id",
                table: "InsuranceScheme",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceType_BaseEntity_Id",
                table: "InsuranceType",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_BaseEntity_Id",
                table: "Payment",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Policy_BaseEntity_Id",
                table: "Policy",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Query_BaseEntity_Id",
                table: "Query",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_State_BaseEntity_Id",
                table: "State",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WithdrawAccount_BaseEntity_Id",
                table: "WithdrawAccount",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
