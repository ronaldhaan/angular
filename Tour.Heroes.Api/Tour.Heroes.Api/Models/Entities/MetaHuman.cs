using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Tour.Heroes.Api.Models.Entities.LinkEntities;

namespace Tour.Heroes.Api.Models.Entities
{
    public enum Status
    {
        Hero,
        Villain,
        AntiHero
    }

    public class MetaHuman : BaseEntity, ITourEntityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; } 

        public IEnumerable<MetaHumanAbility> MetaHumanAbilities { get; set; }

        public IEnumerable<MetaHumanTeam> MetaHumanTeams { get; set; }
    }
}
