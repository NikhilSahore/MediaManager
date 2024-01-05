using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaGateway.Interfaces
{
    public interface IDocumentProcessor
    {
        Task StoreMediaDocument(Media media);
    }
}
