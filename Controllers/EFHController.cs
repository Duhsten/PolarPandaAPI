using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;


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
        public String status(int id)
        {
           string text = System.IO.File.ReadAllText(@"access");
           if(text.Contains("1"))
           {
               Console.WriteLine("Access is set to True!");
              return "true"; 
           }
           else if(text.Contains("2"))
           {
               Console.WriteLine("Access is set to Locked!");
              return "lock"; 
           }
           else
           {
               Console.WriteLine("Access is Offline!");
               return "false"; 
           }
            
        }
   
    }
}
