using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace wedding_backend
{
    public class DownsizeMedia
    {
        private readonly Config config;

        public DownsizeMedia(Config config)
        {
            this.config = config;
        }

        [FunctionName("DownsizeMedia")]
        public async Task Run(
            [BlobTrigger("media/official/{name}", Connection = "BlobStorageConnectionString")] Stream original,
            string name, ILogger log)
        {
            var generatedThumbnail = await ImageUtilities.CreateThumbnailAsync(original);

            await ImageUtilities.UploadToBlobStorage(config.BlobStorageConnectionString, generatedThumbnail, "image/jpeg", $"official-thumbnails/{name}");
        }
    }
}
