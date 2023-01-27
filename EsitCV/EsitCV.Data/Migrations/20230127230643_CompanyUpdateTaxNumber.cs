using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class CompanyUpdateTaxNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Companies",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 971, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 970, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 970, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 2, 6, 42, 970, DateTimeKind.Local).AddTicks(1690));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Companies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 854, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 853, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 853, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 28, 1, 58, 37, 853, DateTimeKind.Local).AddTicks(4317));
        }
    }
}
