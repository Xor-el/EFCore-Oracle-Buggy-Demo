﻿// <auto-generated />
using System;
using LibraryDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryDemo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230113215445_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryDemo.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "J.K. Rowling"
                        },
                        new
                        {
                            Id = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                            DateOfBirth = new DateTime(1952, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Walter Isaacson"
                        });
                });

            modelBuilder.Entity("LibraryDemo.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Metadata")
                        .HasColumnType("CLOB")
                        .HasColumnName("Metadata");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                            AuthorId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            Metadata = "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Harry Potter\\u0027s life is miserable. His parents are dead and he\\u0027s stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.\",\r\n  \"genre\": \"Fantasy\",\r\n  \"publisher\": \"Scholastic; 1st Scholastic Td Ppbk Print., Sept.1999 edition (September 1, 1998)\",\r\n  \"isbn\": \"978-0439708180\",\r\n  \"rating\": 5,\r\n  \"publisherReleaseDate\": \"1998-09-01T00:00:00\"\r\n}",
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            Id = new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                            AuthorId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            Metadata = "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. \",\r\n  \"publisher\": \"Scholastic Paperbacks; Reprint edition (September 1, 2000)\",\r\n  \"isbn\": \"978-0439064873\",\r\n  \"rating\": 5,\r\n  \"publisherReleaseDate\": \"2000-09-01T00:00:00\"\r\n}",
                            Title = "Harry Potter and the Chamber of Secrets"
                        },
                        new
                        {
                            Id = new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                            AuthorId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                            Metadata = "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Walter Isaacson\\u2019s \\u201Centhralling\\u201D (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs.\",\r\n  \"genre\": \"Biography\",\r\n  \"publisher\": \"Simon \\u0026 Schuster; 1st edition (October 24, 2011)\",\r\n  \"isbn\": \"978-1451648539\",\r\n  \"rating\": 4.5,\r\n  \"publisherReleaseDate\": \"2011-10-24T00:00:00\"\r\n}",
                            Title = "Steve Jobs"
                        });
                });

            modelBuilder.Entity("LibraryDemo.Models.Book", b =>
                {
                    b.HasOne("LibraryDemo.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LibraryDemo.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
