using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class CurrentFire
    {
        public int Objectid { get; set; }
        public decimal? Dailyacres { get; set; }
        public decimal? Estimatedcosttodate { get; set; }
        public string? Firebehaviorgeneral { get; set; }
        public string? Firebehaviorgeneral1 { get; set; }
        public string? Firebehaviorgeneral2 { get; set; }
        public string? Firebehaviorgeneral3 { get; set; }
        public DateTime? Firediscoverydatetime { get; set; }
        public string? Firemgmtcomplexity { get; set; }
        public string? Incidentname { get; set; }
        public string? Incidentshortdescription { get; set; }
        public decimal? Totalincidentpersonnel { get; set; }
        public DateTime? CreatedondatetimeDt { get; set; }
        public DateTime? ModifiedondatetimeDt { get; set; }
        public Point? Geom { get; set; }
    }
}
