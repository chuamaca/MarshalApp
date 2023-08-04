using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public abstract class InfocstForManipulationDto
    {
        //public Guid Idinfocst { get; set; }
        //public Guid Idinfhdr { get; set; }
        public string Idcustomer { get; set; }
        public string Idtocustomer { get; set; }
        public DateTime Dterequest { get; set; }
        public string Ubigeo { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string UserRequest { get; set; }
        public string Numprocess { get; set; }
    }
}
