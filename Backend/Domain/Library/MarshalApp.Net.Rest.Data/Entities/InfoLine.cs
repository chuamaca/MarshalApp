﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Entities
{
    public partial class InfoLine
    {
        public Guid Idinfoline { get; set; }
        public string CodName { get; set; }
        public string Prtnum { get; set; }
        public DateTime? DteRentingIni { get; set; }
        public DateTime Dterentingend { get; set; }
        public string Status { get; set; }
        public Guid Idinfohdr { get; set; }
        public string Reason { get; set; }

        public virtual InfoHdr IdinfohdrNavigation { get; set; }
    }
}