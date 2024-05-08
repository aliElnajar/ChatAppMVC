using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatLab.Migrations
{
    /// <inheritdoc />
    public partial class addingGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "groupname",
                table: "chatmessage",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "groupname",
                table: "chatmessage");
        }
    }
}
