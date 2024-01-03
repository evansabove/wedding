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
    public class GetOfficialMedia
    {
        private readonly Config config;

        public GetOfficialMedia(Config config)
        {
            this.config = config;
        }

        [FunctionName("GetOfficialMedia")]
        public async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "media/official")] HttpRequest req,
           ILogger log)
        {
            var blobServiceClient = new BlobServiceClient(config.BlobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("media");

            var resultSegment = containerClient.GetBlobsAsync()
                .AsPages();

            var allBlobs = new List<BlobRecord>();

            await foreach (Page<BlobItem> blobPage in resultSegment)
            {
                foreach (BlobItem blobItem in blobPage.Values.Where(x => x.Name.StartsWith("official-thumbnails/")))
                {
                    var thumbnailUri = GetSasUriForBlob(containerClient, blobItem.Name);
                    var fullImageUri = GetSasUriForBlob(containerClient, $"official/{blobItem.Name["official-thumbnails/".Length..]}");

                    allBlobs.Add(new BlobRecord(blobItem.Properties.LastModified, blobItem.Name, thumbnailUri, fullImageUri));
                }
            }

            if(!int.TryParse(req.Query["page"], out int page))
            {
                page = 1;
            }

            if(!int.TryParse(req.Query["pageSize"], out int pageSize))
            {
                pageSize = 20;
            }

            var results = allBlobs
                .Where(x => x.Name.Contains('-') && x.Name.Contains('.'))
                .OrderBy(x => int.TryParse(x.Name.Split('-', '.')[2], out var imageNumber) ? imageNumber : 0)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var result = new GetMediaResponse(page, pageSize, (int)Math.Ceiling(allBlobs.Count / (double)pageSize), allBlobs.Count, results);

            return new OkObjectResult(result);
        }

        private record GetMediaResponse(int Page, int PageSize, int TotalPages, int TotalRecords, IEnumerable<BlobRecord> Results);

        private static Uri GetSasUriForBlob(BlobContainerClient containerClient, string name)
        {
            var blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = DateTime.UtcNow.AddMonths(-1),
                ExpiresOn = DateTime.UtcNow.AddMonths(1),
                BlobContainerName = "media",
                BlobName = name,
                Resource = "b"
            };

            blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

            var blobClient = containerClient.GetBlobClient(name);
            return blobClient.GenerateSasUri(blobSasBuilder);
        }
    }
}