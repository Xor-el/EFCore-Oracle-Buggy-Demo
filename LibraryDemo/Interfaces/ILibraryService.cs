using LibraryDemo.Models;

namespace LibraryDemo.Interfaces
{
    public interface ILibraryService
    {
        // Book Services
        Task<List<Book>> GetBooksWithGenreAsync(CancellationToken cancellationToken); // GET All Books with Genre
        Task<List<Book>> GetBooksWithoutGenreAsync(CancellationToken cancellationToken); // GET All Books without Genre
    }
}
