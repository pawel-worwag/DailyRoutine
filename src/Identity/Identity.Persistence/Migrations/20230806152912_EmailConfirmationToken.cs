using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmailConfirmationToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRegistrationTokens",
                table: "UserRegistrationTokens");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "UserRegistrationTokens");

            migrationBuilder.DropColumn(
                name: "ValidAfter",
                table: "UserRegistrationTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistrationTokens",
                table: "UserRegistrationTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistrationTokens_Users_UserId",
                table: "UserRegistrationTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistrationTokens_Users_UserId",
                table: "UserRegistrationTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRegistrationTokens",
                table: "UserRegistrationTokens");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "UserRegistrationTokens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidAfter",
                table: "UserRegistrationTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistrationTokens",
                table: "UserRegistrationTokens",
                column: "Guid");
        }
    }
}
