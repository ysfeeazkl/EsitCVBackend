using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class JobPostingRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sector",
                table: "JobPostings",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LicenceDegree",
                table: "JobPostings",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "JobPostings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "JobPostings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "JobPostings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 826, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 825, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 825, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 15, 8, 58, 825, DateTimeKind.Local).AddTicks(8270));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sector",
                table: "JobPostings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "LicenceDegree",
                table: "JobPostings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "JobPostings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "JobPostings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "JobPostings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 471, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 470, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 470, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 1, 11, 58, 53, 470, DateTimeKind.Local).AddTicks(9992));
        }
    }
}
