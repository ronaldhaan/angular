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
                name: "Team",
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
                    table.PrimaryKey("PK_Team", x => x.Id);
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
                name: "MetaHumanTeam",
                columns: table => new
                {
                    CreateAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    MetaHumanId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaHumanTeam", x => new { x.MetaHumanId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MetaHumanTeam_Metahumans_MetaHumanId",
                        column: x => x.MetaHumanId,
                        principalTable: "Metahumans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaHumanTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11165284-804b-4c0d-a883-7f4ff0591abf"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized in combat", "Martial Arts", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c7070eff-84b5-48f5-afcf-52af20ad33ed"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Speaks for itself", "Super strength", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("fe0b8931-219c-4403-bfda-0a84bca23780"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Super fast for its opponent, but for it feels normal for the speedster", "Super speed", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("30de4a7c-33fe-4434-8aac-722824079ff0"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized with a sword", "Swordsmaster", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("be3cc731-8b26-422d-ae18-d0c0b80a1a0a"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Speaks for itself", "Marmot de graaf", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("04ef9f14-88f2-498d-a9df-2bb917bef473"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Super fast for its opponent, but for it feels normal for the speedster", "harinak", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("697715c6-2cce-4334-820f-e26a2a237f77"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized with a sword", "haha", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("434ad3d8-560b-4a29-91ca-617df5f31172"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Overthrows his opponent with spells", "Magic", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Metahumans",
                columns: new[] { "Id", "AlterEgo", "CreateAt", "Description", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("eaee7287-5ed3-4106-9825-c8dcb992bdf4"), "None", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Twisted duplicate of Superman created from a Duplication Ray By Lex On Earth", "Bizarro", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a41576a7-93f4-4cb1-a75e-9e479313ab8e"), "David Hyde", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Deep sea diver and would-be ocean conquero", "Black Manta", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d29f79d9-8c7d-43fc-9dea-4d9ab5ef843d"), "Vril dox", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Evil alien android", "Brainiac", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5c9ecda1-827b-4a8d-9735-9f795174cb3d"), "Leonard Snart", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Blue-suited master of low temperatures", "Captain Cold", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("35f1235c-5d30-4629-af24-c09463399960"), "Priscilla Rich", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cheetah suit-wearing woman", "Cheetah", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("546edb8d-36d8-41ac-81a7-cfb3aa2287c2"), "Edward Nygma", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Megalomaniacal exile from Gorilla City", "Riddler", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a92ac2b6-e7c1-409e-a7e0-b66b3c92a299"), "Grodd", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Megalomaniacal exile from Gorilla City", "Gorrilla Grodd", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0aa12c57-0531-48bd-b982-528c0b21dbb9"), "None", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mad scientist and founder/leader of the Legion of Doom", "Lex Luthor", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dc17e228-11f7-40dd-bca2-9260847b852d"), "Joh", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Martian Manhunter", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49869c5e-1bfe-4607-9665-28a6c9658ef0"), "Thaal Sinestro", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Renegade ex-Green Lantern", "Sinestro", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7f1b9c68-b577-468e-ab3a-abcc87fbb435"), "Doris Zeul", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Stole Apache Chief's magic powder to duplicate his powers", "Giganta", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a7ae6c62-b1c2-40c2-8e24-5892e39b2846"), "Hall Jordan", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Green Lantern", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18456bfd-6eb9-4e3b-93ab-bf0cc7bfa02b"), "Barry Allen", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "The Flash", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("1df18e4e-29e5-4cc9-8154-4f35075d3174"), "None", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "John Constantine", 2, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ed9711c-bf30-407d-9249-5b1df86fda44"), "Henry Allen", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Jay Garrick", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a22913e8-f3b2-431d-afd7-7519b270ec72"), "Diana Prince", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "WonderWoman", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18cd6af9-a795-45b6-8b1b-d41aa6129506"), "Clark Kent", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Superman", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a6bb855f-995d-4142-8a13-3db335e4282d"), "Bruce Wayne", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Batman", 0, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b51aa7aa-a68e-483f-937d-20f06fdfd3e7"), "None", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "General Zodd", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("726bf5c2-3f49-49fb-8f4d-e70e39a36337"), "", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Prometheus", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aa352f05-a919-4493-a993-30f34a719a19"), "", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Cicada", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da5554c5-d131-46bd-a1c7-8b00cf039301"), "Eobard Thawne", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Reverse Flash", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("52784edc-d956-4e02-b707-0deff12cf8e1"), "None", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Darkseid", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("443abc75-d1bd-4389-b9ec-1a20f0e0e967"), "", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Deathstroke", 1, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 451, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bfecce09-fcd0-48f1-b910-4acafe105fcd"), "", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", "Deadpool", 2, new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Legion of Doom", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Justice League", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cd0a17f0-b7e7-43d5-85c4-41218c56ddce"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avengers", new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "MetaHumanTeam",
                columns: new[] { "MetaHumanId", "TeamId", "CreateAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a6bb855f-995d-4142-8a13-3db335e4282d"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("0aa12c57-0531-48bd-b982-528c0b21dbb9"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a92ac2b6-e7c1-409e-a7e0-b66b3c92a299"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("7f1b9c68-b577-468e-ab3a-abcc87fbb435"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("35f1235c-5d30-4629-af24-c09463399960"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5c9ecda1-827b-4a8d-9735-9f795174cb3d"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d29f79d9-8c7d-43fc-9dea-4d9ab5ef843d"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a41576a7-93f4-4cb1-a75e-9e479313ab8e"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("eaee7287-5ed3-4106-9825-c8dcb992bdf4"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("dc17e228-11f7-40dd-bca2-9260847b852d"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a7ae6c62-b1c2-40c2-8e24-5892e39b2846"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18456bfd-6eb9-4e3b-93ab-bf0cc7bfa02b"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a22913e8-f3b2-431d-afd7-7519b270ec72"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18cd6af9-a795-45b6-8b1b-d41aa6129506"), new Guid("a304e3f7-7cb7-4657-a7bf-4dac3bd7c822"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("546edb8d-36d8-41ac-81a7-cfb3aa2287c2"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("49869c5e-1bfe-4607-9665-28a6c9658ef0"), new Guid("449e7ff9-27fe-4ce0-8d6f-f68e0a362912"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "MetahumansAbilities",
                columns: new[] { "MetaHumanId", "AbilityId", "CreateAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1df18e4e-29e5-4cc9-8154-4f35075d3174"), new Guid("434ad3d8-560b-4a29-91ca-617df5f31172"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("6ed9711c-bf30-407d-9249-5b1df86fda44"), new Guid("be3cc731-8b26-422d-ae18-d0c0b80a1a0a"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18456bfd-6eb9-4e3b-93ab-bf0cc7bfa02b"), new Guid("11165284-804b-4c0d-a883-7f4ff0591abf"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a22913e8-f3b2-431d-afd7-7519b270ec72"), new Guid("fe0b8931-219c-4403-bfda-0a84bca23780"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("18cd6af9-a795-45b6-8b1b-d41aa6129506"), new Guid("c7070eff-84b5-48f5-afcf-52af20ad33ed"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a6bb855f-995d-4142-8a13-3db335e4282d"), new Guid("be3cc731-8b26-422d-ae18-d0c0b80a1a0a"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("726bf5c2-3f49-49fb-8f4d-e70e39a36337"), new Guid("697715c6-2cce-4334-820f-e26a2a237f77"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("726bf5c2-3f49-49fb-8f4d-e70e39a36337"), new Guid("04ef9f14-88f2-498d-a9df-2bb917bef473"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("726bf5c2-3f49-49fb-8f4d-e70e39a36337"), new Guid("fe0b8931-219c-4403-bfda-0a84bca23780"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("aa352f05-a919-4493-a993-30f34a719a19"), new Guid("fe0b8931-219c-4403-bfda-0a84bca23780"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da5554c5-d131-46bd-a1c7-8b00cf039301"), new Guid("be3cc731-8b26-422d-ae18-d0c0b80a1a0a"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("da5554c5-d131-46bd-a1c7-8b00cf039301"), new Guid("30de4a7c-33fe-4434-8aac-722824079ff0"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("52784edc-d956-4e02-b707-0deff12cf8e1"), new Guid("c7070eff-84b5-48f5-afcf-52af20ad33ed"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("bfecce09-fcd0-48f1-b910-4acafe105fcd"), new Guid("30de4a7c-33fe-4434-8aac-722824079ff0"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("443abc75-d1bd-4389-b9ec-1a20f0e0e967"), new Guid("11165284-804b-4c0d-a883-7f4ff0591abf"), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 14, 14, 42, 41, 452, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetahumansAbilities_AbilityId",
                table: "MetahumansAbilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaHumanTeam_TeamId",
                table: "MetaHumanTeam",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetahumansAbilities");

            migrationBuilder.DropTable(
                name: "MetaHumanTeam");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Metahumans");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
