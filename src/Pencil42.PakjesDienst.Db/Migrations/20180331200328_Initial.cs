using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pencil42.PakjesDienst.Db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pakjes",
                columns: table => new
                {
                    PakjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bestemmeling = table.Column<string>(nullable: true),
                    GeleverdOp = table.Column<DateTime>(nullable: true),
                    Inhoud = table.Column<string>(nullable: true),
                    KoerierDienst = table.Column<string>(nullable: true),
                    LeveringsStatus = table.Column<int>(nullable: false),
                    Verzender = table.Column<string>(nullable: true),
                    VoorzieneLeveringOp = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakjes", x => x.PakjeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pakjes");
        }
    }
}
