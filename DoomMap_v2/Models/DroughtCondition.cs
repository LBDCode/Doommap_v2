using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class DroughtCondition
    {
        public int Gid { get; set; }
        public double? Objectid { get; set; }
        public int? Dm { get; set; }
        public decimal? ShapeLeng { get; set; }
        public decimal? ShapeArea { get; set; }
        public MultiPolygon? Geom { get; set; }
        public MultiPolygon? Geog { get; set; }

    }
}
