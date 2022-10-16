using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/studentcollections")]
    [ApiController]
    public class StudentCollectionsController : ControllerBase
    {

        private readonly ILibraryApplicationService _libraryApplicationService;
        public StudentCollectionsController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }

        [HttpPost]
        public IActionResult CreateStudentCollection([FromBody] IEnumerable<StudentForCreationDto> estudianteCollection)
        {
            if (estudianteCollection == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateStudentCollection(estudianteCollection);

            return CreatedAtRoute("GetStudentCollection", new { ids = result.IdsAsString }, result.StudentCollection);
        }

        // (key1,key2, ...)

        [HttpGet(Name = "GetStudentCollection")]
        public IActionResult GetStudentCollection([FromQuery] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetStudentCollection(ids);

            if (!result.StudentsFound)
            {
                return NotFound();
            }

            return Ok(result.StudentCollection);
        }
    }
}
