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
    public class GetUserInfoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GetUserGoldController> _logger;

        public GetUserInfoController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IEnumerable<GetUserInfo> Get(int id)
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            GetUserInfo result = db.GetUserInfo(id);
            db.CloseConnection();
           var rng = new Random();
           
            return Enumerable.Range(1, 1).Select(index => new GetUserInfo
            {
                twitchID = result.twitchID,
                displayName = result.displayName,
                avatarURL = result.avatarURL,
                gold = result.gold
            })
            .ToArray();
        }
    }
}
