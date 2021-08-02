using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PolarPandaWebAPI.Controllers
{
    
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class GetLatestNewsController : ControllerBase
    {

        private readonly ILogger<GetLatestNewsController> _logger;

        public GetLatestNewsController(ILogger<GetLatestNewsController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet()]
       public NewsInfo Get()
{        DBSystem db = new DBSystem();
            db.OpenConnection();
            NewsInfo newsResult = db.GetNewsInfo();
            db.CloseConnection();
        return newsResult;
}
 

    }
}
