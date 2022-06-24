using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projectTestSem3_Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_bloodProvider = table.Column<int>(type: "int", nullable: false),
                    Id_guest = table.Column<int>(type: "int", nullable: false),
                    Id_mobiLink = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAcc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_BloodDnt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    historyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodProvider_History_historyId",
                        column: x => x.historyId,
                        principalTable: "History",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    historyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_History_historyId",
                        column: x => x.historyId,
                        principalTable: "History",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoibiLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_guest = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    historyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoibiLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoibiLink_History_historyId",
                        column: x => x.historyId,
                        principalTable: "History",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodProvider_historyId",
                table: "BloodProvider",
                column: "historyId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_historyId",
                table: "Guest",
                column: "historyId");

            migrationBuilder.CreateIndex(
                name: "IX_MoibiLink_historyId",
                table: "MoibiLink",
                column: "historyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodProvider");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "MoibiLink");

            migrationBuilder.DropTable(
                name: "UserAcc");

            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
