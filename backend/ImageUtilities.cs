using System.IO;
using System.Threading.Tasks;
using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using wedding_backend;

public static class ImageUtilities
{
    public static async Task<Stream> CreateThumbnailAsync(Stream image)
    {
        using Image img = await Image.LoadAsync(image);

        var size = Math.Min(img.Height, 350);

        img.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(size, size),
            Mode = ResizeMode.Crop
        }));

        var thumbnailStream = new MemoryStream();
        await img.SaveAsJpegAsync(thumbnailStream);
        thumbnailStream.Position = 0;

        return thumbnailStream;
    }

    public static async Task UploadToBlobStorage(string blobStorageConnectionString, Stream stream, string contentType, string fileName)
    {
        var blobServiceClient = new BlobServiceClient(blobStorageConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient("media");
        var blob = containerClient.GetBlobClient(fileName);

        var uploadedBlob = await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
    }
}
