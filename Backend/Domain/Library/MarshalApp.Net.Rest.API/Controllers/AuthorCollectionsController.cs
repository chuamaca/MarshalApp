using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/authorcollections")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class AuthorCollectionsController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;
        public AuthorCollectionsController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }

        [HttpPost]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<AuthorForCreationDto> authorCollection)
        {
            if (authorCollection == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateAuthorCollection(authorCollection);

            return CreatedAtRoute("GetAuthorCollection", new { ids = result.IdsAsString }, result.AuthorCollection);
        }

        // (key1,key2, ...)

        [HttpGet(Name = "GetAuthorCollection")]
        public IActionResult GetAuthorCollection([FromQuery] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetAuthorCollection(ids);

            if (!result.AuthorsFound)
            {
                return NotFound();
            }

            return Ok(result.AuthorCollection);
        }

    }
}
