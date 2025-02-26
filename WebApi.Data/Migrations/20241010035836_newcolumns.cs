using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiVersion1.Migrations
{
    /// <inheritdoc />
    public partial class newcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalOrder",
                table: "OrderInformation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderInformation");

            migrationBuilder.DropColumn(
                name: "TotalOrder",
                table: "OrderInformation");
        }
    }
}
