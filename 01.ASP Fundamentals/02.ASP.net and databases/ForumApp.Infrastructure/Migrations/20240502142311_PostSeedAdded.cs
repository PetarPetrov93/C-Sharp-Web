using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("63710ac3-7982-4d4b-96df-e71f766b06e5"), "This is the content of my second post.", "My second post" },
                    { new Guid("7d8290bf-a957-43c7-8029-071a987e1fd6"), "This is the content of my third post.", "My third post" },
                    { new Guid("d01c49f8-bb2b-43f1-9970-26b6062c5815"), "This is the content of my first post.", "My first post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("63710ac3-7982-4d4b-96df-e71f766b06e5"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7d8290bf-a957-43c7-8029-071a987e1fd6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d01c49f8-bb2b-43f1-9970-26b6062c5815"));
        }
    }
}
