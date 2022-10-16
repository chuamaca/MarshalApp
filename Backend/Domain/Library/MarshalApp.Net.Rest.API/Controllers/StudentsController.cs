using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.TypeHelper;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarshalApp.Net.Rest.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILibraryApplicationService _libraryApplicationService;
        private readonly IStudentPropertyMappingService _studentPropertyMappingService;
        private readonly ITypeHelperService _typeHelperService;
        public StudentsController(
            ILibraryApplicationService libraryApplicationService,
            IStudentPropertyMappingService studentPropertyMappingService,
            ITypeHelperService typeHelperService
            )
        {
            _libraryApplicationService = libraryApplicationService;
            _studentPropertyMappingService = studentPropertyMappingService;
            _typeHelperService = typeHelperService;
        }

        [HttpGet(Name = "GetStudents")]
        public IActionResult GetStudents([FromQuery] StudentsResourceParameters studentsResourceParameters, [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!_studentPropertyMappingService.ValidMappingExistsFor(studentsResourceParameters.OrderBy) || !_typeHelperService.TypeHasProperties<StudentDto>(studentsResourceParameters.Fields))
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetStudents(studentsResourceParameters);

            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PaginationMetadata));

            if (mediaType == "application/vnd.cesar.hateoas+json")
            {
                return Ok(result.LinkedCollectionResource);
            }
            else
            {
                return Ok(result.ShapedStudents);
            }
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(Guid id, [FromQuery] string? fields = "")
        {
            if (!_typeHelperService.TypeHasProperties<StudentDto>(fields))
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.GetStudent(id, fields);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.LinkedResource);
        }

        [HttpPost(Name = "CreateStudent")]
        public IActionResult CreateStudent([FromBody] StudentForCreationDto student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var result = _libraryApplicationService.CreateStudent(student);

            return CreatedAtRoute("GetStudent", new { id = result.LinkedResource["StudentId"] }, result.LinkedResource);
        }

        //[HttpPost(Name = "CreateEstudianteWithDateOfDeath")]
        //[RequestHeaderMatchesMediaType("Content-Type", new[] { "application/vnd.cesar.authorwithdateofdeath.full+json", "application/vnd.cesar.authorwithdateofdeath.full+xml" })]
        //public IActionResult CreateAuthorWithDateOfDeath([FromBody] AuthorForCreationWithDateOfDeathDto author)
        //{
        //    if (author == null)
        //    {
        //        return BadRequest();
        //    }

        //    var result = _libraryApplicationService.CreateAuthorWithDateOfDeath(author);

        //    return CreatedAtRoute("GetAuthor", new { id = result.LinkedResource["Id"] }, result.LinkedResource);
        //}

        [HttpDelete("{id}", Name = "DeleteStudent")]
        public IActionResult DeleteStudent(Guid id)
        {
            var result = _libraryApplicationService.DeleteStudent(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}", Name = "UpdateStudent")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentForUpdateDto student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_libraryApplicationService.StudentExists(id))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.UpdateStudent(id, student);

            if (result.Success && result.StudentUpserted != null)
            {
                return CreatedAtRoute("GetStudent", new { id = result.StudentUpserted.StudentId }, result.StudentUpserted);
            }

            return NoContent();
        }

    }
}
