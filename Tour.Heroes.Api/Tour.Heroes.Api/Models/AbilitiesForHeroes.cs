using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models
{
    public class HeroAbilities
    {
        public Guid HeroId { get; set; }
        public Hero Hero { get; set; }

        public Guid AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
