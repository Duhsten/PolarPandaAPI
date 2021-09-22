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
    public class EFHController : ControllerBase
    {

        private readonly ILogger<GetUserGoldController> _logger;

        public EFHController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }
        [HttpGet("check")]
        public bool status(int id)
        {
           return true;
            
        }

        [HttpPost]
        public Player Post(Player playerInfo)
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            bool test = db.UpdateUserInfo(playerInfo);
            db.CloseConnection();
           if (test)
           {
              
           }
             return playerInfo;
        }
    }
}
