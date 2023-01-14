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

        [HttpGet("with-genre")]
        public async Task<IActionResult> GetBooksWithGenreAsync(CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetBooksWithGenreAsync(cancellationToken);
            if (!books?.Any() ?? true) //if (books == null || !books.Any())
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, books);
        }

        [HttpGet("without-genre")]
        public async Task<IActionResult> GetBooksWithoutGenreAsync(CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetBooksWithoutGenreAsync(cancellationToken);
            if (!books?.Any() ?? true) //if (books == null || !books.Any())
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, books);
        }
    }
}
