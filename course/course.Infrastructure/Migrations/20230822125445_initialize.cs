using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace course.Infrastructure.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Development" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "Art" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, null, "Language" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Duration", "ImageUrl", "StartDate", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, "ASP.NET Core ile web geliştirmeyi öğrenin", 200, "https://placehold.co/300x200", null, "Temel ASP.NET Core", null },
                    { 2, 1, null, "ASP.NET Core ile web geliştirmeyi öğrenin", 200, "https://placehold.co/300x200", null, "İleri ASP.NET Core", null },
                    { 3, 2, null, "Güzel sanatlar...", 200, "https://placehold.co/300x200", null, "Resim", null },
                    { 4, 3, null, "İngilizce", 200, "https://placehold.co/300x200", null, "İngilizce", null },
                    { 5, 3, null, "Fransızca", 200, "https://placehold.co/300x200", null, "Fransızca", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
