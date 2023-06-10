using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserRegistrationTokenRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRegistrationTokens_UserId",
                table: "UserRegistrationTokens");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistrationTokens_UserId",
                table: "UserRegistrationTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRegistrationTokens_UserId",
                table: "UserRegistrationTokens");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistrationTokens_UserId",
                table: "UserRegistrationTokens",
                column: "UserId");
        }
    }
}
