using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userClaimsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Linda Michaels", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Teodor Lesly", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Admin Adminov", "158122db-fe9b-4553-98b2-046e5929d0fe" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d828e971-9434-49de-b78c-77cc0c425274", "AQAAAAIAAYagAAAAEKbCnEFh0/X272rvhh1BssCglB/lZmlPu79L5OHtOJE7lLYGvhezbB1NFlppAVx6kA==", "ff675508-79a7-428b-b0bc-884c074f7e93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91e5aeb4-4c23-4531-b49b-f076167e5f9a", "AQAAAAIAAYagAAAAEEpnqR9R8JRE44SzZz1WVjumVf/9KvmEgf1Hgi6gzOtCn9E8OeXm4ao3T/pAXGtiOg==", "3ca0de3a-ab48-4a05-97d7-d456f77e2c10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3807c182-f843-4a66-82dd-88e6b0837380", "AQAAAAIAAYagAAAAEIGPCzkvTWyRJ+n6rTFEMJLj1fL+WInYT6QsGKzi7eWpbwIX8ll1i71+SWi5T3uRQA==", "b583f046-8ce6-4c84-9c0e-cfcfae017a80" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6bba58a-5b6d-4e14-a143-a61e72aadd69", "AQAAAAIAAYagAAAAEF15DqF/wrnCAw0+J9S2w5ZSimYU4j0INHfv8EXNrIm1WBznKCS8D53+0NZUvH5YFw==", "a01f487c-ff4f-4b17-9121-96439d03da99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a81107a-c38c-4eb1-a08e-30f49d35cd64", "AQAAAAIAAYagAAAAELSGOlhG3n0B0lbrQJQZX2HFgIP9lpcDDuobaXVAXyc76mAE5zG4YVg9RgExj1nVJA==", "f2f820bf-d22f-4e00-9613-0f563b34df85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25650e4e-d13c-4de4-a513-fcc25eb98a79", "AQAAAAIAAYagAAAAEDCokFT543gT6BfXIXWYPjZGgrvH15R8FyYaAf7vbvVfYwy9cwYucUy60/wC1q6xuw==", "e9e08d39-9d78-420e-84fb-eabbfacb0d56" });
        }
    }
}
