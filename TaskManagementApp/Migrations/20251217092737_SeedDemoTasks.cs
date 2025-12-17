using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "CreatedOn", "Description", "DueDate", "Remarks", "Status", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6190), "Design the database schema for the Task Management app", new DateTime(2025, 12, 24, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6186), "High priority", 2, "Design Database Schema", 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6190) },
                    { 2, 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6192), "Create controllers and views for Task CRUD operations", new DateTime(2025, 12, 22, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6191), "Start after DB design", 1, "Implement CRUD Controllers", 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6193) },
                    { 3, 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6194), "Implement search and status filter in index page", new DateTime(2025, 12, 20, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6194), "Depends on CRUD completion", 4, "Add Search and Filter", 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6195) },
                    { 4, 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6197), "Document the project", new DateTime(2025, 12, 18, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6196), "Assignment ready", 3, "Write README.md", 1, new DateTime(2025, 12, 17, 9, 27, 36, 535, DateTimeKind.Utc).AddTicks(6197) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4);
        }
    }
}
