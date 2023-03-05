using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserRegistrationTokens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserRecoveryPasswordTokens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistrationTokens_Token",
                table: "UserRegistrationTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRecoveryPasswordTokens_Token",
                table: "UserRecoveryPasswordTokens",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRegistrationTokens_Token",
                table: "UserRegistrationTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRecoveryPasswordTokens_Token",
                table: "UserRecoveryPasswordTokens");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserRegistrationTokens");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserRecoveryPasswordTokens");
        }
    }
}
