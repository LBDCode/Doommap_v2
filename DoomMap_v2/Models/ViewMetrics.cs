using System;
using System.ComponentModel.DataAnnotations;


namespace DoomMap_v2.Models
{
    public class ViewMetrics
    {
        [Key]
        public int numberFires { get; set; }

        public decimal totalDailyAcres { get; set; }

        public int numberDroughts { get; set; }

        public decimal acresDroughts { get; set; }

        public List<ViewAdvisoryAreasMetrics>? ViewAdvisoryAreasMetrics { get; set; }


    }

    public partial class ViewAdvisoryAreasMetrics
    {
        public string? areaType { get; set; }

        public int areaCount { get; set; }    

        public double? containedArea { get; set; }
    }
}
