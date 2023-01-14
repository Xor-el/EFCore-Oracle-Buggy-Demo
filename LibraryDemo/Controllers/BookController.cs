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

        [HttpGet("contains-keyword-in-description")]
        public async Task<IActionResult> GetBooksThatContainsKeywordInDescriptionAsync(CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetBooksThatContainsKeywordInDescriptionAsync(cancellationToken);
            if (!books?.Any() ?? true) //if (books == null || !books.Any())
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status200OK, books);
        }
    }
}
