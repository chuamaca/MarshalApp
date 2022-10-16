using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.TypeHelper;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;
        private readonly IAuthorPropertyMappingService _authorPropertyMappingService;
        private readonly ITypeHelperService _typeHelperService;
        public AuthorsController(
            ILibraryApplicationService libraryApplicationService,
            IAuthorPropertyMappingService authorPropertyMappingService,
            ITypeHelperService typeHelperService
            )
        {
            _libraryApplicationService = libraryApplicationService;
            _authorPropertyMappingService = authorPropertyMappingService;
            _typeHelperService = typeHelperService;
        }

        [HttpGet(Name = "GetAuthors")]
        public IActionResult GetAuthors([FromQuery] AuthorsResourceParameters authorsResourceParameters, [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!_authorPropertyMappingService.ValidMappingExistsFor(authorsResourceParameters.OrderBy) || !_typeHelperService.TypeHasProperties<AuthorDto>(authorsResourceParameters.Fields))
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetAuthors(authorsResourceParameters);

            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PaginationMetadata));

            if (mediaType == "application/vnd.cesar.hateoas+json")
            {
                return Ok(result.LinkedCollectionResource);
            }
            else
            {
                return Ok(result.ShapedAuthors);
            }
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid id, [FromQuery] string? fields)
        {
            if (!_typeHelperService.TypeHasProperties<AuthorDto>(fields))
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetAuthor(id, fields);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.LinkedResource);
        }

        [HttpPost(Name = "CreateAuthor")]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateAuthor(author);

            return CreatedAtRoute("GetAuthor", new { id = result.LinkedResource["AuthorId"] }, result.LinkedResource);
        }

        [HttpPost(Name = "CreateAuthorWithDateOfDeath")]
        [RequestHeaderMatchesMediaType("Content-Type", new[] { "application/vnd.cesar.authorwithdateofdeath.full+json", "application/vnd.cesar.authorwithdateofdeath.full+xml" })]
        public IActionResult CreateAuthorWithDateOfDeath([FromBody] AuthorForCreationWithDateOfDeathDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateAuthorWithDateOfDeath(author);

            return CreatedAtRoute("GetAuthor", new { id = result.LinkedResource["Id"] }, result.LinkedResource);
        }

        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var result = _libraryApplicationService.DeleteAuthor(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}", Name = "UpdateAuthor")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_libraryApplicationService.AuthorExists(id))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.UpdateAuthor(id, author);

            if (result.Success && result.AuthorUpserted != null)
            {
                return CreatedAtRoute("GetAuthor", new { id = result.AuthorUpserted.AuthorId }, result.AuthorUpserted);
            }

            return NoContent();
        }
    }
}
