using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SessionFour.Api.Migrations
{
    public partial class ChangeCarEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatYear",
                table: "Car",
                newName: "CreateYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateYear",
                table: "Car",
                newName: "CreatYear");
        }
    }
}
