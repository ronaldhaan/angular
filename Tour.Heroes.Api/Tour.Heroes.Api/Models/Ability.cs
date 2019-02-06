using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour.Heroes.Api.Models
{
    public class Ability : ITourModel
    {
    //    public Ability()
    //    {
    //        this.Heroes = new HashSet<Hero>();
    //    }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<HeroAbilities> HeroesAbilities { get; set; }
    }
}