using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class uniqueconstraintforphonenumberadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc4f1c54-fde1-4b6b-9bcc-a8e563e80d74", "AQAAAAIAAYagAAAAEMA7+trk8qydOGa4A1dydDg/HBSjZuC+a821kG2h575svKhHTgqgDCiG45lMHQ538Q==", "d44cd776-bfaf-411c-9d19-ed87d09c7f13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "202471bd-3acf-4690-8724-ad6353d05089", "AQAAAAIAAYagAAAAEF9+lknD8RJZolCLV7Jg/Non36WtPjnq02ApRqTiy+qDLy204jyLWYWFAW5/SlD8ZA==", "24a04ffc-dcc5-4043-80ed-e1848c073692" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f958ffc-c878-4242-8a8b-2d6315316a20", "AQAAAAIAAYagAAAAEC8Xt8UN2kvkONmmH0zqCmUvv0RcfzTyG5wF7TxoifitMJ3rr+eAG8brT2sDbP6c8w==", "edfb456a-ff61-4a92-85f7-a88090bebc68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8de6d906-6aa1-4f7a-949f-1b856a2fa9bb", "AQAAAAIAAYagAAAAEMkqCiEFA3jwhDBx6hU1pGToItU9n0OtjOB8uuT6LihSOILYKUABjif1y6Yxb45CFQ==", "d6d26101-6ca4-499a-887f-10f51fffc112" });
        }
    }
}
