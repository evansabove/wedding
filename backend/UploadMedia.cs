using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace wedding_backend
{
    public static class UploadMedia
    {
        [FunctionName("UploadMedia")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "upload")] [FromForm] HttpRequest req,
            ILogger log, [Blob("media/{rand-guid}", FileAccess.Write)] Stream media)
        {
            var file = req.Form.Files[0];

            using var stream = file.OpenReadStream();

            await stream.CopyToAsync(media);

            return new NoContentResult();
        }
    }
}
