using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.TypeHelper;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/technicalreports")]
    [ApiController]
    public class TechnicalreportsController : Controller
    {
        private readonly ILibraryApplicationService _libraryApplicationService;
        private readonly IInfohdrPropertyMappingService _infohdrPropertyMappingService;
        private readonly ITypeHelperService _typeHelperService;

        public TechnicalreportsController(
            ILibraryApplicationService libraryApplicationService,
            IInfohdrPropertyMappingService infohdrPropertyMappingService,
            ITypeHelperService typeHelperService)
        {
            _libraryApplicationService = libraryApplicationService;
            _infohdrPropertyMappingService = infohdrPropertyMappingService;
            _typeHelperService = typeHelperService;
        }

        [HttpPost(Name = "CreateTechnicalreports")]
        public IActionResult CreateTechnicalreports([FromBody] InfohdrForCreationDto infohdr)
        {
            if (infohdr==null)
            {
                return BadRequest();
            }
            var result = _libraryApplicationService.CreateTechnicalreports(infohdr);
            return CreatedAtRoute("Technicalreports", new { id = result.LinkedResource["Idinfohdr"] }, result.LinkedResource);


        }
    }
}
