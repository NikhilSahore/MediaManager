using Azure.Storage.Blobs.Models;
using MediaGateway.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaGateway.Processor
{
    public class DocumentProcessor : IDocumentProcessor
    {
        private IBlobService BlobService { get; set; }

        public DocumentProcessor(IBlobService blobService)
        {
            BlobService = blobService;
        }
        public async Task StoreMediaDocument(Media media)
        {            
            foreach(var photo in media.Photos)
            {
                await BlobService.UploadBlobAsync(photo.File, photo.Name);
            }
            foreach (var video in media.Videos)
            {
                await BlobService.UploadBlobAsync(video.File, video.Name);
            }
        }
    }
}
