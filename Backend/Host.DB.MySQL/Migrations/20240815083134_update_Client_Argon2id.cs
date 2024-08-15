using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Host.DB.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class update_Client_Argon2id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "password",
                table: "clients",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "issuperadmin",
                table: "clients",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "passcodesalt",
                table: "clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "bookcategories",
                keyColumn: "id",
                keyValue: new Guid("6007d295-0d25-4c4b-8935-f440b326cc3e"),
                column: "createdon",
                value: new DateTime(2024, 8, 15, 15, 31, 33, 599, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "id", "cellnumber", "createdon", "isdeactivate", "isdeleted", "ishardcoded", "issuperadmin", "modifiedon", "name", "passcodesalt", "password", "username" },
                values: new object[] { new Guid("723eac11-23d7-4fbe-9a66-f66aece7d69f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fuJqhZID2ruYq+WbjnO4Fw==", new byte[] { 238, 5, 155, 242, 128, 237, 255, 169, 209, 92, 187, 103, 100, 135, 43, 66 }, "superadmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "id",
                keyValue: new Guid("723eac11-23d7-4fbe-9a66-f66aece7d69f"));

            migrationBuilder.DropColumn(
                name: "issuperadmin",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "passcodesalt",
                table: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "clients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "clients",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "clients",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "bookcategories",
                keyColumn: "id",
                keyValue: new Guid("6007d295-0d25-4c4b-8935-f440b326cc3e"),
                column: "createdon",
                value: new DateTime(2024, 8, 3, 18, 15, 34, 256, DateTimeKind.Local).AddTicks(2534));
        }
    }
}
