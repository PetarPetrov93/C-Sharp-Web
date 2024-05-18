using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsApprovedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is house approved by admin");

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

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d00e6527-fed5-412d-a7c4-c357c56860e5", "AQAAAAIAAYagAAAAEJ71jjjDtLXsmPOuPsPeBwEk2AzTA1E36iryepoghap8Y0wPSrfsNkTYBy3TVggRNQ==", "17eb5b0d-3cee-4c7b-8448-a3443c36ad15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f59544e1-0ae3-4125-82e0-353a4d3427bc", "AQAAAAIAAYagAAAAECSHGED7xzGEPUEPQ7nDC84t08TpbXfANbR44cHoKkUNQCvp9kEjFhiv8kr4TROvvg==", "a33c2002-be26-4584-8e9f-b4aa1daac1c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5212cf8-3700-4b70-9739-34aa14d09b02", "AQAAAAIAAYagAAAAEHiLCI5JHm/iWRRPmbNDmTJPd9usBNbaIqJYxptsDaTlseIdhSuHE4Si2NLZxX1Oeg==", "d175bb8d-7702-49b4-8104-ce1a584ab8c7" });
        }
    }
}
