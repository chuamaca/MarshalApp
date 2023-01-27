using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Entities
{
    internal class Informes
    {
    }
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class InboundHeader
    {
        [JsonPropertyName("DocumentType")]
        public string DocumentType { get; set; }

        [JsonPropertyName("Supplier_Id")]
        public string Supplier_Id { get; set; }

        [JsonPropertyName("Store")]
        public string Store { get; set; }

        [JsonPropertyName("NroOC")]
        public string NroOC { get; set; }

        [JsonPropertyName("Creation_date")]
        public DateTime Creation_date { get; set; }

        [JsonPropertyName("Document_date")]
        public DateTime Document_date { get; set; }

        [JsonPropertyName("Despatch_Type")]
        public string Despatch_Type { get; set; }

        [JsonPropertyName("Tracking_Number")]
        public string Tracking_Number { get; set; }

        [JsonPropertyName("NroOrder")]
        public string NroOrder { get; set; }

        [JsonPropertyName("Doc_ref1")]
        public string Doc_ref1 { get; set; }

        [JsonPropertyName("Doc_ref2")]
        public string Doc_ref2 { get; set; }

        [JsonPropertyName("Doc_ref3")]
        public string Doc_ref3 { get; set; }

        [JsonPropertyName("Doc_ref4")]
        public string Doc_ref4 { get; set; }

        [JsonPropertyName("Doc_ref5")]
        public string Doc_ref5 { get; set; }
    }

    public class InboundItemList
    {
        [JsonPropertyName("InboundLines")]
        public List<InboundLine> InboundLines { get; set; }
    }

    public class InboundLine
    {
        [JsonPropertyName("DocumentType")]
        public string DocumentType { get; set; }

        [JsonPropertyName("NroDoc")]
        public string NroDoc { get; set; }

        [JsonPropertyName("LinNum")]
        public string LinNum { get; set; }

        [JsonPropertyName("Article")]
        public string Article { get; set; }

        [JsonPropertyName("Cantidad")]
        public string Cantidad { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("CodeSize")]
        public string CodeSize { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        [JsonPropertyName("Product")]
        public string Product { get; set; }

        [JsonPropertyName("Attribute1")]
        public string Attribute1 { get; set; }

        [JsonPropertyName("Attribute2")]
        public string Attribute2 { get; set; }

        [JsonPropertyName("Attribute3")]
        public string Attribute3 { get; set; }

        [JsonPropertyName("Attribute4")]
        public string Attribute4 { get; set; }

        [JsonPropertyName("Attribute5")]
        public string Attribute5 { get; set; }
    }

    public class InboundOC
    {
        [JsonPropertyName("InboundHeader")]
        public InboundHeader InboundHeader { get; set; }

        [JsonPropertyName("InboundSupplier")]
        public InboundSupplier InboundSupplier { get; set; }

        [JsonPropertyName("InboundItemList")]
        public InboundItemList InboundItemList { get; set; }
    }

    public class InboundSupplier
    {
        [JsonPropertyName("DocumentType")]
        public string DocumentType { get; set; }

        [JsonPropertyName("NroDoc")]
        public string NroDoc { get; set; }

        [JsonPropertyName("Supplier_Id")]
        public string Supplier_Id { get; set; }

        [JsonPropertyName("Name1")]
        public string Name1 { get; set; }

        [JsonPropertyName("Name2")]
        public string Name2 { get; set; }

        [JsonPropertyName("Street1")]
        public object Street1 { get; set; }

        [JsonPropertyName("Street2")]
        public string Street2 { get; set; }

        [JsonPropertyName("PostCode")]
        public string PostCode { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("CountryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("RegionCode")]
        public string RegionCode { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("Inbound_OC")]
        public InboundOC Inbound_OC { get; set; }
    }


}
