using AutoMapper;
using RunningActivity.API.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Tests.Controllers
{
    public  abstract class BaseControllerTest
    {
        protected static IMapper _mapper;
        protected BaseControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new UsersMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
