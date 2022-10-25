using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class refactorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 458, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 457, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 457, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 49, 15, 457, DateTimeKind.Local).AddTicks(9382));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 930, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 928, DateTimeKind.Local).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 928, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 25, 13, 45, 33, 928, DateTimeKind.Local).AddTicks(1311));
        }
    }
}
