using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.PropertyMapping;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Helpers
{
    public class InfohdrPropertyMappingService : PropertyMappingService<InfohdrDto, InfoHdr>, IInfohdrPropertyMappingService
    {
       
        private static Dictionary<string, PropertyMappingValue> _infohdrPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            { 
                
            
            };

        public InfohdrPropertyMappingService () : base(_infohdrPropertyMapping)
        {

        }
    }
}
