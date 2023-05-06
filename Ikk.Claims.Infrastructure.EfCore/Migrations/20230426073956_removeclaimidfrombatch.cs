using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ikk.Claims.Infrastructure.EfCore.Migrations
{
    public partial class removeclaimidfrombatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claems_BatchId",
                schema: "clm",
                table: "Claems");

            migrationBuilder.DropColumn(
                name: "ClaemId",
                schema: "clm",
                table: "Batchs");

            migrationBuilder.CreateIndex(
                name: "IX_Claems_BatchId",
                schema: "clm",
                table: "Claems",
                column: "BatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Claems_BatchId",
                schema: "clm",
                table: "Claems");

            migrationBuilder.AddColumn<long>(
                name: "ClaemId",
                schema: "clm",
                table: "Batchs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Claems_BatchId",
                schema: "clm",
                table: "Claems",
                column: "BatchId",
                unique: true);
        }
    }
}
