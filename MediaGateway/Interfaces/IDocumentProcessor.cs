using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using MediaGateway.Models;

namespace MediaGateway.Interfaces
{
    public interface IDocumentProcessor
    {
        Task SaveMediaDocument(Media media);
    }
}
