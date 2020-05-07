using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortLink.DataLayer.Migrations
{
    public partial class AddSiteName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteName",
                table: "GenerateLinks",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteName",
                table: "GenerateLinks");
        }
    }
}
