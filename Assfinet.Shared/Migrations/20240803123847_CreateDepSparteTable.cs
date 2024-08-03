using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assfinet.Shared.Migrations
{
    /// <inheritdoc />
    public partial class CreateDepSparteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KrvSparten_Vertraege_Key",
                table: "KrvSparten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KrvSparten",
                table: "KrvSparten");

            migrationBuilder.RenameTable(
                name: "KrvSparten",
                newName: "KrvSparte");

            migrationBuilder.RenameIndex(
                name: "IX_KrvSparten_Key",
                table: "KrvSparte",
                newName: "IX_KrvSparte_Key");

            migrationBuilder.RenameIndex(
                name: "IX_KrvSparten_AmsId",
                table: "KrvSparte",
                newName: "IX_KrvSparte_AmsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KrvSparte",
                table: "KrvSparte",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DepSparte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Bearbeitet = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Amsidnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Typ = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    License = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastSynchronisation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DEP101 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP111 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP113 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP115 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP116 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP119 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP120 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP122 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP125 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP126 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP128 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP131 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP132 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP134 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP137 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP138 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP140 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP143 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP144 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP146 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP149 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP150 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP152 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP155 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP156 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP158 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP161 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP162 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP164 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP167 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP168 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP170 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP173 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP174 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP176 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP178 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP179 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEP180 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepSparte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepSparte_Vertraege_Key",
                        column: x => x.Key,
                        principalTable: "Vertraege",
                        principalColumn: "Amsidnr",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DepSparte_AmsId",
                table: "DepSparte",
                column: "AmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepSparte_Key",
                table: "DepSparte",
                column: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_KrvSparte_Vertraege_Key",
                table: "KrvSparte",
                column: "Key",
                principalTable: "Vertraege",
                principalColumn: "Amsidnr",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KrvSparte_Vertraege_Key",
                table: "KrvSparte");

            migrationBuilder.DropTable(
                name: "DepSparte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KrvSparte",
                table: "KrvSparte");

            migrationBuilder.RenameTable(
                name: "KrvSparte",
                newName: "KrvSparten");

            migrationBuilder.RenameIndex(
                name: "IX_KrvSparte_Key",
                table: "KrvSparten",
                newName: "IX_KrvSparten_Key");

            migrationBuilder.RenameIndex(
                name: "IX_KrvSparte_AmsId",
                table: "KrvSparten",
                newName: "IX_KrvSparten_AmsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KrvSparten",
                table: "KrvSparten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KrvSparten_Vertraege_Key",
                table: "KrvSparten",
                column: "Key",
                principalTable: "Vertraege",
                principalColumn: "Amsidnr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
