using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireResistance.Web.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAndIdAddedInTableForColumnAndSlab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SlabWithRigidConnectionData",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ColumnFireIsWithFourSidesData",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SlabWithRigidConnectionData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ColumnFireIsWithFourSidesData");
        }
    }
}
