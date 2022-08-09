﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onBoard.Data;

#nullable disable

namespace onBoard.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220809064621_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HourUser", b =>
                {
                    b.Property<int>("HoursHourID")
                        .HasColumnType("int");

                    b.Property<string>("UsersName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HoursHourID", "UsersName");

                    b.HasIndex("UsersName");

                    b.ToTable("HourUser");
                });

            modelBuilder.Entity("onBoard.Models.Hour", b =>
                {
                    b.Property<int>("HourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HourID"), 1L, 1);

                    b.Property<DateTime>("HourPressed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HourID");

                    b.ToTable("Date", (string)null);
                });

            modelBuilder.Entity("onBoard.Models.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("HourUser", b =>
                {
                    b.HasOne("onBoard.Models.Hour", null)
                        .WithMany()
                        .HasForeignKey("HoursHourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("onBoard.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}