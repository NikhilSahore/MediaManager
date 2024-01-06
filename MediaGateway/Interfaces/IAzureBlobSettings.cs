namespace MediaGateway.Interfaces
{
    public interface IAzureBlobSettings
    {
        string ContainerName { get; set; }

        string ConnectionString { get; set; }
    }
}
