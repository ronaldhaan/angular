using System;

namespace Tour.Heroes.Api.Models.Entities
{
    public class BaseEntity : ITourModel
    {
        public BaseEntity()
        {
            CreateAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset CreateAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}