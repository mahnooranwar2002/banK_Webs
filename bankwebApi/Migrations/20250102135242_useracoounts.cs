using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class useracoounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "tbl_accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tbl_accounts");
        }
    }
}
