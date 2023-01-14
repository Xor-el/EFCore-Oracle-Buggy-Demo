using LibraryDemo.Models;

namespace LibraryDemo.Interfaces
{
    public interface ILibraryService
    {
        // Book Services
        Task<List<Book>> GetBooksThatContainsKeywordInDescriptionAsync(CancellationToken cancellationToken); // GET All Books that contains keyword in Description
    }
}
