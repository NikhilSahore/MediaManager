namespace MediaGateway
{
    public class Media
    {
        public string Event { get; set; }

        public Location Location { get; set; }

        public string Time { get; set; }

        public List<MediaFile> Photos { get; set; }

        public List<MediaFile> Videos { get; set; }
    }

    public class MediaFile
    {
        public string Name { get; set; }

        public IFormFile File { get; set; }
    }

    public class Location
    {
        public string City { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}