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
    public class ModifyPlayerInfoController : ControllerBase
    {

        private readonly ILogger<GetUserGoldController> _logger;

        public ModifyPlayerInfoController(ILogger<GetUserGoldController> logger)
        {
            _logger = logger;
        }

        [HttpPost("modify/")]
        public Object Post(Player playerInfo)
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            bool test = db.UpdateUserInfo(playerInfo);
            db.CloseConnection();
           if (test)
           {
              
           }
            Result result = new Result();
            result.id = 200;
            result.message = "Success";
             return result;
        }
    }
}
