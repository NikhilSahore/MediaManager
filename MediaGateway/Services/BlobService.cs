using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediaGateway.Interfaces;

namespace MediaGateway.Services
{
    public class BlobService : IBlobService
    {
        private readonly string _blobContainer = "mediacontainer";
        private BlobServiceClient BlobServiceClient { get; set; }

        public BlobService(BlobServiceClient blobServiceClient)
        {
            BlobServiceClient = blobServiceClient;
        }
        public async Task UploadBlobAsync(IFormFile file, string blobName)
        {            
            // Get a reference to the container
            var containerClient = BlobServiceClient.GetBlobContainerClient(_blobContainer);
            var blobClient = containerClient.GetBlobClient(blobName);

            // Open the image file and upload its contents to the blob
            using (var fs = file.OpenReadStream())
            {
                await blobClient.UploadAsync(fs);                    
            }
        }
    }
}
