using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class FeaturesAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterest_UserProfiles_UserProfileID",
                table: "AreasOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_UserProfiles_UserProfileID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentProject_UserProfiles_UserProfileID",
                table: "CurrentProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_UserProfiles_UserProfileID",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobbie_UserProfiles_UserProfileID",
                table: "Hobbie");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_UserProfiles_UserProfileID",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseOrCertificate_UserProfiles_UserProfileID",
                table: "LicenseOrCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_About_AboutID",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_UserProfiles_UserProfileID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_AboutID",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseOrCertificate",
                table: "LicenseOrCertificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbie",
                table: "Hobbie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentProject",
                table: "CurrentProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreasOfInterest",
                table: "AreasOfInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "WorkExperience",
                newName: "WorkExperiences");

            migrationBuilder.RenameTable(
                name: "LicenseOrCertificate",
                newName: "LicenseOrCerificates");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "Hobbie",
                newName: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "CurrentProject",
                newName: "CurrentProjects");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "AreasOfInterest",
                newName: "AreasOfInterests");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "Abouts");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperience_UserProfileID",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseOrCertificate_UserProfileID",
                table: "LicenseOrCerificates",
                newName: "IX_LicenseOrCerificates_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Language_UserProfileID",
                table: "Languages",
                newName: "IX_Languages_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Hobbie_UserProfileID",
                table: "Hobbies",
                newName: "IX_Hobbies_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Education_UserProfileID",
                table: "Educations",
                newName: "IX_Educations_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentProject_UserProfileID",
                table: "CurrentProjects",
                newName: "IX_CurrentProjects_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_UserProfileID",
                table: "Courses",
                newName: "IX_Courses_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterest_UserProfileID",
                table: "AreasOfInterests",
                newName: "IX_AreasOfInterests_UserProfileID");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "WorkExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "LicenseOrCerificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LicenseOrCerificates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "LicenseOrCerificates",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Hobbies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobbies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Educations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "CurrentProjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "CurrentProjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CurrentProjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectUrl",
                table: "CurrentProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "AreasOfInterests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AreasOfInterests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Abouts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileID",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseOrCerificates",
                table: "LicenseOrCerificates",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentProjects",
                table: "CurrentProjects",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreasOfInterests",
                table: "AreasOfInterests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currently = table.Column<bool>(type: "bit", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IssuingBodyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserProfileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organizations_UserProfiles_UserProfileID",
                        column: x => x.UserProfileID,
                        principalTable: "UserProfiles",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_UserProfileID",
                table: "Abouts",
                column: "UserProfileID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserProfileID",
                table: "Organizations",
                column: "UserProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterests_UserProfiles_UserProfileID",
                table: "AreasOfInterests",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UserProfiles_UserProfileID",
                table: "Courses",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentProjects_UserProfiles_UserProfileID",
                table: "CurrentProjects",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_UserProfiles_UserProfileID",
                table: "Educations",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_UserProfiles_UserProfileID",
                table: "Hobbies",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_UserProfiles_UserProfileID",
                table: "Languages",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseOrCerificates_UserProfiles_UserProfileID",
                table: "LicenseOrCerificates",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_UserProfiles_UserProfileID",
                table: "WorkExperiences",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_UserProfiles_UserProfileID",
                table: "Abouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfInterests_UserProfiles_UserProfileID",
                table: "AreasOfInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UserProfiles_UserProfileID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentProjects_UserProfiles_UserProfileID",
                table: "CurrentProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_UserProfiles_UserProfileID",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_UserProfiles_UserProfileID",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_UserProfiles_UserProfileID",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseOrCerificates_UserProfiles_UserProfileID",
                table: "LicenseOrCerificates");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_UserProfiles_UserProfileID",
                table: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseOrCerificates",
                table: "LicenseOrCerificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentProjects",
                table: "CurrentProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreasOfInterests",
                table: "AreasOfInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_UserProfileID",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "CurrentProjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CurrentProjects");

            migrationBuilder.DropColumn(
                name: "ProjectUrl",
                table: "CurrentProjects");

            migrationBuilder.DropColumn(
                name: "UserProfileID",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "WorkExperiences",
                newName: "WorkExperience");

            migrationBuilder.RenameTable(
                name: "LicenseOrCerificates",
                newName: "LicenseOrCertificate");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobbie");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "CurrentProjects",
                newName: "CurrentProject");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "AreasOfInterests",
                newName: "AreasOfInterest");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "About");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_UserProfileID",
                table: "WorkExperience",
                newName: "IX_WorkExperience_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseOrCerificates_UserProfileID",
                table: "LicenseOrCertificate",
                newName: "IX_LicenseOrCertificate_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_UserProfileID",
                table: "Language",
                newName: "IX_Language_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Hobbies_UserProfileID",
                table: "Hobbie",
                newName: "IX_Hobbie_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_UserProfileID",
                table: "Education",
                newName: "IX_Education_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_CurrentProjects_UserProfileID",
                table: "CurrentProject",
                newName: "IX_CurrentProject_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_UserProfileID",
                table: "Course",
                newName: "IX_Course_UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_AreasOfInterests_UserProfileID",
                table: "AreasOfInterest",
                newName: "IX_AreasOfInterest_UserProfileID");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "WorkExperience",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "LicenseOrCertificate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LicenseOrCertificate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "LicenseOrCertificate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Language",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Hobbie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobbie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Education",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "CurrentProject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileID",
                table: "AreasOfInterest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AreasOfInterest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "About",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseOrCertificate",
                table: "LicenseOrCertificate",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbie",
                table: "Hobbie",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentProject",
                table: "CurrentProject",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreasOfInterest",
                table: "AreasOfInterest",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 331, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 331, DateTimeKind.Local).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 15, 59, 32, 331, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AboutID",
                table: "UserProfiles",
                column: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfInterest_UserProfiles_UserProfileID",
                table: "AreasOfInterest",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_UserProfiles_UserProfileID",
                table: "Course",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentProject_UserProfiles_UserProfileID",
                table: "CurrentProject",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_UserProfiles_UserProfileID",
                table: "Education",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbie_UserProfiles_UserProfileID",
                table: "Hobbie",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Language_UserProfiles_UserProfileID",
                table: "Language",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseOrCertificate_UserProfiles_UserProfileID",
                table: "LicenseOrCertificate",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_About_AboutID",
                table: "UserProfiles",
                column: "AboutID",
                principalTable: "About",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_UserProfiles_UserProfileID",
                table: "WorkExperience",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");
        }
    }
}
