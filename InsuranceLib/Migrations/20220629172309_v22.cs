using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceLib.DAL.Migrations
{
    public partial class v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceType_Image_TypeImageId",
                table: "InsuranceType");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceType_TypeImageId",
                table: "InsuranceType");

            migrationBuilder.DropColumn(
                name: "TypeImageId",
                table: "InsuranceType");

            migrationBuilder.AddColumn<string>(
                name: "TypeImage",
                table: "InsuranceType",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeImage",
                table: "InsuranceType");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeImageId",
                table: "InsuranceType",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
