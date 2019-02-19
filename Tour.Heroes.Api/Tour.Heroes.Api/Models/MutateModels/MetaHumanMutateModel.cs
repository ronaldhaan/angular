using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Models.MutateModels
{
    public class MetaHumanMutateModel : BaseMutateModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AlterEgo { get; set; }

        public Status Status { get; set; }
    }
}
