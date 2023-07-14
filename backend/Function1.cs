using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace wedding_backend
{
    public static class Function1
    {
        [FunctionName("UploadMedia")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "upload")] HttpRequest req,
            ILogger log)
        {
            var formData = await req.ReadFormAsync();
            var file = req.Form.Files["file"];

            return new OkObjectResult(file.FileName + " - " + file.Length);
        }
    }
}
