using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsitCV.Data.Migrations
{
    public partial class DisabilitiesAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disability_UserDisabilities_UserDisabilityID",
                table: "Disability");

            migrationBuilder.DropTable(
                name: "UserDisabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disability",
                table: "Disability");

            migrationBuilder.DropIndex(
                name: "IX_Disability_UserDisabilityID",
                table: "Disability");

            migrationBuilder.DropColumn(
                name: "UserDisabilityID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PercentageOfObstacles",
                table: "Disability");

            migrationBuilder.DropColumn(
                name: "UserDisabilityID",
                table: "Disability");

            migrationBuilder.RenameTable(
                name: "Disability",
                newName: "Disabilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disabilities",
                table: "Disabilities",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "UserAndDisabilities",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DisabilityID = table.Column<int>(type: "int", nullable: false),
                    PercentageOfDisability = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndDisabilities", x => new { x.UserID, x.DisabilityID });
                    table.ForeignKey(
                        name: "FK_UserAndDisabilities_Disabilities_DisabilityID",
                        column: x => x.DisabilityID,
                        principalTable: "Disabilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAndDisabilities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Disabilities",
                columns: new[] { "ID", "CreatedByUserId", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByUserId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7181), true, false, 0, null, "İşitme" },
                    { 2, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7183), true, false, 0, null, "Bedensel" },
                    { 3, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7184), true, false, 0, null, "Görme" },
                    { 4, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7185), true, false, 0, null, "Süreğen Hastalık (Kronik)" },
                    { 5, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7186), true, false, 0, null, "Dil ve Konuşma Bozuklupu" },
                    { 6, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7187), true, false, 0, null, "Zihinsel (MR)" },
                    { 7, 0, new DateTime(2022, 10, 18, 15, 59, 32, 332, DateTimeKind.Local).AddTicks(7189), true, false, 0, null, "Sınıflanamayan" }
                });

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
                name: "IX_UserAndDisabilities_DisabilityID",
                table: "UserAndDisabilities",
                column: "DisabilityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAndDisabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disabilities",
                table: "Disabilities");

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.RenameTable(
                name: "Disabilities",
                newName: "Disability");

            migrationBuilder.AddColumn<int>(
                name: "UserDisabilityID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PercentageOfObstacles",
                table: "Disability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDisabilityID",
                table: "Disability",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disability",
                table: "Disability",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "UserDisabilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDisabilities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserDisabilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Disability_UserDisabilityID",
                table: "Disability",
                column: "UserDisabilityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDisabilities_UserId",
                table: "UserDisabilities",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Disability_UserDisabilities_UserDisabilityID",
                table: "Disability",
                column: "UserDisabilityID",
                principalTable: "UserDisabilities",
                principalColumn: "ID");
        }
    }
}
