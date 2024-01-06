using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediaGateway.Interfaces;

namespace MediaGateway.Services
{
    public class MediaBlobService : IMediaBlobService
    {
        private BlobContainerClient BlobContainerClient { get; set; }

        public MediaBlobService(BlobContainerClient blobContainerClient)
        {
            BlobContainerClient = blobContainerClient;
        }
        public async Task UploadBlobAsync(IFormFile file, string mediaId)
        {            
            var blobName = string.Join(":",mediaId,file.FileName);
            var blobClient = BlobContainerClient.GetBlobClient(blobName);

            // Open the image file and upload its contents to the blob
            using (var fs = file.OpenReadStream())
            {
                await blobClient.UploadAsync(fs);                    
            }
        }
    }
}
