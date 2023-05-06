using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ikk.Claims.Infrastructure.EfCore.Migrations
{
    public partial class changepicname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicAddress",
                schema: "clm",
                table: "ClaemPics",
                newName: "PicName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicName",
                schema: "clm",
                table: "ClaemPics",
                newName: "PicAddress");
        }
    }
}
