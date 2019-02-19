using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models.MutateModels
{
    public class BaseMutateModel
    {
        public BaseMutateModel()
        {
            this.UpdatedAt = DateTime.Now;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
