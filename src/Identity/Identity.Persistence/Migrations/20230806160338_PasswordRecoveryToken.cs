using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PasswordRecoveryToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRecoveryPasswordTokens");

            migrationBuilder.CreateTable(
                name: "PasswordRecoveryTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ValidAfter = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidBefore = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRecoveryTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_PasswordRecoveryTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordRecoveryTokens_UserId",
                table: "PasswordRecoveryTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordRecoveryTokens");

            migrationBuilder.CreateTable(
                name: "UserRecoveryPasswordTokens",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ValidAfter = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidBefore = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecoveryPasswordTokens", x => x.Guid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecoveryPasswordTokens_Token",
                table: "UserRecoveryPasswordTokens",
                column: "Token",
                unique: true);
        }
    }
}
