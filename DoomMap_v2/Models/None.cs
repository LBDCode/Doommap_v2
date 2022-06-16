using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class None
    {
        public int Gid { get; set; }
        public string? CapId { get; set; }
        public string? Vtec { get; set; }
        public string? Phenom { get; set; }
        public string? Sig { get; set; }
        public string? Wfo { get; set; }
        public string? Event { get; set; }
        public string? Issuance { get; set; }
        public string? Expiration { get; set; }
        public string? Onset { get; set; }
        public string? Ends { get; set; }
        public string? Url { get; set; }
        public string? MsgType { get; set; }
        public string? ProdType { get; set; }
        public MultiPolygon? Geom { get; set; }
    }
}
