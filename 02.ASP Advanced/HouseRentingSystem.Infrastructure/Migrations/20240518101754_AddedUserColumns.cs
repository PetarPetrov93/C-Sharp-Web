using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ae7677f-0d2a-4e3e-9d76-714f8374966d", "Teodor", "Lesly", "AQAAAAIAAYagAAAAEM9F+utQBqQZ3JtstFU7YaQwcaGI38vUScZ6aoW6v9hSqVK2j19NMsKbX1kpJUa+KQ==", "d225b797-4382-40b3-90af-9d9037116708" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42a42372-3ff8-4eec-843a-10d390346afa", "Linda", "Michaels", "AQAAAAIAAYagAAAAEJsyEwWKEyXMviaM/VE8abFntMbdJnb8Lo355yjjNoXCO7Pk4LrWRBEvXz7/BTMisA==", "bafd3d75-ea12-4854-8299-a0a8f4aee53d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee3229d2-1c23-4264-8a6f-fd0465ef32b9", "AQAAAAIAAYagAAAAEOhsGjj0QB0SLYbYkbzVGph+sll7FalDyc0LLgK0SEKW+ftfl1QTlGKiHg9KFuuNew==", "4f2acc5f-6304-46f0-b7cb-5ad4b25892b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2edce257-a1bc-4277-98b0-25bf61ab4e73", "AQAAAAIAAYagAAAAEB8XEU1dszehfwKumWdn/CLMzyhXheXPNMWzy8SerFQDp9Secv1Cc3pH4eZJO3+Jvg==", "e99ed427-809a-47ad-b0d2-b1fa52abea5e" });
        }
    }
}
