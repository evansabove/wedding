using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using Azure;
using System.Collections.Generic;
using Azure.Storage.Sas;
using System.Linq;

namespace wedding_backend
{
    public class GetMedia
    {
        private readonly Config config;

        public GetMedia(Config config)
        {
            this.config = config;
        }

        [FunctionName("GetMedia")]
        public async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "media")] HttpRequest req,
           ILogger log)
        {
            var blobServiceClient = new BlobServiceClient(config.BlobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("media");

            var resultSegment = containerClient.GetBlobsAsync()
                .AsPages();

            var allBlobs = new List<BlobRecord>();

            await foreach (Page<BlobItem> blobPage in resultSegment)
            {
                foreach (BlobItem blobItem in blobPage.Values)
                {
                    var blobSasBuilder = new BlobSasBuilder
                    {
                        StartsOn = DateTime.UtcNow.AddMonths(-1),
                        ExpiresOn = DateTime.UtcNow.AddMonths(1),
                        BlobContainerName = "media",
                        BlobName = blobItem.Name,
                        Resource = "b"
                    };

                    blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

                    var blobClient = containerClient.GetBlobClient(blobItem.Name);
                    var sasUri = blobClient.GenerateSasUri(blobSasBuilder);

                    allBlobs.Add(new BlobRecord(blobItem.Properties.LastModified, blobItem.Name, sasUri));
                }
            }

            var results = allBlobs.OrderByDescending(x => x.LastModified);

            return new OkObjectResult(results);
        }
    }

    public record BlobRecord(DateTimeOffset? LastModified, string Name, Uri sasUri);
}
