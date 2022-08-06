using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class DroughtCondition
    {
        public long? Objectid { get; set; }
        public long? Dm { get; set; }
        public double? ShapeLeng { get; set; }
        public double? ShapeArea { get; set; }
        public MultiPolygon? Geometry { get; set; }
    }
}
