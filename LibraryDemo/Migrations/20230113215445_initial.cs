using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDemo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Metadata = table.Column<string>(type: "CLOB", nullable: true),
                    AuthorId = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[] { new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), new DateTime(1952, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter Isaacson" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[] { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Metadata", "Title" },
                values: new object[] { new Guid("150c81c6-2458-466e-907a-2df11325e2b8"), new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Walter Isaacson\\u2019s \\u201Centhralling\\u201D (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs.\",\r\n  \"genre\": \"Biography\",\r\n  \"publisher\": \"Simon \\u0026 Schuster; 1st edition (October 24, 2011)\",\r\n  \"isbn\": \"978-1451648539\",\r\n  \"rating\": 4.5,\r\n  \"publisherReleaseDate\": \"2011-10-24T00:00:00\"\r\n}", "Steve Jobs" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Metadata", "Title" },
                values: new object[] { new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"), new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Harry Potter\\u0027s life is miserable. His parents are dead and he\\u0027s stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.\",\r\n  \"genre\": \"Fantasy\",\r\n  \"publisher\": \"Scholastic; 1st Scholastic Td Ppbk Print., Sept.1999 edition (September 1, 1998)\",\r\n  \"isbn\": \"978-0439708180\",\r\n  \"rating\": 5,\r\n  \"publisherReleaseDate\": \"1998-09-01T00:00:00\"\r\n}", "Harry Potter and the Sorcerer's Stone" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Metadata", "Title" },
                values: new object[] { new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"), new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "{\r\n  \"availableToPublic\": true,\r\n  \"description\": \"Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. \",\r\n  \"publisher\": \"Scholastic Paperbacks; Reprint edition (September 1, 2000)\",\r\n  \"isbn\": \"978-0439064873\",\r\n  \"rating\": 5,\r\n  \"publisherReleaseDate\": \"2000-09-01T00:00:00\"\r\n}", "Harry Potter and the Chamber of Secrets" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
