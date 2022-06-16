using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class Fire
    {
        public int Gid { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Brightness { get; set; }
        public decimal? Scan { get; set; }
        public decimal? Track { get; set; }
        //public DateOnly? AcqDate { get; set; }
        public string? AcqTime { get; set; }
        public string? Satellite { get; set; }
        public int? Confidence { get; set; }
        public string? Version { get; set; }
        public decimal? BrightT31 { get; set; }
        public decimal? Frp { get; set; }
        public string? Daynight { get; set; }
        public Point? Geom { get; set; }
    }
}
