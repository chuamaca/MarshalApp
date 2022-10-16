using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Dynamic;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class StudentLinksBuilder : IStudentLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public StudentLinksBuilder(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }

        public string CreateStudentsResourceUri(StudentsResourceParameters studentsResourceParameters, ResourceUriType type)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return urlHelper.Link("GetStudents",
                      new
                      {
                          fields = studentsResourceParameters.Fields,
                          orderBy = studentsResourceParameters.OrderBy,
                          searchQuery = studentsResourceParameters.SearchQuery,
                          genre = studentsResourceParameters.Genre,
                          pageNumber = studentsResourceParameters.PageNumber - 1,
                          pageSize = studentsResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return urlHelper.Link("GetStudents",
                      new
                      {
                          fields = studentsResourceParameters.Fields,
                          orderBy = studentsResourceParameters.OrderBy,
                          searchQuery = studentsResourceParameters.SearchQuery,
                          genre = studentsResourceParameters.Genre,
                          pageNumber = studentsResourceParameters.PageNumber + 1,
                          pageSize = studentsResourceParameters.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return urlHelper.Link("GetStudents",
                    new
                    {
                        fields = studentsResourceParameters.Fields,
                        orderBy = studentsResourceParameters.OrderBy,
                        searchQuery = studentsResourceParameters.SearchQuery,
                        genre = studentsResourceParameters.Genre,
                        pageNumber = studentsResourceParameters.PageNumber,
                        pageSize = studentsResourceParameters.PageSize
                    });
            }
        }

        public IEnumerable<LinkDto> CreatePagedLinksForStudents(StudentsResourceParameters studentsResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();

            // self 
            links.Add(new LinkDto(CreateStudentsResourceUri(studentsResourceParameters, ResourceUriType.Current), "self", "GET"));

            if (hasNext)
            {
                links.Add(new LinkDto(CreateStudentsResourceUri(studentsResourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateStudentsResourceUri(studentsResourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
            }

            return links;
        }

        public List<LinkDto> CreateDocumentationLinksForStudent(Guid id, string fields)
        {
            var links = new List<LinkDto>();
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(new LinkDto(urlHelper.Link("GetStudent", new { id }), "self", "GET"));
            }
            else
            {
                links.Add(new LinkDto(urlHelper.Link("GetStudent", new { id, fields }), "self", "GET"));
            }

            links.Add(new LinkDto(urlHelper.Link("DeleteStudent", new { id }), "delete_estudiante", "DELETE"));
            links.Add(new LinkDto(urlHelper.Link("CreateGradeForStudent", new { estudianteId = id }), "create_curso_for_estudiante", "POST"));
            links.Add(new LinkDto(urlHelper.Link("GetGradesForStudent", new { estudianteId = id }), "cursos", "GET"));

            return links;
        }

        public PaginationMetadata GetPaginationMetadata(PagedList<Student> estudiantes, StudentsResourceParameters estudiantesResourceParameters)
        {
            PaginationMetadata paginationMetadata = new PaginationMetadata
            {
                PreviousPageLink = estudiantes.HasPrevious ? CreateStudentsResourceUri(estudiantesResourceParameters, ResourceUriType.PreviousPage) : null,
                NextPageLink = estudiantes.HasNext ? CreateStudentsResourceUri(estudiantesResourceParameters, ResourceUriType.NextPage) : null,
                TotalCount = estudiantes.TotalCount,
                PageSize = estudiantes.PageSize,
                CurrentPage = estudiantes.CurrentPage,
                TotalPages = estudiantes.TotalPages,
            };

            return paginationMetadata;
        }

        public IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForStudentShapeData(IEnumerable<ExpandoObject> shapedEstudiantes, StudentsResourceParameters estudiantesResourceParameters)
        {
            var shapedEstudiantesWithLinks = shapedEstudiantes.Select(estudiante =>
            {
                var estudianteAsDictionary = estudiante as IDictionary<string, object>;
                var estudianteLinks = CreateDocumentationLinksForStudent((Guid)estudianteAsDictionary["StudentId"], estudiantesResourceParameters.Fields);
                estudianteAsDictionary.Add("links", estudianteLinks);

                return estudianteAsDictionary;
            });

            return shapedEstudiantesWithLinks;
        }




    }
}
