using Microsoft.EntityFrameworkCore.Migrations;

namespace GatewayApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "GSMGateways",
                columns: table => new
                {
                    Ip = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    Password = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSMGateways", x => x.Ip);
                    table.ForeignKey(
                        name: "FK_GSMGateways_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GSMGateways_ProviderId",
                table: "GSMGateways",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GSMGateways");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
