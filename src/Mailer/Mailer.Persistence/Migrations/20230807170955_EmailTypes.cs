using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmailTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "EmailTypes",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmailTypes",
                newName: "TypeName");
        }
    }
}
