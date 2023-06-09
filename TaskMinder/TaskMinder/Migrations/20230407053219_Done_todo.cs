using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMinder.Migrations
{
    /// <inheritdoc />
    public partial class Donetodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "COMPLETEDDATE",
                table: "TODOITEM",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DONE",
                table: "TODOITEM",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COMPLETEDDATE",
                table: "TODOITEM");

            migrationBuilder.DropColumn(
                name: "DONE",
                table: "TODOITEM");
        }
    }
}
