﻿// <auto-generated />
using System;
using DailyRoutine.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DailyRoutine.Persistence.Migrations
{
    [DbContext(typeof(DailyRoutineDbContext))]
    partial class DailyRutineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DailyRutine.Domain.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Owner")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.ToTable("Calendars", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.DecimalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("DecimalEntries", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.NutritionEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Carbohydrate")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Energy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<decimal?>("Fat")
                        .HasColumnType("numeric");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Protein")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Salt")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("SaturatedFat")
                        .HasColumnType("numeric");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Sugar")
                        .HasColumnType("numeric");

                    b.Property<int>("Unit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(2);

                    b.Property<decimal>("Weight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("NutrionEntries", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.TextEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("TextEntries", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.ToDoEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Done")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("ToDoEntries", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalendarId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.DecimalEntry", b =>
                {
                    b.HasOne("DailyRutine.Domain.Entities.Calendar", "Calendar")
                        .WithMany("DecimalEntries")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyRutine.Domain.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.NutritionEntry", b =>
                {
                    b.HasOne("DailyRutine.Domain.Entities.Calendar", "Calendar")
                        .WithMany("NutritionEntries")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyRutine.Domain.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.TextEntry", b =>
                {
                    b.HasOne("DailyRutine.Domain.Entities.Calendar", "Calendar")
                        .WithMany("TextEntries")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyRutine.Domain.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Entries.ToDoEntry", b =>
                {
                    b.HasOne("DailyRutine.Domain.Entities.Calendar", "Calendar")
                        .WithMany("ToDoEntries")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DailyRutine.Domain.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Section", b =>
                {
                    b.HasOne("DailyRutine.Domain.Entities.Calendar", "Calendar")
                        .WithMany("Sections")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("DailyRutine.Domain.Entities.Calendar", b =>
                {
                    b.Navigation("DecimalEntries");

                    b.Navigation("NutritionEntries");

                    b.Navigation("Sections");

                    b.Navigation("TextEntries");

                    b.Navigation("ToDoEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
