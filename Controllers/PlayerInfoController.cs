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
    public class PlayerInfoController : ControllerBase
    {

        private readonly ILogger<GetUserGoldController> _logger;

        public PlayerInfoController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }

        [HttpGet("id/{id}")]
        public Object Get(int id)
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            Player result = db.GetUserInfo(id);
            db.CloseConnection();
            if(result.twitchID == 0)
            {
                return "Invalid ID";
            }          
           else
           {
                return result;
           }
            
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
