using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PolarPandaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPlayerInfoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GetUserGoldController> _logger;

        public GetPlayerInfoController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public GetPlayerInfo Get(int id)
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            GetPlayerInfo result = db.GetUserInfo(id);
            db.CloseConnection();
          
           
            return result;
        }
    }
}
