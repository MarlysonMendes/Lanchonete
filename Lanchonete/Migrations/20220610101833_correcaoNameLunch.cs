using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanchonete.Migrations
{
    public partial class correcaoNameLunch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LouchName",
                table: "Lunches",
                newName: "LuchName");

            migrationBuilder.RenameColumn(
                name: "LouchId",
                table: "Lunches",
                newName: "LuchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LuchName",
                table: "Lunches",
                newName: "LouchName");

            migrationBuilder.RenameColumn(
                name: "LuchId",
                table: "Lunches",
                newName: "LouchId");
        }
    }
}
