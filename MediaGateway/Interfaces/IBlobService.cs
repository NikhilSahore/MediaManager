using Azure.Storage.Blobs.Models;

namespace MediaGateway.Interfaces
{
    public interface IBlobService
    {
        Task UploadBlobAsync(IFormFile file, string blobName);
    }
}
