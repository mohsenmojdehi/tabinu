using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class t3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementPlanId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraphicDesigningPlanId",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AdvertisementPlanId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "GraphicDesigningPlanId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
