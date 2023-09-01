using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;

namespace wedding_backend
{
    public class UploadMedia
    {
        private readonly Config config;

        public UploadMedia(Config config)
        {
            this.config = config;
        }

        [FunctionName("UploadMedia")]
        public async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = "media")][FromForm] HttpRequest req,
           ILogger log)
        {
            using var file = req.Form.Files[0].OpenReadStream();

            await Upload(file, req.Form.Files[0].ContentType);

            return new NoContentResult();
        }

        private async Task Upload(Stream stream, string contentType)
        {
            var blobServiceClient = new BlobServiceClient(config.BlobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("media");
            var blob = containerClient.GetBlobClient(Guid.NewGuid().ToString());

            var uploadedBlob = await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
        }
    }
}
