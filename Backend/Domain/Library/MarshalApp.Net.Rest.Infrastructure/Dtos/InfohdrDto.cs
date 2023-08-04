using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class InfohdrDto
    {
        public Guid Idinfohdr { get; set; }
        public string IdNum { get; set; }
        public DateTime? DteAdd { get; set; }
        public DateTime? DteUpd { get; set; }
        public string Userid { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
    }
}
