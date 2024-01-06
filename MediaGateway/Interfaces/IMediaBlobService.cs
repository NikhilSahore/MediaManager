using Azure.Storage.Blobs.Models;

namespace MediaGateway.Interfaces
{
    public interface IMediaBlobService
    {
        Task UploadBlobAsync(IFormFile file, string mediaId);
    }
}
