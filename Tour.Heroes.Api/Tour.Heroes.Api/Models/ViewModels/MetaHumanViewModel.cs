using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tour.Heroes.Api.Models.Entities;

namespace Tour.Heroes.Api.Models.ViewModels
{
    public class MetaHumanViewModel : IEntityViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        [JsonProperty("abilities")]
        public IEnumerable<AbilityViewModel> Abilities { get; set; }

        [JsonProperty("teams")]
        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}
