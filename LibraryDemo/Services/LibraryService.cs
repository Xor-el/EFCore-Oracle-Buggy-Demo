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

        public async Task<List<Book>> GetBooksWithGenreAsync(CancellationToken cancellationToken)
        {
            var filterKey = "$.genre";
            return await _db.Books.Where(x => !string.IsNullOrEmpty(x.Metadata) && OracleDbFunctions.JsonExists(x.Metadata, filterKey)).ToListAsync(cancellationToken);
        }

        public async Task<List<Book>> GetBooksWithoutGenreAsync(CancellationToken cancellationToken)
        {
            var filterKey = "$.genre";
            return await _db.Books.Where(x => !string.IsNullOrEmpty(x.Metadata) && !OracleDbFunctions.JsonExists(x.Metadata, filterKey)).ToListAsync(cancellationToken);
        }

        #endregion Books
    }
}

