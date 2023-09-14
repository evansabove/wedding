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
using MoreLinq;
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

            await UploadToBlobStorage(file, formFile.ContentType, newId);

            file.Position = 0;

            var thumbnailStream = await CreateThumbnail(file);
            await UploadToBlobStorage(thumbnailStream, formFile.ContentType, $"thumbnails/{newId}");

            return newId;
        }

        private static async Task<Stream> CreateThumbnail(Stream image)
        {
            using Image img = await Image.LoadAsync(image);

            var size = Math.Min(img.Height, 250);

            img.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(size, size),
                Mode = ResizeMode.Crop
            }));

            //if (img.Width == img.Height)
            //{
            //    var size = Math.Min(img.Height, thumbnailHeight);
            //    img.Mutate(x => x.Resize(size, size, KnownResamplers.Lanczos3));
            //}
            //else if(img.Width > img.Height)
            //{
            //    img.Mutate(x => x.Resize(new ResizeOptions
            //    {
            //        Size = new Size(thumbnailHeight, 0),
            //        Mode = ResizeMode.Crop
            //    }));
            //}
            //else
            //{
            //    img.Mutate(x => x.Resize(new ResizeOptions
            //    {
            //        Size = new Size(0, thumbnailHeight),
            //        Mode = ResizeMode.Crop
            //    }));
            //}

            //img.Mutate(x => x.Pad(thumbnailHeight, thumbnailHeight, Color.FromRgb(34, 46, 80)));

            var thumbnailStream = new MemoryStream();
            await img.SaveAsJpegAsync(thumbnailStream);
            thumbnailStream.Position = 0;

            return thumbnailStream;
        }

        private async Task UploadToBlobStorage(Stream stream, string contentType, string fileName)
        {
            var blobServiceClient = new BlobServiceClient(config.BlobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("media");
            var blob = containerClient.GetBlobClient(fileName);

            var uploadedBlob = await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
        }
    }
}
