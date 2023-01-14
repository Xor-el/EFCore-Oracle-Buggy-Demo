using System.ComponentModel.DataAnnotations;

namespace LibraryDemo.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Metadata { get; set; }

        // One-to-many relation with author
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
