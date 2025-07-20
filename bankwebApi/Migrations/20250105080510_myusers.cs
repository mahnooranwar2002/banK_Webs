using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class myusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "is_admin",
                table: "tbl_users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_admin",
                table: "tbl_users");
        }
    }
}
