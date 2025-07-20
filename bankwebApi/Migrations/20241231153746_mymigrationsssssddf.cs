using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class mymigrationsssssddf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pin_code",
                table: "tbl_accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pin_code",
                table: "tbl_accounts");
        }
    }
}
