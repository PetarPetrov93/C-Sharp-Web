using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "158122db-fe9b-4553-98b2-046e5929d0fe", 0, "c555eee5-4481-4e30-acc6-6356fe2c5873", "admin@mail.com", false, "Admin", "Adminov", false, null, "admin@mail.com", "admin@mail.com", null, null, false, "03f341d9-414b-4cae-a083-503412113fce", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359888888887", "158122db-fe9b-4553-98b2-046e5929d0fe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ae7677f-0d2a-4e3e-9d76-714f8374966d", "AQAAAAIAAYagAAAAEM9F+utQBqQZ3JtstFU7YaQwcaGI38vUScZ6aoW6v9hSqVK2j19NMsKbX1kpJUa+KQ==", "d225b797-4382-40b3-90af-9d9037116708" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42a42372-3ff8-4eec-843a-10d390346afa", "AQAAAAIAAYagAAAAEJsyEwWKEyXMviaM/VE8abFntMbdJnb8Lo355yjjNoXCO7Pk4LrWRBEvXz7/BTMisA==", "bafd3d75-ea12-4854-8299-a0a8f4aee53d" });
        }
    }
}
