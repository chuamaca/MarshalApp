using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public class InfohdrRepository : IInfohdrRepository
    {
        //Conexion
        private readonly LibraryContext _context;
        private IInfohdrPropertyMappingService _infohdrPropertyMappingService;

        public InfohdrRepository
            (LibraryContext context,
            IInfohdrPropertyMappingService infohdrPropertyMappingService)
        {
            _context = context;
            _infohdrPropertyMappingService = infohdrPropertyMappingService;
        }

        public void AddInfohdr(InfoHdr infohdr)
        {
            _context.InfoHdrs.Add(infohdr);
        }

        public void DeleteInfohdr(InfoHdr infohdr)
        {
            _context.InfoHdrs.Remove(infohdr);
        }

        public PagedList<InfoHdr> GetAllInfohdrs(InfohdrsResourceParameters infohdrsResourceParameters)
        {
            var collectionBeforePaging = _context.InfoHdrs.ApplySort(infohdrsResourceParameters.Orderby,_infohdrPropertyMappingService.GetPropertyMapping());

            if (!string.IsNullOrEmpty(infohdrsResourceParameters.busqueda))
            {
                var busquedaForWhereClause = infohdrsResourceParameters.busqueda.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.IdNum.ToLower() == busquedaForWhereClause);
            }
            if (!string.IsNullOrEmpty(infohdrsResourceParameters.SerachQuery))
            {
                var searchQueryForWhereClause = infohdrsResourceParameters.SerachQuery.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(x=>x.IdNum.ToLower() == searchQueryForWhereClause
                    ||x.Ref1.ToLower().Contains(searchQueryForWhereClause));

            }

            return PagedList<InfoHdr>.Create(collectionBeforePaging, infohdrsResourceParameters.PageNumber, infohdrsResourceParameters.PageSize);

        }

        public InfoHdr GetInfohdr(Guid idinfohdr)
        {
            return _context.InfoHdrs.FirstOrDefault(v => v.Idinfohdr == idinfohdr);
        }

        public IEnumerable<InfoHdr> GetInfohdrs(IEnumerable<Guid> idinfohdr)
        {
           return _context.InfoHdrs.Where(a => idinfohdr.Contains(a.Idinfohdr))
                .OrderBy(a=> a.IdNum)
                .OrderBy(a=> a.DteAdd)
                .ToList();
        }

        public bool InfohdrExists(Guid idinfohdr)
        {
            return _context.InfoHdrs.Any(a => a.Idinfohdr == idinfohdr);
        }

        public void UpdateInfohdr(InfoHdr infohdr)
        {
            var infohdrUpdate = GetInfohdr(infohdr.Idinfohdr);
            if (infohdrUpdate != null)
            {
                infohdrUpdate.DteUpd = infohdr.DteUpd;
                infohdrUpdate.Userid = infohdr.Userid;
                infohdrUpdate.Ref1= infohdr.Ref1;
                infohdrUpdate.Ref2= infohdr.Ref2;
                infohdrUpdate.Ref3 = infohdr.Ref3;
            }
        }
    }
}
