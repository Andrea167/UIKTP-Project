using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Name" },
                values: new object[,]
                {
                    { new Guid("2340faf7-31af-4467-a799-71b86293c539"), "Created the C language and OS theory.", "Dennis Ritchie" },
                    { new Guid("746516bd-8fd2-43d5-8128-a37b134159fc"), "Mathematician and logician.", "Dr. Alan Turing" },
                    { new Guid("d5c97fcb-373a-4099-8f4b-79be4e9dbb24"), "Pioneer of computing and OOP.", "Ada Lovelace" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("1dbcf313-4be0-4b75-bad1-f42a64644603"), new Guid("2340faf7-31af-4467-a799-71b86293c539"), "Introduction to OS principles", "Operating System" },
                    { new Guid("cc16e97f-8e7f-4723-b3c5-5ea2a883c6bb"), new Guid("746516bd-8fd2-43d5-8128-a37b134159fc"), "Learn Calculus from scratch", "Calculus" },
                    { new Guid("fecf59dd-0705-4882-9dd8-853c161ce167"), new Guid("d5c97fcb-373a-4099-8f4b-79be4e9dbb24"), "Understand OOP concepts", "Object Oriented Programming" }
                });

            migrationBuilder.InsertData(
                table: "CourseModules",
                columns: new[] { "Id", "CourseId", "Title" },
                values: new object[,]
                {
                    { new Guid("3a209081-2a93-471f-889f-f91be6ae3b0a"), new Guid("cc16e97f-8e7f-4723-b3c5-5ea2a883c6bb"), "Integrals" },
                    { new Guid("592834d8-c34f-41b4-8d4f-38270fb9b0e1"), new Guid("1dbcf313-4be0-4b75-bad1-f42a64644603"), "Processes and Threads" },
                    { new Guid("76651b18-c224-4385-959a-b1a00d49523b"), new Guid("fecf59dd-0705-4882-9dd8-853c161ce167"), "Inheritance and Polymorphism" },
                    { new Guid("8d7aea43-e17a-489b-9f6e-22dfc8ebe9e2"), new Guid("fecf59dd-0705-4882-9dd8-853c161ce167"), "Abstraction and Interfaces" },
                    { new Guid("bcb0c203-cea0-4eef-ad3e-be14ea2ef98d"), new Guid("fecf59dd-0705-4882-9dd8-853c161ce167"), "Classes and Objects" },
                    { new Guid("be8dfd8b-0790-4a5b-bd0c-4dd922a9bc8a"), new Guid("cc16e97f-8e7f-4723-b3c5-5ea2a883c6bb"), "Graph and functions" },
                    { new Guid("c928791c-7afa-4261-b982-09be9a5aca3a"), new Guid("1dbcf313-4be0-4b75-bad1-f42a64644603"), "File Systems" },
                    { new Guid("d76b898f-4392-42c1-8b2d-459c0bedb238"), new Guid("1dbcf313-4be0-4b75-bad1-f42a64644603"), "Memory Management" },
                    { new Guid("fb1e7162-9349-423d-9a6c-0f6cbd729c41"), new Guid("cc16e97f-8e7f-4723-b3c5-5ea2a883c6bb"), "Limits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_CourseId",
                table: "CourseModules",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseModules");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1dbcf313-4be0-4b75-bad1-f42a64644603"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("cc16e97f-8e7f-4723-b3c5-5ea2a883c6bb"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("fecf59dd-0705-4882-9dd8-853c161ce167"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2340faf7-31af-4467-a799-71b86293c539"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("746516bd-8fd2-43d5-8128-a37b134159fc"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d5c97fcb-373a-4099-8f4b-79be4e9dbb24"));
        }
    }
}
