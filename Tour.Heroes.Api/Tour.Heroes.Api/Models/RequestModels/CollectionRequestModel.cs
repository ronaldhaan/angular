using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models.RequestModels
{
    public class CollectionRequestModel
    {
        public int? AbilityCount { get; set; }

        public int? Skip { get; set; }

        public string Name { get; set; }

    }
}
