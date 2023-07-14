using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace wedding_backend
{
    public static class UploadFunction
    {
        [FunctionName("UploadMedia")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "upload")] HttpRequest req,
            ILogger log)
        {
            var formData = await req.ReadFormAsync();

            Console.WriteLine(formData.Files.Count);
            Console.WriteLine(string.Join(',', formData.Files.Select(x => x.Name)));

            var files = req.Form.Files["file"];
            Console.WriteLine(formData.Files.Count);

            Console.WriteLine(req);
            Console.WriteLine(req.Form);

            return new OkObjectResult("");
        }
    }
}
