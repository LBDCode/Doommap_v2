using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class StormCondition
    {
        public int Gid { get; set; }
        public double? MinFt { get; set; }
        public double? MaxFt { get; set; }
        public MultiPolygon? Geom { get; set; }
    }
}
