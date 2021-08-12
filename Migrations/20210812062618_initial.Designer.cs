﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _49_1.Models;

namespace _49_1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210812062618_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("_49_1.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 8, 12, 12, 26, 18, 263, DateTimeKind.Local).AddTicks(9050));

                    b.Property<DateTime?>("DateOfRelease")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("new");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Task");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("Idx_Task_Id");

                    b.HasIndex("UserId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("_49_1.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("Idx_User_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("_49_1.Models.TaskModel", b =>
                {
                    b.HasOne("_49_1.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Users_Tasks")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}