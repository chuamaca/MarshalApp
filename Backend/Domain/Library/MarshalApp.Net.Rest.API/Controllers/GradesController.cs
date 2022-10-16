using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.Controllers
{
    //[Route("api/students/{StudentId}/Grades")]
    [Route("api/students/{studentId}/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {

        private readonly ILibraryApplicationService _libraryApplicationService;

        public GradesController(
            ILibraryApplicationService libraryApplicationService
        )
        {
            _libraryApplicationService = libraryApplicationService;
        }

        [HttpGet(Name = "GetGradesForStudent")]
        public IActionResult GetGradesForStudent(Guid studentId)
        {
            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.GetGradesForStudent(studentId);

            return Ok(result.LinkedCollectionResource);
        }

        [HttpGet("{id}", Name = "GetGradeForStudent")]
        public IActionResult GetGradeForStudent(Guid studentId, Guid id)
        {
            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.GetGradeForStudent(studentId, id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.LinkedResource);
        }

        [HttpPost(Name = "CreateGradeForStudent")]
        public IActionResult CreateCursoForEstudiante(Guid studentId, [FromBody] GradeForCreationDto grade)
        {
            if (grade == null)
            {
                return BadRequest();
            }

            if (grade.Subject == grade.Description)
            {
                ModelState.AddModelError(nameof(GradeForCreationDto), "The provided description should be different from the title.");
            }

            if (!ModelState.IsValid)
            {
                // return 422
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.CreateGradeForStudent(studentId, grade);

            return CreatedAtRoute("GetGradeForStudent", new { studentId, id = result.LinkedResource.GradeId }, result.LinkedResource);
        }
        [HttpDelete("{id}", Name = "DeleteGradeForStudent")]
        public IActionResult DeleteGradeForStudent(Guid studentId, Guid id)
        {
            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.DeleteGradeForStudent(studentId, id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}", Name = "UpdateGradeForStudent")]
        public IActionResult UpdateGradeForStudent(Guid studentId, Guid id, [FromBody] GradeForUpdateDto grade)
        {
            if (grade == null)
            {
                return BadRequest();
            }

            if (grade.Subject == grade.Description)
            {
                ModelState.AddModelError(nameof(GradeForUpdateDto), "The provided description should be different from the title.");
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }


            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.UpdateGradeForStudent(studentId, id, grade);

            if (result.Success && result.GradeUpserted != null)
            {
                return CreatedAtRoute("GetGradeForStudent", new { studentId, id = result.GradeUpserted.GradeId }, result.GradeUpserted);
            }

            return NoContent();
        }
        [HttpPatch("{id}", Name = "PartiallyUpdateGradeForStudent")]
        public IActionResult PartiallyUpdateGradeForStudent(Guid studentId, Guid id, [FromBody] JsonPatchDocument<GradeForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!_libraryApplicationService.StudentExists(studentId))
            {
                return NotFound();
            }

            var result = _libraryApplicationService.PartiallyUpdateGradeForStudent(studentId, id, patchDoc, this);

            if (!result.Success)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            else
            {
                if (result.GradeUpserted != null)
                {
                    return CreatedAtRoute("GetGradeForStudent", new { estudianteId = studentId, id = result.GradeUpserted.GradeId }, result.GradeUpserted);
                }
            }

            return NoContent();
        }
    }
}