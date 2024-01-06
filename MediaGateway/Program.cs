using Azure.Storage.Blobs;
using MediaGateway.Interfaces;
using MediaGateway.Models;
using MediaGateway.Processor;
using MediaGateway.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddSingleton<IMongoDBSettings>(mg =>
    mg.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddSingleton(x =>
{
    var blobServiceClient = new BlobServiceClient(builder.Configuration.GetValue<string>("AzureBlobSettings:ConnectionString"));
    return blobServiceClient.GetBlobContainerClient(builder.Configuration.GetValue<string>("AzureBlobSettings:ContainerName"));
});
builder.Services.AddSingleton<IMongoClient>(x => new MongoClient(builder.Configuration.GetValue<string>("MongoDBSettings:ConnectionString")));
builder.Services.AddSingleton<IMediaBlobService, MediaBlobService>();
builder.Services.AddSingleton<IMediaDatabaseService, MediaDatabaseService>();
builder.Services.AddSingleton<IDocumentProcessor, DocumentProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
