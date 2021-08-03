using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolarPandaAPI;

namespace PolarPandaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameManagerController : ControllerBase
    {

        private readonly ILogger<GetUserGoldController> _logger;

        public GameManagerController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{result}")]
        public Object Get(string result)
        {
            GameManager gm = new GameManager();
            if (result == "")
            {
            
            return gm;
            }
            else if (result == "status")
            {
                return gm.status;
            }
            else if ( result == "currentgame")
            {
                return gm.currentGame;
            }
            else
            {
                return "Unknown Result";
            }
            
        }
    }
}
