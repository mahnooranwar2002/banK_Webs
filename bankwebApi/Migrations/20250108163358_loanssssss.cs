using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class loanssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "number",
                table: "tbl_loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "tbl_loans");
        }
    }
}
