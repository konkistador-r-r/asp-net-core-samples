using Microsoft.EntityFrameworkCore.Migrations;

namespace NavigationProp.Migrations
{
    public partial class Set_CASCADE_STRICT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyName",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyName",
                table: "Users",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyName",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyName",
                table: "Users",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
