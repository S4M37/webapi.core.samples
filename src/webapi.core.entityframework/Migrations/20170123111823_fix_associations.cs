using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.core.entityframework.Migrations
{
    public partial class fix_associations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Business_BusinessId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_BusinessId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Category",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Business",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Business_CategoryId",
                table: "Business",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Category_CategoryId",
                table: "Business",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_Category_CategoryId",
                table: "Business");

            migrationBuilder.DropIndex(
                name: "IX_Business_CategoryId",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Business");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_BusinessId",
                table: "Category",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Business_BusinessId",
                table: "Category",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
