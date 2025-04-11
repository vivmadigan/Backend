using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalSeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientName" },
                values: new object[,]
                {
                    { "0b8c6218-e1c7-4149-b3c9-3e6217c1c14e", "Soylent Corp" },
                    { "4f3bb3c0-3d92-4e28-b6e4-5823a30b3a1c", "Contoso Ltd." },
                    { "ab2566ae-45c9-4c11-85ff-1ef1da3772e4", "Initech" },
                    { "c2ab1b58-0e0f-4b52-9a11-0dc5e18cfd63", "Globex Corporation" },
                    { "f6dc7358-0bd3-4c43-a965-40421ef8ee4f", "Umbrella Corp" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Planning" },
                    { 2, "Started" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { "58e16de8-2046-4f4f-86da-88e11bdc0f2a", "dave@example.com" },
                    { "65c37406-2a7a-4f67-8c7f-89b4b2e40f03", "eve@example.com" },
                    { "6618abef-8c1e-44c5-a2d1-3318c6c76927", "carol@example.com" },
                    { "8297339c-1f0f-4d6d-a378-c6a08a61ff2a", "bob@example.com" },
                    { "e00af53f-45dc-4e1b-9db4-82512bc2b31a", "alice@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "0b8c6218-e1c7-4149-b3c9-3e6217c1c14e");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "4f3bb3c0-3d92-4e28-b6e4-5823a30b3a1c");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "ab2566ae-45c9-4c11-85ff-1ef1da3772e4");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "c2ab1b58-0e0f-4b52-9a11-0dc5e18cfd63");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "f6dc7358-0bd3-4c43-a965-40421ef8ee4f");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "58e16de8-2046-4f4f-86da-88e11bdc0f2a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "65c37406-2a7a-4f67-8c7f-89b4b2e40f03");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6618abef-8c1e-44c5-a2d1-3318c6c76927");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8297339c-1f0f-4d6d-a378-c6a08a61ff2a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e00af53f-45dc-4e1b-9db4-82512bc2b31a");
        }
    }
}
