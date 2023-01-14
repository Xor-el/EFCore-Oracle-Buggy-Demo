namespace LibraryDemo.Models
{
    public class BookMetadata
    {
        public bool? AvailableToPublic { get; set; }
        public string? Description { get; set; }
        public Genre? Genre { get; set; }
        public string? Publisher { get; set; }
        public string? ISBN { get; set; }
        public double? Rating { get; set; }
        public DateTime? PublisherReleaseDate { get; set; }
    }
}
