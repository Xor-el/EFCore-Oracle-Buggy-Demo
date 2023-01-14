using LibraryDemo.Data;
using LibraryDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryDemo.Interfaces
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;

        public LibraryService(AppDbContext db)
        {
            _db = db;
        }

        #region Books

        public async Task<List<Book>> GetBooksThatContainsKeywordInDescriptionAsync(CancellationToken cancellationToken)
        {
            var filterKey = "$.description";

            return await (from book in _db.Books
                          let metadata = book.Metadata
                          where !string.IsNullOrEmpty(metadata)
                          let description = OracleDbFunctions.JsonValue(metadata, filterKey)
                          where !string.IsNullOrEmpty(description) && description.Contains("Harry")
                          select book).ToListAsync(cancellationToken);
        }

        #endregion Books
    }
}

