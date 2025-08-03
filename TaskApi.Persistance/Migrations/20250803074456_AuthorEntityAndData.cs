using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AuthorEntityAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Description", "IsCompleted", "Name", "Priority" },
                values: new object[] { 1, "Milk, Bread, Eggs", false, "Buy groceries-DB", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
