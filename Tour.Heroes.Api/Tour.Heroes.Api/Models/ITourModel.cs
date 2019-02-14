using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models
{
    public interface ITourModel
    {
        DateTimeOffset CreateAt { get; }
        DateTimeOffset UpdatedAt { get; set; }
    }
}
