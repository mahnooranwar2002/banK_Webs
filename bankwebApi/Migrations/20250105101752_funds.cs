using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankwebApi.Migrations
{
    /// <inheritdoc />
    public partial class funds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_funds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fund_amount = table.Column<int>(type: "int", nullable: false),
                    massage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_funds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_funds");
        }
    }
}
