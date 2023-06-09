using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMinder.Migrations
{
    /// <inheritdoc />
    public partial class AddedTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TODOITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    TITLE = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODOITEM", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODOITEM");
        }
    }
}
