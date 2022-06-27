using System;
using System.ComponentModel.DataAnnotations;


namespace DoomMap_v2.Models
{
    public class ViewBounds
    {
        [Key]
        public double xmin { get; set; }
        public double xmax { get; set; }
        public double ymin { get; set; }
        public double ymax { get; set; }

    }
}
