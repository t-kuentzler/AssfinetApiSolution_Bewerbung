using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assfinet.Shared.Migrations
{
    /// <inheritdoc />
    public partial class ChangedKundePersonenDetailsBrancheLengthTo600 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Branche",
                table: "KundenPersonenDetails",
                type: "varchar(600)",
                maxLength: 600,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Branche",
                table: "KundenPersonenDetails",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(600)",
                oldMaxLength: 600,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
