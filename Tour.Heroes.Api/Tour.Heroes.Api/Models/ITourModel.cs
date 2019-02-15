using System;

namespace Tour.Heroes.Api.Models
{
    public interface ITourModel
    {
        DateTimeOffset CreateAt { get; }
        DateTimeOffset UpdatedAt { get; set; }
    }
}
