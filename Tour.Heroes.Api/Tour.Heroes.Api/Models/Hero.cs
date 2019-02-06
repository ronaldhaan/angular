using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models
{
    public class Hero : ITourModel
    {
        //public Hero()
        //{
        //    this.Abilities = new HashSet<Ability>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<HeroAbilities> AbilitiesHeroes { get; set; }
    }
}
