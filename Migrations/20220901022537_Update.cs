using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _272Ass3.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeminarId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Seminar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seminar_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_SeminarId",
                table: "User",
                column: "SeminarId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminar_User",
                table: "Seminar",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Seminar_SeminarId",
                table: "User",
                column: "SeminarId",
                principalTable: "Seminar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Seminar_SeminarId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Seminar");

            migrationBuilder.DropIndex(
                name: "IX_User_SeminarId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SeminarId",
                table: "User");
        }
    }
}
