using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Tour.Heroes.Api.Models.ViewModels
{
    public class TeamViewModel : IEntityViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("metahumans")]
        public IEnumerable<MetaHumanViewModel> MetaHumans { get; set; }
    }
}