using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public abstract class InfolineForManipulationDto
    {
        //public Guid Idinfoline { get; set; }
        public string CodName { get; set; }
        public string Prtnum { get; set; }
        public DateTime? DteRentingIni { get; set; }
        public DateTime Dterentingend { get; set; }
        public string Status { get; set; }
        //public Guid Idinfohdr { get; set; }
        public string Reason { get; set; }
    }
}
