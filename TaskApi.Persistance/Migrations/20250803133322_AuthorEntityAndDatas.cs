using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskApi.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AuthorEntityAndDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityLevel",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 111, "Chathuni" },
                    { 222, "Soori" }
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "AuthorId", "Description", "IsCompleted", "Name", "Priority", "PriorityLevel" },
                values: new object[,]
                {
                    { 10, 111, "Set up and create first web API", true, "Day 01 Tasks", 0, 2 },
                    { 11, 222, "Create Models", true, "Day 02 Tasks", 0, 2 },
                    { 12, 111, "Create Services", true, "Day 03 Tasks", 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AuthorId",
                table: "ToDos",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Authors_AuthorId",
                table: "ToDos",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Authors_AuthorId",
                table: "ToDos");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_AuthorId",
                table: "ToDos");

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "ToDos");

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Description", "IsCompleted", "Name", "Priority" },
                values: new object[] { 1, "Milk, Bread, Eggs", false, "Buy groceries-DB", 1 });
        }
    }
}
