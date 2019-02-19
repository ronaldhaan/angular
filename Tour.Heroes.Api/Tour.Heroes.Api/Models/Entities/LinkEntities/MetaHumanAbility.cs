using System;

namespace Tour.Heroes.Api.Models.Entities.LinkEntities
{
    public class MetaHumanAbility : BaseEntity, ITourLinkModel
    {
        public Guid MetaHumanId { get; set; }
        public MetaHuman MetaHuman { get; set; }

        public Guid AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
