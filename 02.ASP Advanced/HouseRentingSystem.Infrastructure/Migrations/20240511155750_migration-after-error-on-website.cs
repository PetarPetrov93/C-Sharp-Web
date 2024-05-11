using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationaftererroronwebsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
