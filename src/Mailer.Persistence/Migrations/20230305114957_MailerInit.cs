using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mailer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MailerInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    MediaType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Inline = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTypes", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    CultureName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.CultureName);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "character varying(30)", nullable: false),
                    LanguageCultureName = table.Column<string>(type: "character varying(30)", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    BodyEncoded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Templates_EmailTypes_TypeName",
                        column: x => x.TypeName,
                        principalTable: "EmailTypes",
                        principalColumn: "TypeName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Templates_Languages_LanguageCultureName",
                        column: x => x.LanguageCultureName,
                        principalTable: "Languages",
                        principalColumn: "CultureName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentTemplate",
                columns: table => new
                {
                    AttachmentsId = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTemplate", x => new { x.AttachmentsId, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_AttachmentTemplate_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentTemplate_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_Guid",
                table: "Attachments",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentTemplate_TemplateId",
                table: "AttachmentTemplate",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_Guid",
                table: "Templates",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_LanguageCultureName",
                table: "Templates",
                column: "LanguageCultureName");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TypeName",
                table: "Templates",
                column: "TypeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentTemplate");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "EmailTypes");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
