using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class mymigrationsssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "iid",
                table: "tbl_Acctypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "i_d",
                table: "tbl_accounts",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "types_id",
                table: "tbl_accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbl_Acctypes",
                newName: "iid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbl_accounts",
                newName: "i_d");

            migrationBuilder.AlterColumn<int>(
                name: "types_id",
                table: "tbl_accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
