using System.Linq;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.ViewModels;

namespace Tour.Heroes.Api.Helpers
{
    public class ViewModelHelper
    {
        public static MetaHumanViewModel BuildMetaViewModel(MetaHuman metaHuman, bool addRelations = false)
        {
            var viewmodel = new MetaHumanViewModel
            {
                Id = metaHuman.Id,
                Name = metaHuman.Name,
                Description = metaHuman.Description,
                AlterEgo = metaHuman.AlterEgo,
                Status = metaHuman.Status
            };

            if(addRelations)
            {
                viewmodel.Abilities = metaHuman.MetaHumanAbilities.Select(x => BuildAbilityViewModel(x.Ability));
                viewmodel.Teams = metaHuman.MetaHumanTeams.Select(x => BuildTeamViewModel(x.Team));
            }

            return viewmodel;
        }

        public static TeamViewModel BuildTeamViewModel(Team team, bool addRelations = false)
        {
            var viewmodel = new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description
            };

            if (addRelations)
            {
                viewmodel.MetaHumans = team.MetaHumanTeams.Select(y => BuildMetaViewModel(y.MetaHuman));
            }

            return viewmodel;
        }

        public static AbilityViewModel BuildAbilityViewModel(Ability ability, bool addRelations = false)
        {
            var viewmodel = new AbilityViewModel
            {
                Id = ability.Id,
                Name = ability.Name,
                Description = ability.Description
            };

            if(addRelations)
            {
                viewmodel.MetaHumans = ability.MetaHumanAbilities.Select(y => BuildMetaViewModel(y.MetaHuman));
            }

            return viewmodel;
        }        
    }
}