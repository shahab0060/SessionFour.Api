using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SessionFour.Api.Migrations
{
    public partial class ChangeCarEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatYear",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatYear",
                table: "Car");
        }
    }
}
