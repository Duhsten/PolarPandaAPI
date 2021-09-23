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
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Threading;


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
        public async Task<FileStreamResult> Download(int id)
        {
            var path = "EFH/files.efh";
            var stream = System.IO.File.OpenRead(path);
            return new Microsoft.AspNetCore.Mvc.FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = "files.efh"
            };
        } 
        [HttpPost]
        [Route("addfile")]
        public IActionResult Upload(IFormFile file)
        {
           
             using (Stream fileStream = new FileStream(@"EFH/archive/" + file.FileName, FileMode.Create)) {
                    file.CopyToAsync(fileStream);
                }
           return Ok("File Recieved " + file.FileName);
        }

        [HttpPost("upload", Name = "upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(
         IFormFile file,
         CancellationToken cancellationToken)
        {
            if (CheckIfExcelFile(file))
            {
                await WriteFile(file);
            }
            else
            {
                return BadRequest(new { message = "Invalid file extension" });
            }

            return Ok();
        }  

        private bool CheckIfExcelFile(IFormFile file)
        {
           
            return false; // Change the extension based on your need
        }

        private async Task<bool> WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
                   fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
               //log error
            }

            return isSaveSuccess;
        }
    }
}
