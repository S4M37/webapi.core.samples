using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.core.entityframework.Migrations
{
    public partial class fix_timefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTimestamp",
                table: "Category",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Category",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedTimestamp",
                table: "Business",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Business",  
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Category",
                newName: "UpdatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Category",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Business",
                newName: "UpdatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Business",
                newName: "Timestamp");
        }
    }
}
