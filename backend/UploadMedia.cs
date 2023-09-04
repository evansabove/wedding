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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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

            var newId = Guid.NewGuid().ToString();

            await Upload(file, req.Form.Files[0].ContentType, newId);

            file.Position = 0;

            var thumbnailStream = await CreateThumbnail(file);
            await Upload(thumbnailStream, req.Form.Files[0].ContentType, $"thumbnails/{newId}");

            return new NoContentResult();
        }

        private static async Task<Stream> CreateThumbnail(Stream image)
        {
            int thumbnailHeight = 250;

            using Image img = await Image.LoadAsync(image);

            img.Mutate(x => x.Resize(0, thumbnailHeight));

            var thumbnailStream = new MemoryStream();
            await img.SaveAsJpegAsync(thumbnailStream);
            thumbnailStream.Position = 0;

            return thumbnailStream;
        }

        private async Task Upload(Stream stream, string contentType, string fileName)
        {
            var blobServiceClient = new BlobServiceClient(config.BlobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("media");
            var blob = containerClient.GetBlobClient(fileName);

            var uploadedBlob = await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
        }
    }
}
