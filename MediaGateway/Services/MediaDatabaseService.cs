using MediaGateway.Interfaces;
using MediaGateway.Models;
using MongoDB.Driver;

namespace MediaGateway.Services
{
    public class MediaDatabaseService : IMediaDatabaseService
    {
        private readonly IMongoCollection<Media> _media;

        public MediaDatabaseService(IMongoDBSettings mongoDBSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(mongoDBSettings.DatabaseName);
            _media = database.GetCollection<Media>(mongoDBSettings.CollectionName);
        }
        public Media Create(Media media)
        {
            _media.InsertOne(media);
            return media;
        }
    }
}
