using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tour.Heroes.Api.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroAbilities",
                columns: table => new
                {
                    HeroId = table.Column<Guid>(nullable: false),
                    AbilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroAbilities", x => new { x.HeroId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_HeroAbilities_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroAbilities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("e8d8f446-131f-456f-9031-0f36eec37d95"), "Specialized in combat", "Martial Arts" },
                    { new Guid("46cc7990-e44f-4b5d-9436-7c0b55b71f76"), "Speaks for itself", "Super strength" },
                    { new Guid("a2105d1e-7a93-4152-aa54-d7adcb7147b5"), "Super fast for its opponent, but for it feels normal for the speedster", "Super speed" },
                    { new Guid("79ee5b6d-bf67-4ce3-b315-bda73879a854"), "Specialized with a sword", "Swordsmaster" },
                    { new Guid("dbe15c06-3c00-48bd-9358-9a130408351d"), "Speaks for itself", "Marmot de graaf" },
                    { new Guid("5b1f4217-1b6c-4a5a-8090-9d88b5efcdc8"), "Super fast for its opponent, but for it feels normal for the speedster", "harinak" },
                    { new Guid("95d99eab-93f8-4eb4-bce8-a1296e757bc8"), "Specialized with a sword", "haha" }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("170f3b78-7267-49ed-a44d-bce86ccb9d60"), "Batman" },
                    { new Guid("708d8976-a5c8-4afa-bcb3-ba2d93f913e3"), "Superman" },
                    { new Guid("f063751e-604e-42b5-b0bb-202fff920239"), "WonderWoman" },
                    { new Guid("17cf5e2e-2417-412f-bf01-f66f978c5f68"), "The Flash" },
                    { new Guid("2df360a7-8691-4316-8283-21b997a5d241"), "Jay Garrick" }
                });

            migrationBuilder.InsertData(
                table: "HeroAbilities",
                columns: new[] { "HeroId", "AbilityId" },
                values: new object[,]
                {
                    { new Guid("170f3b78-7267-49ed-a44d-bce86ccb9d60"), new Guid("e8d8f446-131f-456f-9031-0f36eec37d95") },
                    { new Guid("708d8976-a5c8-4afa-bcb3-ba2d93f913e3"), new Guid("46cc7990-e44f-4b5d-9436-7c0b55b71f76") },
                    { new Guid("f063751e-604e-42b5-b0bb-202fff920239"), new Guid("79ee5b6d-bf67-4ce3-b315-bda73879a854") },
                    { new Guid("f063751e-604e-42b5-b0bb-202fff920239"), new Guid("dbe15c06-3c00-48bd-9358-9a130408351d") },
                    { new Guid("17cf5e2e-2417-412f-bf01-f66f978c5f68"), new Guid("a2105d1e-7a93-4152-aa54-d7adcb7147b5") },
                    { new Guid("2df360a7-8691-4316-8283-21b997a5d241"), new Guid("a2105d1e-7a93-4152-aa54-d7adcb7147b5") },
                    { new Guid("2df360a7-8691-4316-8283-21b997a5d241"), new Guid("5b1f4217-1b6c-4a5a-8090-9d88b5efcdc8") },
                    { new Guid("2df360a7-8691-4316-8283-21b997a5d241"), new Guid("95d99eab-93f8-4eb4-bce8-a1296e757bc8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroAbilities_AbilityId",
                table: "HeroAbilities",
                column: "AbilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroAbilities");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
