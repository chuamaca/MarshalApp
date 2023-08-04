using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public interface IInfohdrRepository
    {
        void AddInfohdr(InfoHdr infohdr);
        bool InfohdrExists(Guid idinfohdr);
        void DeleteInfohdr(InfoHdr infohdr);
        InfoHdr GetInfohdr(Guid idinfohdr);
        //Incliye el Paginado
        PagedList<InfoHdr> GetAllInfohdrs(InfohdrsResourceParameters infohdrsResourceParameters);
        IEnumerable<InfoHdr> GetInfohdrs(IEnumerable<Guid> idinfohdr);
        void UpdateInfohdr(InfoHdr infohdr);
    }
}
