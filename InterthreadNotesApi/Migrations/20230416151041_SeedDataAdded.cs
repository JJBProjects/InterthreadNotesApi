using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InterthreadNotesApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "UserJJB1" },
                    { 2, "UserJJB2" },
                    { 3, "UserJJB3" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "NoteCreatedTimestamp", "NoteText", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 17, 1, 10, 41, 33, DateTimeKind.Local).AddTicks(4951), "UserJJB1TestNote1", 1 },
                    { 2, new DateTime(2023, 4, 17, 1, 10, 41, 33, DateTimeKind.Local).AddTicks(4973), "UserJJB1TestNote2", 1 },
                    { 3, new DateTime(2023, 4, 17, 1, 10, 41, 33, DateTimeKind.Local).AddTicks(4982), "UserJJB2TestNote1", 2 },
                    { 4, new DateTime(2023, 4, 17, 1, 10, 41, 33, DateTimeKind.Local).AddTicks(4990), "UserJJB3TestNote1", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
