using Microsoft.EntityFrameworkCore.Migrations;

namespace GSCS_Cameras_API.Migrations
{
    public partial class LinkCameraToSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "Cameras",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_SchoolID",
                table: "Cameras",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_Schools_SchoolID",
                table: "Cameras",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_Schools_SchoolID",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_SchoolID",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "Cameras");
        }
    }
}
