﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Entities
{
    public partial class InfHdr
    {
        public InfHdr()
        {
            InfCsts = new HashSet<InfCst>();
            InfLines = new HashSet<InfLine>();
        }

        public Guid Idinfhdr { get; set; }
        public string IdNum { get; set; }
        public DateTime? DteAdd { get; set; }
        public DateTime? DteUpd { get; set; }
        public string Userid { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }

        public virtual ICollection<InfCst> InfCsts { get; set; }
        public virtual ICollection<InfLine> InfLines { get; set; }
    }
}