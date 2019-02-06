using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models;

namespace Tour.Heroes.Api
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }
        //define tables.
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<HeroAbilities> HeroAbilities { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // create a constraint primary key with the fields HeroId and AbilityId.
            modelBuilder.Entity<HeroAbilities>()
                .HasKey(ha => new { ha.HeroId, ha.AbilityId });

            modelBuilder.Entity<HeroAbilities>()
            // create a one to many relation between the hero table and the link table HeroAbilities
                .HasOne(ha => ha.Hero)
                .WithMany(h => h.AbilitiesHeroes)
            // set foreign key from the hero table to the link table HeroAbilities.
                .HasForeignKey(ha => ha.HeroId);

            modelBuilder.Entity<HeroAbilities>()
            // create a one to many relation between the ability table and the link table HeroAbilities
                .HasOne(ha => ha.Ability)
                .WithMany(a => a.HeroesAbilities)
            // set foreign key from the hero table to the link table HeroAbilities.
                .HasForeignKey(ha => ha.AbilityId);

            Ability ability0 = new Ability { Id = Guid.NewGuid(), Name = "Martial Arts", Description = "Specialized in combat" };
            Ability ability1 = new Ability { Id = Guid.NewGuid(), Name = "Super strength", Description = "Speaks for itself" };
            Ability ability2 = new Ability { Id = Guid.NewGuid(), Name = "Super speed", Description = "Super fast for its opponent, but for it feels normal for the speedster" };
            Ability ability3 = new Ability { Id = Guid.NewGuid(), Name = "Swordsmaster", Description = "Specialized with a sword" };
            Ability ability4 = new Ability { Id = Guid.NewGuid(), Name = "Marmot de graaf", Description = "Speaks for itself" };
            Ability ability5 = new Ability { Id = Guid.NewGuid(), Name = "harinak", Description = "Super fast for its opponent, but for it feels normal for the speedster" };
            Ability ability6 = new Ability { Id = Guid.NewGuid(), Name = "haha", Description = "Specialized with a sword" };

            Hero hero0 = new Hero { Id = Guid.NewGuid(), Name = "Batman" };
            Hero hero1 = new Hero { Id = Guid.NewGuid(), Name = "Superman" };
            Hero hero2 = new Hero { Id = Guid.NewGuid(), Name = "WonderWoman" };
            Hero hero3 = new Hero { Id = Guid.NewGuid(), Name = "The Flash" };
            Hero hero4 = new Hero { Id = Guid.NewGuid(), Name = "Jay Garrick" };

            HeroAbilities ha0 = new HeroAbilities { HeroId = hero0.Id, AbilityId = ability0.Id };
            HeroAbilities ha1 = new HeroAbilities { HeroId = hero1.Id, AbilityId = ability1.Id};
            HeroAbilities ha2 = new HeroAbilities { HeroId = hero2.Id, AbilityId = ability3.Id };
            HeroAbilities ha3 = new HeroAbilities { HeroId = hero3.Id, AbilityId = ability2.Id };
            HeroAbilities ha4 = new HeroAbilities { HeroId = hero4.Id, AbilityId = ability2.Id };
            HeroAbilities ha5 = new HeroAbilities { HeroId = hero2.Id, AbilityId = ability4.Id };
            HeroAbilities ha6 = new HeroAbilities { HeroId = hero4.Id , AbilityId = ability5.Id};
            HeroAbilities ha7 = new HeroAbilities { HeroId = hero4.Id, AbilityId = ability6.Id };

            modelBuilder
                .Entity<Ability>()
                .HasData(
                     ability0,
                     ability1,
                     ability2,
                     ability3,
                     ability4,
                     ability5,
                     ability6
                 );

            modelBuilder
                .Entity<Hero>()
                .HasData(
                       hero0,
                       hero1,
                       hero2,
                       hero3,
                       hero4
                    );

            modelBuilder.Entity<HeroAbilities>().HasData(
                ha0,
                ha1,
                ha2,
                ha3,
                ha4,
                ha5,
                ha6,
                ha7
            );
        }
    }
}
