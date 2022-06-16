using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class StormTrackPt
    {
        public int Gid { get; set; }
        public string? Advdate { get; set; }
        public string? Advisnum { get; set; }
        public string? Basin { get; set; }
        public string? Datelbl { get; set; }
        public string? Dvlbl { get; set; }
        public decimal? Fcstprd { get; set; }
        public string? Fldatelbl { get; set; }
        public decimal? Gust { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
        public decimal? Maxwind { get; set; }
        public decimal? Mslp { get; set; }
        public decimal? Ssnum { get; set; }
        public string? Stormname { get; set; }
        public decimal? Stormnum { get; set; }
        public string? Stormsrc { get; set; }
        public string? Stormtype { get; set; }
        public string? Tcdvlp { get; set; }
        public decimal? Tau { get; set; }
        public decimal? Tcdir { get; set; }
        public decimal? Tcspd { get; set; }
        public string? Timezone { get; set; }
        public string? Validtime { get; set; }
        public Point? Geom { get; set; }
    }
}
