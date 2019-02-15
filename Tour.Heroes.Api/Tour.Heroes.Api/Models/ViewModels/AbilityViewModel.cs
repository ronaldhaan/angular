using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour.Heroes.Api.Models.ViewModels
{
    public class AbilityViewModel : IEntityViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("metahumans")]
        public IEnumerable<MetaHumanViewModel> MetaHumans { get; set; }
    }
}
