using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TemplateAttachmentsFullRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplateId",
                table: "TemplateAttachments");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "TemplateAttachments",
                newName: "TemplatesId");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateAttachments_TemplateId",
                table: "TemplateAttachments",
                newName: "IX_TemplateAttachments_TemplatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplatesId",
                table: "TemplateAttachments",
                column: "TemplatesId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplatesId",
                table: "TemplateAttachments");

            migrationBuilder.RenameColumn(
                name: "TemplatesId",
                table: "TemplateAttachments",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateAttachments_TemplatesId",
                table: "TemplateAttachments",
                newName: "IX_TemplateAttachments_TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplateId",
                table: "TemplateAttachments",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
