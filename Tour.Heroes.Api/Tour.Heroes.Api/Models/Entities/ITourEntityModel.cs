using System;

namespace Tour.Heroes.Api.Models.Entities
{
    public interface ITourEntityModel : ITourModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}