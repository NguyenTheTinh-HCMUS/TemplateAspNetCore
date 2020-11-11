using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static Web1.MappingProfiles.DoamainToResponseProfile;

namespace Web1.Controllers
{
    public class TestController : Controller
    {
        #region Injector
        private readonly IMapper _map;
        #endregion
        public TestController(IMapper mapper)
        {
            _map = mapper;

        }
        [HttpGet("api/test")]
        public IActionResult Test()
        {
            
            return Ok(new { 
            test="test"
            });

        }
    }
}
