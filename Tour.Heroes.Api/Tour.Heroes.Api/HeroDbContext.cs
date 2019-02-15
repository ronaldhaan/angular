using Microsoft.EntityFrameworkCore;
using System;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.Entities.LinkEntities;

namespace Tour.Heroes.Api
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }
        //define tables.
        public DbSet<MetaHuman> Metahumans { get; set; }
        public DbSet<MetaHumanAbility> MetahumansAbilities { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // create a constraint primary key with the fields MetahumanId and AbilityId.
            modelBuilder.Entity<MetaHumanAbility>()
                .HasKey(x => new { x.MetaHumanId, x.AbilityId });

            modelBuilder.Entity<MetaHumanAbility>()
            // create a one to many relation between the metahuman table and the link table MetahumanAbility
                .HasOne(ha => ha.MetaHuman)
                .WithMany(h => h.MetaHumanAbilities)
            // set foreign key from the metahuman table to the link table MetahumanAbility.
                .HasForeignKey(ha => ha.MetaHumanId);

            modelBuilder.Entity<MetaHumanAbility>()
            // create a one to many relation between the ability table and the link table MetahumanAbility
                .HasOne(ha => ha.Ability)
                .WithMany(a => a.MetaHumanAbilities)
            // set foreign key from the metahuman table to the link table MetahumanAbility.
                .HasForeignKey(ha => ha.AbilityId);

            // create a constraint primary key with the fields MetahumanId and TeamId.
            modelBuilder.Entity<MetaHumanTeam>()
                .HasKey(x => new { x.MetaHumanId, x.TeamId });

            modelBuilder.Entity<MetaHumanTeam>()
            // create a one to many relation between the metahuman table and the link table MetahumanTeam
                .HasOne(mt => mt.MetaHuman)
                .WithMany(m => m.MetaHumanTeams)
            // set foreign key from the metahuman table to the link table MetahumanAbility.
                .HasForeignKey(ha => ha.MetaHumanId);

            modelBuilder.Entity<MetaHumanTeam>()
            // create a one to many relation between the team table and the link table MetahumanTeam
                .HasOne(mt => mt.Team)
                .WithMany(t => t.MetaHumanTeams)
            // set foreign key from the metahuman table to the link table MetahumanTeam.
                .HasForeignKey(ha => ha.TeamId);

            Ability[] abilities = 
            {
                new Ability { Id = Guid.NewGuid(), Name = "Martial Arts", Description = "Specialized in combat" },
                new Ability { Id = Guid.NewGuid(), Name = "Super strength", Description = "Speaks for itself" },
                new Ability { Id = Guid.NewGuid(), Name = "Super speed", Description = "Super fast for its opponent, but for it feels normal for the speedster" },
                new Ability { Id = Guid.NewGuid(), Name = "Swordsmaster", Description = "Specialized with a sword" },
                new Ability { Id = Guid.NewGuid(), Name = "Marmot de graaf", Description = "Speaks for itself" },
                new Ability { Id = Guid.NewGuid(), Name = "harinak", Description = "Super fast for its opponent, but for it feels normal for the speedster" },
                new Ability { Id = Guid.NewGuid(), Name = "haha", Description = "Specialized with a sword" },
                new Ability { Id = Guid.NewGuid(), Name = "Magic", Description= "Overthrows his opponent with spells" },
            };

            MetaHuman[] metahumans =
            {
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "",             Status = Status.Villain, Name="Deathstroke", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "None",         Status = Status.Villain, Name="Darkseid", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Eobard Thawne", Status = Status.Villain, Name="Reverse Flash", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "",             Status = Status.Villain, Name="Cicada", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "",             Status = Status.Villain, Name="Prometheus", Description = "" },

                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "None",         Status = Status.Villain, Name="General Zodd", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Bruce Wayne",  Status = Status.Hero,   Name = "Batman", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Clark Kent",   Status = Status.Hero,   Name = "Superman", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Diana Prince", Status = Status.Hero,   Name = "WonderWoman", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Barry Allen",  Status = Status.Hero,   Name = "The Flash", Description = "" },

                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Henry Allen",  Status = Status.Hero,       Name = "Jay Garrick", Description = "" },                                                     
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "None",         Status = Status.AntiHero,   Name = "John Constantine", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "",             Status = Status.AntiHero,   Name = "Deadpool", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Hall Jordan",  Status = Status.Hero,       Name = "Green Lantern", Description = "" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Joh",          Status = Status.Hero,       Name = "Martian Manhunter", Description = "" },
                                                     
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "None",             Status = Status.Villain, Name = "Bizarro", Description = "Twisted duplicate of Superman created from a Duplication Ray By Lex On Earth"},
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "David Hyde",       Status = Status.Villain, Name = "Black Manta", Description = "Deep sea diver and would-be ocean conquero" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Vril dox",         Status = Status.Villain, Name = "Brainiac", Description = "Evil alien android" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Leonard Snart",    Status = Status.Villain, Name = "Captain Cold", Description = "Blue-suited master of low temperatures" },
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Priscilla Rich",   Status = Status.Villain, Name = "Cheetah", Description = "Cheetah suit-wearing woman" },

                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Doris Zeul",       Status = Status.Villain, Name = "Giganta", Description = "Stole Apache Chief's magic powder to duplicate his powers"},
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Grodd",            Status = Status.Villain, Name = "Gorrilla Grodd", Description = "Megalomaniacal exile from Gorilla City"},
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "None",             Status = Status.Villain, Name = "Lex Luthor", Description = "Mad scientist and founder/leader of the Legion of Doom"},
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Edward Nygma",     Status = Status.Villain, Name = "Riddler", Description = "Megalomaniacal exile from Gorilla City"},
                new MetaHuman { Id = Guid.NewGuid(), AlterEgo = "Thaal Sinestro",     Status = Status.Villain, Name = "Sinestro", Description = "Renegade ex-Green Lantern"},
                
            };

            Team[] teams =
            {
                new Team { Id = Guid.NewGuid(), Name = "Justice League"},
                new Team { Id = Guid.NewGuid(), Name = "Legion of Doom"},
                new Team { Id = Guid.NewGuid(), Name = "Avengers"},
            };

            MetaHumanTeam[] metaHumanTeams =
            {
                // justice league
                new MetaHumanTeam { MetaHumanId = metahumans[6].Id, TeamId = teams[0].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[7].Id, TeamId = teams[0].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[8].Id, TeamId = teams[0].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[9].Id, TeamId = teams[0].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[13].Id, TeamId = teams[0].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[14].Id, TeamId = teams[0].Id },

                // legion of doom                
                new MetaHumanTeam { MetaHumanId = metahumans[15].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[16].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[17].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[18].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[19].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[20].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[21].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[22].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[23].Id, TeamId = teams[1].Id },
                new MetaHumanTeam { MetaHumanId = metahumans[24].Id, TeamId = teams[1].Id },


            };

            MetaHumanAbility[] MetahumanAbilities = {
                new MetaHumanAbility { MetaHumanId = metahumans[0].Id, AbilityId = abilities[0].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[1].Id, AbilityId = abilities[1].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[2].Id, AbilityId = abilities[3].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[3].Id, AbilityId = abilities[2].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[4].Id, AbilityId = abilities[2].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[2].Id, AbilityId = abilities[4].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[4].Id, AbilityId = abilities[5].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[4].Id, AbilityId = abilities[6].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[6].Id, AbilityId = abilities[4].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[7].Id, AbilityId = abilities[1].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[8].Id, AbilityId = abilities[2].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[9].Id, AbilityId = abilities[0].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[10].Id, AbilityId = abilities[4].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[11].Id, AbilityId = abilities[7].Id },
                new MetaHumanAbility { MetaHumanId = metahumans[12].Id, AbilityId = abilities[3].Id },
            };

            modelBuilder
                .Entity<Ability>()
                .HasData(abilities);

            modelBuilder
                .Entity<MetaHuman>()
                .HasData(metahumans);
            
            modelBuilder
                .Entity<Team>()
                .HasData(teams);

            modelBuilder
                .Entity<MetaHumanAbility>()
                .HasData(MetahumanAbilities);

            modelBuilder
                .Entity<MetaHumanTeam>()
                .HasData(metaHumanTeams);

        }

        public DbSet<Tour.Heroes.Api.Models.Entities.Team> Team { get; set; }

        public DbSet<Tour.Heroes.Api.Models.Entities.LinkEntities.MetaHumanTeam> MetaHumanTeam { get; set; }
    }
}
