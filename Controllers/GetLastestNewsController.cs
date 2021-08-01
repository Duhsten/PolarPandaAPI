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
    public class GetLatestNewsController : ControllerBase
    {

        private readonly ILogger<GetLatestNewsController> _logger;

        public GetLatestNewsController(ILogger<GetLatestNewsController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet()]
        public IEnumerable<NewsInfo> Get()
        {
            DBSystem db = new DBSystem();
            db.OpenConnection();
            NewsInfo newsResult = db.GetNewsInfo();
            db.CloseConnection();
           var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new NewsInfo
            {
                title = newsResult.title,
                content = newsResult.content,
                date = newsResult.date
                
                    
                
            })
            .ToArray();
        }
    }
}
