using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Models
{
    public interface ITourModel
    {
        DateTime CreateAt { get; }
        DateTime UpdatedAt { get; set; }
    }
}
