using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TemplatesWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Attachments_AttachmentsId",
                table: "TemplateAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments");

            migrationBuilder.DropIndex(
                name: "IX_TemplateAttachments_TemplatesId",
                table: "TemplateAttachments");

            migrationBuilder.RenameColumn(
                name: "AttachmentsId",
                table: "TemplateAttachments",
                newName: "_attachmentsId");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Attachments",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments",
                columns: new[] { "TemplatesId", "_attachmentsId" });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAttachments__attachmentsId",
                table: "TemplateAttachments",
                column: "_attachmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Attachments__attachmentsId",
                table: "TemplateAttachments",
                column: "_attachmentsId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Attachments__attachmentsId",
                table: "TemplateAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments");

            migrationBuilder.DropIndex(
                name: "IX_TemplateAttachments__attachmentsId",
                table: "TemplateAttachments");

            migrationBuilder.RenameColumn(
                name: "_attachmentsId",
                table: "TemplateAttachments",
                newName: "AttachmentsId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attachments",
                newName: "Path");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments",
                columns: new[] { "AttachmentsId", "TemplatesId" });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateAttachments_TemplatesId",
                table: "TemplateAttachments",
                column: "TemplatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Attachments_AttachmentsId",
                table: "TemplateAttachments",
                column: "AttachmentsId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
