using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ikk.Claims.Infrastructure.EfCore.Migrations
{
    public partial class claeminpart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimInPart_Claems_ClaemId",
                schema: "clm",
                table: "ClaimInPart");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimInPart_Parts_PartId",
                schema: "clm",
                table: "ClaimInPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimInPart",
                schema: "clm",
                table: "ClaimInPart");

            migrationBuilder.RenameTable(
                name: "ClaimInPart",
                schema: "clm",
                newName: "claemInParts",
                newSchema: "clm");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimInPart_PartId",
                schema: "clm",
                table: "claemInParts",
                newName: "IX_claemInParts_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimInPart_ClaemId",
                schema: "clm",
                table: "claemInParts",
                newName: "IX_claemInParts_ClaemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_claemInParts",
                schema: "clm",
                table: "claemInParts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_claemInParts_Claems_ClaemId",
                schema: "clm",
                table: "claemInParts",
                column: "ClaemId",
                principalSchema: "clm",
                principalTable: "Claems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_claemInParts_Parts_PartId",
                schema: "clm",
                table: "claemInParts",
                column: "PartId",
                principalSchema: "clm",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_claemInParts_Claems_ClaemId",
                schema: "clm",
                table: "claemInParts");

            migrationBuilder.DropForeignKey(
                name: "FK_claemInParts_Parts_PartId",
                schema: "clm",
                table: "claemInParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_claemInParts",
                schema: "clm",
                table: "claemInParts");

            migrationBuilder.RenameTable(
                name: "claemInParts",
                schema: "clm",
                newName: "ClaimInPart",
                newSchema: "clm");

            migrationBuilder.RenameIndex(
                name: "IX_claemInParts_PartId",
                schema: "clm",
                table: "ClaimInPart",
                newName: "IX_ClaimInPart_PartId");

            migrationBuilder.RenameIndex(
                name: "IX_claemInParts_ClaemId",
                schema: "clm",
                table: "ClaimInPart",
                newName: "IX_ClaimInPart_ClaemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimInPart",
                schema: "clm",
                table: "ClaimInPart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimInPart_Claems_ClaemId",
                schema: "clm",
                table: "ClaimInPart",
                column: "ClaemId",
                principalSchema: "clm",
                principalTable: "Claems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimInPart_Parts_PartId",
                schema: "clm",
                table: "ClaimInPart",
                column: "PartId",
                principalSchema: "clm",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
