using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyrenteraddedforhouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Renter Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Renter Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "158122db-fe9b-4553-98b2-046e5929d0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbd260a7-f238-43b0-8897-9e83b92405eb", "AQAAAAIAAYagAAAAEJvXs3Ug+h4yG3PI258CZPVC3KIy/O7amYkxZqYXD3D0aQWZv3uK8TUBJvcjpduohg==", "1a8138d8-637f-4a9d-be02-ce86965a5cfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4477e157-b394-4426-adbe-3286bca045df", "AQAAAAIAAYagAAAAEF8y4MX7qPaD1HyX2CIx/xfrXzcX3bccypjTuyxHl9mbdj8ms2/I61RCZ9V7BxJRhw==", "c7d7e922-e5bb-4196-ac51-cbdbb2d0c972" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85b13a92-d0ee-4125-b64b-345136ff4221", "AQAAAAIAAYagAAAAEMRaraauEexUUz1zpLUiZFRYSrzrhjqvqocZ3G7tSMZo6LNeS3h/3oUmlVN96fWciw==", "9876f008-390e-4d18-8672-89764cc65252" });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Renter Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "Renter Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}
