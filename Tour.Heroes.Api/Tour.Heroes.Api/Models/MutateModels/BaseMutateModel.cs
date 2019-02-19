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
            this.UpdatedAt = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
