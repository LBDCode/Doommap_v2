using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class StormTrackPgn
    {
        public int Gid { get; set; }
        public string? Stormname { get; set; }
        public string? Stormtype { get; set; }
        public string? Advdate { get; set; }
        public string? Advisnum { get; set; }
        public decimal? Stormnum { get; set; }
        public decimal? Fcstprd { get; set; }
        public string? Basin { get; set; }
        public MultiPolygon? Geom { get; set; }
    }
}
