using LibraryDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("with-metadata")]
        public async Task<IActionResult> GetBooksWithMetadataAsync(CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetBooksWithMetadataAsync(cancellationToken);
            if (!books?.Any() ?? true) //if (books == null || !books.Any())
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, books);
        }
    }
}
