using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoardApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoardId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84ae52c2-3c7d-446f-be08-9c846ce48fdc", 0, "a4c9659d-4288-4557-be89-b7ddec2d8581", null, false, false, null, "TEST@SOFTUNI.BG", null, "AQAAAAIAAYagAAAAEMNLBQXq93dxERcGa1UnSLdnXLyXtEtzmwZs/H2/nlnbwE2ArUlxPMVk8UZiwOlkAw==", null, false, "352e526d-5b96-44c6-826f-86b3590ea040", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 18, 10, 21, 29, 19, DateTimeKind.Utc).AddTicks(6359), "Implement better styling for all public pages", "84ae52c2-3c7d-446f-be08-9c846ce48fdc", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 12, 5, 10, 21, 29, 19, DateTimeKind.Utc).AddTicks(6392), "Create Android client App for the RESTful TaskBoard service", "84ae52c2-3c7d-446f-be08-9c846ce48fdc", "Android Client App" },
                    { 3, 2, new DateTime(2024, 4, 5, 10, 21, 29, 19, DateTimeKind.Utc).AddTicks(6401), "Create Desktop client App for the RESTful TaskBoard service", "84ae52c2-3c7d-446f-be08-9c846ce48fdc", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 5, 5, 10, 21, 29, 19, DateTimeKind.Utc).AddTicks(6404), "Implement [Create Task] page for adding tasks", "84ae52c2-3c7d-446f-be08-9c846ce48fdc", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84ae52c2-3c7d-446f-be08-9c846ce48fdc");
        }
    }
}
