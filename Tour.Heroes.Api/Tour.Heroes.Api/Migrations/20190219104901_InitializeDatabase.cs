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
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metahumans",
                columns: table => new
                {
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AlterEgo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metahumans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetahumansAbilities",
                columns: table => new
                {
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    MetaHumanId = table.Column<Guid>(nullable: false),
                    AbilityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetahumansAbilities", x => new { x.MetaHumanId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_MetahumansAbilities_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetahumansAbilities_Metahumans_MetaHumanId",
                        column: x => x.MetaHumanId,
                        principalTable: "Metahumans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaHumanTeams",
                columns: table => new
                {
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    MetaHumanId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaHumanTeams", x => new { x.MetaHumanId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MetaHumanTeams_Metahumans_MetaHumanId",
                        column: x => x.MetaHumanId,
                        principalTable: "Metahumans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaHumanTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("208da2a6-fcda-4857-aaf4-23bd8b14229d"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 765, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized in combat", "Martial Arts", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 765, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d9f54e4d-a218-4ac4-9572-2545d61adda8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Speaks for itself", "Super strength", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("14cde9b8-045f-473d-92c6-2d9d2ad1930b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Super fast for its opponent, but for it feels normal for the speedster", "Super speed", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("adbacf3a-37a1-4211-9ffb-97b4b898c8e8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized with a sword", "Swordsmaster", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2f738fd1-a400-420b-b360-009e9bfccbef"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Speaks for itself", "Marmot de graaf", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18c9b872-5865-4279-9ffc-108d23b956df"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Super fast for its opponent, but for it feels normal for the speedster", "harinak", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0004be42-cb00-4f3d-9f4c-f69bc3b46ebb"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized with a sword", "haha", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("632c7c6f-16ff-498f-bbe1-bbe0f037f4d7"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Overthrows his opponent with spells", "Magic", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Metahumans",
                columns: new[] { "Id", "AlterEgo", "CreateAt", "Description", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7c19d2b9-d4cf-4182-988d-616b2f308518"), "None", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Twisted duplicate of Superman created from a Duplication Ray By Lex On Earth", "Bizarro", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b24205f9-43f7-4cf3-a422-1bfc01a1ef0f"), "David Hyde", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Deep sea diver and would-be ocean conquero", "Black Manta", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ed77765b-0b94-4cf5-bc49-0c6be4f628b6"), "Vril dox", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Evil alien android", "Brainiac", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("15d336cc-5318-4031-b80d-680fb2161b9b"), "Leonard Snart", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Blue-suited master of low temperatures", "Captain Cold", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3a919c57-c6d4-419b-8d6a-6a0f8596ec14"), "Priscilla Rich", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cheetah suit-wearing woman", "Cheetah", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("37480978-498e-49b0-bc8e-47ac2764b223"), "Edward Nygma", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Megalomaniacal exile from Gorilla City", "Riddler", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8b9fd4f-d62f-4358-8cf3-a34e43812fa6"), "Grodd", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Megalomaniacal exile from Gorilla City", "Gorrilla Grodd", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cd36b2ef-1ad5-4e36-8968-7d263a7fdae3"), "None", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mad scientist and founder/leader of the Legion of Doom", "Lex Luthor", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4746b9f8-ed25-4add-b99c-e4ad1d1e28c6"), "Joh", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Martian Manhunter", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d2cd1117-1e96-41e2-9167-7291db001c56"), "Thaal Sinestro", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Renegade ex-Green Lantern", "Sinestro", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5c04a440-45a6-4ba3-b31f-fc44777fd20e"), "Doris Zeul", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stole Apache Chief's magic powder to duplicate his powers", "Giganta", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("20b23a0a-242f-4a0f-ad59-93ced35b3cce"), "Hall Jordan", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Green Lantern", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99201ef5-9e88-4f77-b2c9-d55bf844d1b2"), "Barry Allen", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "The Flash", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("442915a0-e192-4cd2-8800-eac1cd034383"), "None", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "John Constantine", 2, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0e4cb48e-fba4-48f1-925c-c396d49ee913"), "Henry Allen", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Jay Garrick", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f5c868ae-da99-41ed-96a3-39a85e53fcb3"), "Diana Prince", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "WonderWoman", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb0843de-7393-4686-88ea-4c6f80b12a47"), "Clark Kent", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Superman", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2114c11d-fa71-4f95-8725-90bd699694cf"), "Bruce Wayne", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Batman", 0, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("65490a5b-bb49-4721-b442-90e39b64ceb6"), "None", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "General Zodd", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d478bc91-5c51-4438-80bc-891f420a2d06"), "", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Prometheus", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("21ecf9ee-4fbd-4689-8251-2d6797c3acbe"), "", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Cicada", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7abbc069-155f-4399-a0fa-fb519b731824"), "Eobard Thawne", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Reverse Flash", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("07488ec0-9066-46bb-bef9-53151b278de6"), "None", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Darkseid", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("87f2ad97-b3a2-4996-9f93-fb756feeb374"), "", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Deathstroke", 1, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4e9c9def-ca75-4ff2-8fa8-c20e0d4a734a"), "", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Deadpool", 2, new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Legion of Doom", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Justice League", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b50e6562-7b62-4002-93a2-ef4e4f699318"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avengers", new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "MetaHumanTeams",
                columns: new[] { "MetaHumanId", "TeamId", "CreateAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2114c11d-fa71-4f95-8725-90bd699694cf"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cd36b2ef-1ad5-4e36-8968-7d263a7fdae3"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8b9fd4f-d62f-4358-8cf3-a34e43812fa6"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5c04a440-45a6-4ba3-b31f-fc44777fd20e"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("3a919c57-c6d4-419b-8d6a-6a0f8596ec14"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("15d336cc-5318-4031-b80d-680fb2161b9b"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ed77765b-0b94-4cf5-bc49-0c6be4f628b6"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b24205f9-43f7-4cf3-a422-1bfc01a1ef0f"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7c19d2b9-d4cf-4182-988d-616b2f308518"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4746b9f8-ed25-4add-b99c-e4ad1d1e28c6"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("20b23a0a-242f-4a0f-ad59-93ced35b3cce"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99201ef5-9e88-4f77-b2c9-d55bf844d1b2"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f5c868ae-da99-41ed-96a3-39a85e53fcb3"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb0843de-7393-4686-88ea-4c6f80b12a47"), new Guid("d8550cf0-3743-4afa-8530-49a85398cb49"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("37480978-498e-49b0-bc8e-47ac2764b223"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d2cd1117-1e96-41e2-9167-7291db001c56"), new Guid("9ad1b2c3-5276-4b80-9995-ecb8bac1693b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "MetahumansAbilities",
                columns: new[] { "MetaHumanId", "AbilityId", "CreateAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("442915a0-e192-4cd2-8800-eac1cd034383"), new Guid("632c7c6f-16ff-498f-bbe1-bbe0f037f4d7"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0e4cb48e-fba4-48f1-925c-c396d49ee913"), new Guid("2f738fd1-a400-420b-b360-009e9bfccbef"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("99201ef5-9e88-4f77-b2c9-d55bf844d1b2"), new Guid("208da2a6-fcda-4857-aaf4-23bd8b14229d"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f5c868ae-da99-41ed-96a3-39a85e53fcb3"), new Guid("14cde9b8-045f-473d-92c6-2d9d2ad1930b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cb0843de-7393-4686-88ea-4c6f80b12a47"), new Guid("d9f54e4d-a218-4ac4-9572-2545d61adda8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("2114c11d-fa71-4f95-8725-90bd699694cf"), new Guid("2f738fd1-a400-420b-b360-009e9bfccbef"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d478bc91-5c51-4438-80bc-891f420a2d06"), new Guid("0004be42-cb00-4f3d-9f4c-f69bc3b46ebb"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d478bc91-5c51-4438-80bc-891f420a2d06"), new Guid("18c9b872-5865-4279-9ffc-108d23b956df"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d478bc91-5c51-4438-80bc-891f420a2d06"), new Guid("14cde9b8-045f-473d-92c6-2d9d2ad1930b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("21ecf9ee-4fbd-4689-8251-2d6797c3acbe"), new Guid("14cde9b8-045f-473d-92c6-2d9d2ad1930b"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7abbc069-155f-4399-a0fa-fb519b731824"), new Guid("2f738fd1-a400-420b-b360-009e9bfccbef"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7abbc069-155f-4399-a0fa-fb519b731824"), new Guid("adbacf3a-37a1-4211-9ffb-97b4b898c8e8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("07488ec0-9066-46bb-bef9-53151b278de6"), new Guid("d9f54e4d-a218-4ac4-9572-2545d61adda8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4e9c9def-ca75-4ff2-8fa8-c20e0d4a734a"), new Guid("adbacf3a-37a1-4211-9ffb-97b4b898c8e8"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 767, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("87f2ad97-b3a2-4996-9f93-fb756feeb374"), new Guid("208da2a6-fcda-4857-aaf4-23bd8b14229d"), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 19, 10, 49, 1, 766, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetahumansAbilities_AbilityId",
                table: "MetahumansAbilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaHumanTeams_TeamId",
                table: "MetaHumanTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetahumansAbilities");

            migrationBuilder.DropTable(
                name: "MetaHumanTeams");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Metahumans");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
