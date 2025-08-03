using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FixedToDosSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuthorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AuthorId",
                table: "ToDos",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Author_AuthorId",
                table: "ToDos",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Author_AuthorId",
                table: "ToDos");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_AuthorId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ToDos");
        }
    }
}
