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
           if(text.Equals("true"))
           {
              return "true"; 
           }
           else if(text.Equals("false"))
           {
              return "lock"; 
           }
           else
           {
               return "false"; 
           }
            
        }
    [HttpGet("retrievelist")]
        public HttpResponseMessage GetFile(string id)
        {

            string fileName;
            string localFilePath;
            int fileSize;

            localFilePath = "test.zip";
            fileName = "test.zip";

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;
}
    }
}
