using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Tour.Heroes.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
