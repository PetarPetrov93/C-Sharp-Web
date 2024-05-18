using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminPasswordSeedCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c555eee5-4481-4e30-acc6-6356fe2c5873", null, "03f341d9-414b-4cae-a083-503412113fce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0da759ab-fa72-484e-84df-029bb2cb10a6", "AQAAAAIAAYagAAAAECadrnds5EWYLJoqkUqfvlE2nT5CML9ACjjFV4x0p6u1gAkhUYfn+aB1NFb4JAkHWA==", "371e697e-c7ce-40f6-b69c-28ebeca996e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "558d6efd-e3c7-4de7-88dd-1ebe21bb31b0", "AQAAAAIAAYagAAAAEJk46ythaBcwnByhOMgBXoxgKynAm28KiA1ZwUjHiKhvNWHcb8tJ1F4OYAqqDTz81Q==", "3a3c42f7-a74d-41b6-a0c6-5bca0a7f436d" });
        }
    }
}
