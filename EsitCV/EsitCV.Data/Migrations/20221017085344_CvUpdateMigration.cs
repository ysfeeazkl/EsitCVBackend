using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class CvUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CurriculumVitaes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 17, 11, 53, 44, 365, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 17, 11, 53, 44, 365, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 17, 11, 53, 44, 365, DateTimeKind.Local).AddTicks(9930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CurriculumVitaes");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 14, 17, 55, 44, 813, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 14, 17, 55, 44, 813, DateTimeKind.Local).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 14, 17, 55, 44, 813, DateTimeKind.Local).AddTicks(3776));
        }
    }
}
