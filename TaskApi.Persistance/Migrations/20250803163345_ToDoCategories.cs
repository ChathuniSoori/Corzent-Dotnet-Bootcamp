using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ToDoCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Category", "Description", "IsCompleted", "Name", "Priority" },
                values: new object[] { 1, "home todos", "Milk, Bread, Eggs", false, "Buy groceries-DB", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ToDos");
        }
    }
}
