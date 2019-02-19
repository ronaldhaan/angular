using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models.MutateModels
{
    public class TeamMutateModel : BaseMutateModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
