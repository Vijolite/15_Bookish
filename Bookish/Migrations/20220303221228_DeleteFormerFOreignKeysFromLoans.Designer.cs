﻿// <auto-generated />
using System;
using Bookish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookish.Migrations
{
    [DbContext(typeof(BookishContext))]
    [Migration("20220303221228_DeleteFormerFOreignKeysFromLoans")]
    partial class DeleteFormerFOreignKeysFromLoans
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorDbModelBookDbModel", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<string>("BooksIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorsId", "BooksIsbn");

                    b.HasIndex("BooksIsbn");

                    b.ToTable("AuthorDbModelBookDbModel");
                });

            modelBuilder.Entity("Bookish.Models.Database.AuthorDbModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("AuthorPhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookDbModel", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Blurb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Isbn");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookish.Models.Database.CopyDbModel", b =>
                {
                    b.Property<int?>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CopyId"), 1L, 1);

                    b.Property<string>("BookDbModelIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CopyId");

                    b.HasIndex("BookDbModelIsbn");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("Bookish.Models.Database.LoanDbModel", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"), 1L, 1);

                    b.Property<int?>("CopyDbModelCopyId")
                        .HasColumnType("int");

                    b.Property<int>("CopyId")
                        .HasColumnType("int");

                    b.Property<bool>("HasReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberDbModelId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanId");

                    b.HasIndex("CopyDbModelCopyId");

                    b.HasIndex("MemberDbModelId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Bookish.Models.Database.MemberDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("AuthorDbModelBookDbModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.AuthorDbModel", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookish.Models.Database.BookDbModel", null)
                        .WithMany()
                        .HasForeignKey("BooksIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookish.Models.Database.CopyDbModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.BookDbModel", null)
                        .WithMany("Copies")
                        .HasForeignKey("BookDbModelIsbn");
                });

            modelBuilder.Entity("Bookish.Models.Database.LoanDbModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.CopyDbModel", null)
                        .WithMany("Loans")
                        .HasForeignKey("CopyDbModelCopyId");

                    b.HasOne("Bookish.Models.Database.MemberDbModel", null)
                        .WithMany("Loans")
                        .HasForeignKey("MemberDbModelId");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookDbModel", b =>
                {
                    b.Navigation("Copies");
                });

            modelBuilder.Entity("Bookish.Models.Database.CopyDbModel", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Bookish.Models.Database.MemberDbModel", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
