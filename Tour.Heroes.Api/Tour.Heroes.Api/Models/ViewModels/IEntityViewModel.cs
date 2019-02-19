using System;

namespace Tour.Heroes.Api.Models.ViewModels
{
    public interface IEntityViewModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }

    }
}