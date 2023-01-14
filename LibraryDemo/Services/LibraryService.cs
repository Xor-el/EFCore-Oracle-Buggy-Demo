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

        public async Task<List<Book>> GetBooksWithMetadataAsync(CancellationToken cancellationToken)
        {
            return await _db.Books.Where(x => !string.IsNullOrWhiteSpace(x.Metadata)).ToListAsync(cancellationToken);
        }

        #endregion Books
    }
}

