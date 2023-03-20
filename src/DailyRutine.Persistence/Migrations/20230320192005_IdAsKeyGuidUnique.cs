using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DailyRutine.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdAsKeyGuidUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecimalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecimalEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecimalEntries_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecimalEntries_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrionEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Unit = table.Column<int>(type: "integer", nullable: false, defaultValue: 2),
                    Energy = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Fat = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "numeric", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "numeric", nullable: true),
                    Sugar = table.Column<decimal>(type: "numeric", nullable: true),
                    Protein = table.Column<decimal>(type: "numeric", nullable: true),
                    Salt = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrionEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrionEntries_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutrionEntries_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextEntries_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextEntries_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Done = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoEntries_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoEntries_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_Guid",
                table: "Calendars",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DecimalEntries_CalendarId",
                table: "DecimalEntries",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_DecimalEntries_Guid",
                table: "DecimalEntries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DecimalEntries_SectionId",
                table: "DecimalEntries",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrionEntries_CalendarId",
                table: "NutrionEntries",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrionEntries_Guid",
                table: "NutrionEntries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutrionEntries_SectionId",
                table: "NutrionEntries",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CalendarId",
                table: "Sections",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Guid",
                table: "Sections",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextEntries_CalendarId",
                table: "TextEntries",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_TextEntries_Guid",
                table: "TextEntries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextEntries_SectionId",
                table: "TextEntries",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_CalendarId",
                table: "ToDoEntries",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_Guid",
                table: "ToDoEntries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_SectionId",
                table: "ToDoEntries",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecimalEntries");

            migrationBuilder.DropTable(
                name: "NutrionEntries");

            migrationBuilder.DropTable(
                name: "TextEntries");

            migrationBuilder.DropTable(
                name: "ToDoEntries");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Calendars");
        }
    }
}
