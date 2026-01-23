using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholesaleShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCustmerModleThatDeletPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "BCrypt/PBKDF2 hash. Never store raw passwords.");
        }
    }
}
