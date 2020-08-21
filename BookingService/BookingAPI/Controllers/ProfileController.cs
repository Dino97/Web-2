using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetProfileName(int id)
        {
            return new string[] { "Dinulja", "Isus" }[id];
        }
    }
}
