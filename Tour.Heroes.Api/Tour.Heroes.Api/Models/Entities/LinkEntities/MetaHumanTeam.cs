using System;

namespace Tour.Heroes.Api.Models.Entities.LinkEntities
{
    public class MetaHumanTeam : BaseEntity, ITourLinkModel
    {
        public Guid MetaHumanId { get; set; }
        public MetaHuman MetaHuman { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
