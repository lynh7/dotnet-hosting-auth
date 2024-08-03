using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Host.DB.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bookcategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    categoryname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isdeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isdeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ishardcoded = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcategories", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cellnumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isdeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isdeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ishardcoded = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    bookname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    borrowfee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bookcategoryid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    createdon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isdeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isdeactivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ishardcoded = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_bookcategories_bookcategoryid",
                        column: x => x.bookcategoryid,
                        principalTable: "bookcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "bookcategories",
                columns: new[] { "id", "categoryname", "createdon", "isdeactivate", "isdeleted", "ishardcoded", "modifiedon" },
                values: new object[] { new Guid("6007d295-0d25-4c4b-8935-f440b326cc3e"), "Art & Music ", new DateTime(2024, 8, 3, 18, 15, 34, 256, DateTimeKind.Local).AddTicks(2534), false, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_books_bookcategoryid",
                table: "books",
                column: "bookcategoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "bookcategories");
        }
    }
}
