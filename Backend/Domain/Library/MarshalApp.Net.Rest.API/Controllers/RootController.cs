using MarshalApp.Net.Rest.API.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;
        public RootController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType == "application/vnd.cesar.hateoas+json")
            {
                return Ok(_libraryApplicationService.GetRoot());
            }

            return NoContent();
        }
    }
}
