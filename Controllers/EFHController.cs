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
using PolarPandaAPI;

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
        [HttpGet("files")]
        public Object f()
        {
            PolarPandaAPI.File f1 = new PolarPandaAPI.File()
            {
                id = 45654,
                fileName = "test",
                filePath = "/33/3//3",
                fileSize = 300
            };
            PolarPandaAPI.File f2 = new PolarPandaAPI.File()
            {
                id = 4566543,
                fileName = "dfew3",
                filePath = "/33/3//3",
                fileSize = 300
            };
            PolarPandaAPI.File f3 = new PolarPandaAPI.File()
            {
                id = 45334,
                fileName = "df33",
                filePath = "/33/3//3",
                fileSize = 300
            };
            List<PolarPandaAPI.File> f = new List<PolarPandaAPI.File>();
            f.Add(f1);
            f.Add(f2);
            f.Add(f3);
            Files files = new Files()
            {
                files = f
            };
            
            return files;
        }
   
    }
}
