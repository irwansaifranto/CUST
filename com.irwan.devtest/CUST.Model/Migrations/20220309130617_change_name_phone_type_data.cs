using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CUST.Model.Migrations
{
    public partial class change_name_phone_type_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<int>(type: "bigint", nullable: false, maxLength: 20)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Customers");
        }
    }
}
