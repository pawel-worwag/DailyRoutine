using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TemplateAttachmentsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTemplate_Attachments_AttachmentsId",
                table: "AttachmentTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentTemplate_Templates_TemplateId",
                table: "AttachmentTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentTemplate",
                table: "AttachmentTemplate");

            migrationBuilder.RenameTable(
                name: "AttachmentTemplate",
                newName: "TemplateAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentTemplate_TemplateId",
                table: "TemplateAttachments",
                newName: "IX_TemplateAttachments_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments",
                columns: new[] { "AttachmentsId", "TemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Attachments_AttachmentsId",
                table: "TemplateAttachments",
                column: "AttachmentsId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplateId",
                table: "TemplateAttachments",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Attachments_AttachmentsId",
                table: "TemplateAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateAttachments_Templates_TemplateId",
                table: "TemplateAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateAttachments",
                table: "TemplateAttachments");

            migrationBuilder.RenameTable(
                name: "TemplateAttachments",
                newName: "AttachmentTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateAttachments_TemplateId",
                table: "AttachmentTemplate",
                newName: "IX_AttachmentTemplate_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentTemplate",
                table: "AttachmentTemplate",
                columns: new[] { "AttachmentsId", "TemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTemplate_Attachments_AttachmentsId",
                table: "AttachmentTemplate",
                column: "AttachmentsId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentTemplate_Templates_TemplateId",
                table: "AttachmentTemplate",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
