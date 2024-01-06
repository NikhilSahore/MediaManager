using Azure.Storage.Blobs.Models;
using MediaGateway.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MediaGateway.Models;

namespace MediaGateway.Processor
{
    public class DocumentProcessor : IDocumentProcessor
    {
        private IMediaBlobService MediaBlobService { get; set; }

        private IMediaDatabaseService MediaDatabaseService { get; set; }

        public DocumentProcessor(IMediaBlobService mediaBlobService, IMediaDatabaseService mediaDatabaseService)
        {
            MediaBlobService = mediaBlobService;
            MediaDatabaseService = mediaDatabaseService;
        }
        public async Task SaveMediaDocument(Media media)
        {
            MediaDatabaseService.Create(media);
            foreach(var photo in media.Photos)
            {
                await MediaBlobService.UploadBlobAsync(photo.File, media.Id);
            }
            foreach (var video in media.Videos)
            {
                await MediaBlobService.UploadBlobAsync(video.File, media.Id);
            }
        }
    }
}
