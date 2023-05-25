using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.Repo.Migrations
{
    public partial class isDeductionAddedInFundTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeduction",
                table: "Funds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeduction",
                table: "Funds");
        }
    }
}
