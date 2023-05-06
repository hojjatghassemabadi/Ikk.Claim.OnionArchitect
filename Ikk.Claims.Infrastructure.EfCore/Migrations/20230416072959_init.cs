using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ikk.Claims.Infrastructure.EfCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clm");

            migrationBuilder.CreateTable(
                name: "Batchs",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClaemId = table.Column<long>(type: "bigint", nullable: false),
                    CarInBatchId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CKDQRs",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverSeasFactory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountainerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackingStatus = table.Column<int>(type: "int", nullable: false),
                    OverSeasePlantAction = table.Column<int>(type: "int", nullable: false),
                    Responsibility = table.Column<int>(type: "int", nullable: false),
                    URgencyClassification = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<int>(type: "int", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    Problemtype = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CKDQRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCars",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Famil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claems",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountPart = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claems_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalSchema: "clm",
                        principalTable: "Batchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CKDQRPics",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CkdqrId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CKDQRPics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CKDQRPics_CKDQRs_CkdqrId",
                        column: x => x.CkdqrId,
                        principalSchema: "clm",
                        principalTable: "CKDQRs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carInBatches",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCarId = table.Column<long>(type: "bigint", nullable: false),
                    BatchId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carInBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carInBatches_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalSchema: "clm",
                        principalTable: "Batchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carInBatches_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "clm",
                        principalTable: "Parts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_carInBatches_TypeCars_TypeCarId",
                        column: x => x.TypeCarId,
                        principalSchema: "clm",
                        principalTable: "TypeCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "clm",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "clm",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "claemInCkdqrs",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaemId = table.Column<long>(type: "bigint", nullable: false),
                    CkdqrId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claemInCkdqrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_claemInCkdqrs_CKDQRs_CkdqrId",
                        column: x => x.CkdqrId,
                        principalSchema: "clm",
                        principalTable: "CKDQRs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_claemInCkdqrs_Claems_ClaemId",
                        column: x => x.ClaemId,
                        principalSchema: "clm",
                        principalTable: "Claems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaemPics",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PicAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaemPics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaemPics_Claems_ClaemId",
                        column: x => x.ClaemId,
                        principalSchema: "clm",
                        principalTable: "Claems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimInPart",
                schema: "clm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<long>(type: "bigint", nullable: false),
                    ClaemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimInPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimInPart_Claems_ClaemId",
                        column: x => x.ClaemId,
                        principalSchema: "clm",
                        principalTable: "Claems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimInPart_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "clm",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carInBatches_BatchId",
                schema: "clm",
                table: "carInBatches",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_carInBatches_PartId",
                schema: "clm",
                table: "carInBatches",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_carInBatches_TypeCarId",
                schema: "clm",
                table: "carInBatches",
                column: "TypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CKDQRPics_CkdqrId",
                schema: "clm",
                table: "CKDQRPics",
                column: "CkdqrId");

            migrationBuilder.CreateIndex(
                name: "IX_claemInCkdqrs_CkdqrId",
                schema: "clm",
                table: "claemInCkdqrs",
                column: "CkdqrId");

            migrationBuilder.CreateIndex(
                name: "IX_claemInCkdqrs_ClaemId",
                schema: "clm",
                table: "claemInCkdqrs",
                column: "ClaemId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaemPics_ClaemId",
                schema: "clm",
                table: "ClaemPics",
                column: "ClaemId");

            migrationBuilder.CreateIndex(
                name: "IX_Claems_BatchId",
                schema: "clm",
                table: "Claems",
                column: "BatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInPart_ClaemId",
                schema: "clm",
                table: "ClaimInPart",
                column: "ClaemId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimInPart_PartId",
                schema: "clm",
                table: "ClaimInPart",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_RoleId",
                schema: "clm",
                table: "UserInRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserId",
                schema: "clm",
                table: "UserInRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "clm",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carInBatches",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "CKDQRPics",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "claemInCkdqrs",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "ClaemPics",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "ClaimInPart",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "UserInRoles",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "TypeCars",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "CKDQRs",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "Claems",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "Parts",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "clm");

            migrationBuilder.DropTable(
                name: "Batchs",
                schema: "clm");
        }
    }
}
