using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class SoilsAdvisory
    {
        public string? Label { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? StartDt2 { get; set; }
        public string? EndDt2 { get; set; }
        public Geometry? Geometry { get; set; }
    }
}
