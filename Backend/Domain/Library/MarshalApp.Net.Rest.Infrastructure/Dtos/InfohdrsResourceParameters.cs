using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos
{
    public class InfohdrsResourceParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 10;

        public int PageSize
        { 
            get
            { 
                return _pageSize;           
            }
            set
            {
                _pageSize = value > maxPageSize ? value : maxPageSize;
            }
        }

        public string Orderby { get; set; } = "IdNum";

        public string busqueda { get; set; }

        public string SerachQuery { get; set; } = "";
        public string Fields { get; set; } = "";
    }
}
