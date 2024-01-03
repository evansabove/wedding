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
using System.Collections.Generic;

namespace wedding_backend
{
    public record UploadResult(List<string> Succeeded, List<string> Failed);

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
            var result = new UploadResult(new List<string>(), new List<string>());

            foreach(var file in req.Form.Files)
            {
                try
                {
                    result.Succeeded.Add(await Upload(file));
                } catch(Exception ex)
                {
                    log.LogError(ex, "Failed to upload file");
                    result.Failed.Add(file.FileName);
                }
            }

            return new OkObjectResult(result);
        }

        private async Task<string> Upload(IFormFile formFile)
        {
            using var file = formFile.OpenReadStream();

            var newId = Guid.NewGuid().ToString();

            await ImageUtilities.UploadToBlobStorage(config.BlobStorageConnectionString, file, formFile.ContentType, newId);

            file.Position = 0;

            var thumbnailStream = await ImageUtilities.CreateThumbnailAsync(file);
            await ImageUtilities.UploadToBlobStorage(config.BlobStorageConnectionString, thumbnailStream, formFile.ContentType, $"thumbnails/{newId}");

            return newId;
        }
    }
}
