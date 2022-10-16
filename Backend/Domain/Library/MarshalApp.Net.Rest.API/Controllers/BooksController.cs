using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;

        public BooksController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }

        [HttpGet(Name = "GetBooksForAuthor")]
        public IActionResult GetBooksForAuthor(Guid authorId)
        {
            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.GetBooksForAuthor(authorId);

            return Ok(result.LinkedCollectionResource);
        }

        [HttpGet("{id}", Name = "GetBookForAuthor")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid id)
        {
            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.GetBookForAuthor(authorId, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.LinkedResource);
        }

        [HttpPost(Name = "CreateBookForAuthor")]
        public IActionResult CreateBookForAuthor(Guid authorId, [FromBody] BookForCreationDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            if (book.Description == book.Title)
            {
                ModelState.AddModelError(nameof(BookForCreationDto), "The provided description should be different from the title.");
            }

            if (!ModelState.IsValid)
            {
                // return 422
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.CreateBookForAuthor(authorId, book);

            return CreatedAtRoute("GetBookForAuthor", new { authorId, id = result.LinkedResource.BookId }, result.LinkedResource);
        }
        [HttpDelete("{id}", Name = "DeleteBookForAuthor")]
        public IActionResult DeleteBookForAuthor(Guid authorId, Guid id)
        {
            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.DeleteBookForAuthor(authorId, id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}", Name = "UpdateBookForAuthor")]
        public IActionResult UpdateBookForAuthor(Guid authorId, Guid id, [FromBody] BookForUpdateDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            if (book.Description == book.Title)
            {
                ModelState.AddModelError(nameof(BookForUpdateDto), "The provided description should be different from the title.");
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }


            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.UpdateBookForAuthor(authorId, id, book);

            if (result.Success && result.BookUpserted != null)
            {
                return CreatedAtRoute("GetBookForAuthor", new { authorId, id = result.BookUpserted.BookId }, result.BookUpserted);
            }

            return NoContent();
        }
        [HttpPatch("{id}", Name = "PartiallyUpdateBookForAuthor")]
        public IActionResult PartiallyUpdateBookForAuthor(Guid authorId, Guid id, [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!_libraryApplicationService.AuthorExists(authorId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.PartiallyUpdateBookForAuthor(authorId, id, patchDoc, this);

            if (!result.Success)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            else
            {
                if (result.BookUpserted != null)
                {
                    return CreatedAtRoute("GetBookForAuthor", new { authorId, id = result.BookUpserted.BookId }, result.BookUpserted);
                }
            }

            return NoContent();
        }
    }
}
