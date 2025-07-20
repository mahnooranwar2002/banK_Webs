using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class mymigrationssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_accounts_tbl_Acctypes_types_id",
                table: "tbl_accounts");

            migrationBuilder.DropIndex(
                name: "IX_tbl_accounts_types_id",
                table: "tbl_accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_accounts_types_id",
                table: "tbl_accounts",
                column: "types_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_accounts_tbl_Acctypes_types_id",
                table: "tbl_accounts",
                column: "types_id",
                principalTable: "tbl_Acctypes",
                principalColumn: "iid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
