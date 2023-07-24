using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireResistance.Web.Migrations
{
    /// <inheritdoc />
    public partial class SourceDataChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaveDate",
                table: "SlabWithRigidConnectionData",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SaveDate",
                table: "ColumnFireIsWithFourSidesData",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveDate",
                table: "SlabWithRigidConnectionData");

            migrationBuilder.DropColumn(
                name: "SaveDate",
                table: "ColumnFireIsWithFourSidesData");
        }
    }
}
