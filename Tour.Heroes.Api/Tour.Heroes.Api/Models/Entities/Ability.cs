using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tour.Heroes.Api.Models.Entities.LinkEntities;

namespace Tour.Heroes.Api.Models.Entities
{
    public class Ability : BaseEntity, ITourEntityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<MetaHumanAbility> MetaHumanAbilities { get; set; }
    }
}