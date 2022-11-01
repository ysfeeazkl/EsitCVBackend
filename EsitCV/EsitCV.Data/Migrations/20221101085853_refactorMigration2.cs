using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class refactorMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts");

            migrationBuilder.AlterColumn<int>(
                name: "AboutID",
                table: "UserProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts");

            migrationBuilder.AlterColumn<int>(
                name: "AboutID",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
