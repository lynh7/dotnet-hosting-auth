﻿// <auto-generated />
using System;
using Host.DB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Host.DB.MySQL.Migrations
{
    [DbContext(typeof(HostContext))]
    [Migration("20240803111534_InitMigrations")]
    partial class InitMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Host.DB.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("BookCategoryId")
                        .HasColumnType("char(36)")
                        .HasColumnName("bookcategoryid");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("bookname");

                    b.Property<string>("BorrowFee")
                        .HasColumnType("longtext")
                        .HasColumnName("borrowfee");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsDeactivate")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeactivate");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeleted");

                    b.Property<bool>("IsHardcoded")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ishardcoded");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modifiedon");

                    b.HasKey("Id");

                    b.HasIndex("BookCategoryId");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("Host.DB.Entities.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("categoryname");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsDeactivate")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeactivate");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeleted");

                    b.Property<bool>("IsHardcoded")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ishardcoded");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modifiedon");

                    b.HasKey("Id");

                    b.ToTable("bookcategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6007d295-0d25-4c4b-8935-f440b326cc3e"),
                            CategoryName = "Art & Music ",
                            CreatedOn = new DateTime(2024, 8, 3, 18, 15, 34, 256, DateTimeKind.Local).AddTicks(2534),
                            IsDeactivate = false,
                            IsDeleted = false,
                            IsHardcoded = false,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Host.DB.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("CellNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("cellnumber");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdon");

                    b.Property<bool>("IsDeactivate")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeactivate");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isdeleted");

                    b.Property<bool>("IsHardcoded")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ishardcoded");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modifiedon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Host.DB.Entities.Book", b =>
                {
                    b.HasOne("Host.DB.Entities.BookCategory", "Category")
                        .WithMany("Books")
                        .HasForeignKey("BookCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Host.DB.Entities.BookCategory", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
