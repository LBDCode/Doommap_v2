using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class Gage
    {
        public string? StateAbv { get; set; }
        public string? AgencyCd { get; set; }
        public string? SiteNo { get; set; }
        public string? StationNm { get; set; }
        public double? Datum { get; set; }
        public Point? LocationGeom { get; set; }
        public bool? Active { get; set; }
        public string? DatumType { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int Oid { get; set; }
    }
}
