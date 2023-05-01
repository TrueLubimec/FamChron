using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamChron.API.Migrations
{
    /// <inheritdoc />
    public partial class LilCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TileLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    EventsIds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileLines", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 4, 26, 17, 40, 55, 186, DateTimeKind.Utc).AddTicks(7702));

            migrationBuilder.InsertData(
                table: "TileLines",
                columns: new[] { "Id", "EventsIds", "StoryId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TileLines");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 4, 25, 22, 1, 39, 645, DateTimeKind.Utc).AddTicks(3198));
        }
    }
}
