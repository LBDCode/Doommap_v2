using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IMetricsService
    {
        Task<List<CurrentFire>> GetAllMetrics();
        Task<ViewMetrics> GetMetricsInView(ViewBounds viewBounds);
    }

    public class MetricsService: IMetricsService
    {
        private readonly DoomMapContext _context;

        public MetricsService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentFire>> GetAllMetrics()
        { 
            List<CurrentFire> fires = new List<CurrentFire>();
            fires = await (from FireList in _context.CurrentFires select FireList).ToListAsync();

            return fires;            

        }

        public async Task<ViewMetrics> GetMetricsInView(ViewBounds viewBounds)
        {

            Envelope envelope = new(viewBounds.xmin, viewBounds.xmax, viewBounds.ymin, viewBounds.ymax);
            GeometryFactory factory = new(new PrecisionModel(), 4326);
            Geometry geometry = factory.ToGeometry(envelope);


            //List<CurrentFire> fires = await _context.CurrentFires.Where(c => geometry.Contains(c.Geom)).ToListAsync();

            var fires = await (from c in _context.CurrentFires
                   where geometry.Contains(c.Geom)
                   group c by 1 into grp
                   select new
                   {
                       rowCount = grp.Count(),
                       rowSum = grp.Sum(x => x.Dailyacres)
                   }).ToListAsync();



            var droughts = await (from c in _context.DroughtConditions
                    where geometry.Intersects(c.Geom)
                    group c by 1 into grp
                    select new
                    {
                        rowCount = grp.Count(),
                        rowSum = grp.Sum(x => x.ShapeArea),
                        containedArea = grp.Sum(x => x.Geog.Intersection(geometry).Area) * 0.000247105,
                    }).ToListAsync();




            List<ViewAdvisoryAreasMetrics> areas = await (from a in _context.AdvisoryAreas 
                               where geometry.Intersects(a.Geom)
                               where a.ProdType == "Fire Weather Watch" || a.ProdType == "Heat Advisory" || a.ProdType == "Flood Warning"
                               group a by a.ProdType into grp
                               select new ViewAdvisoryAreasMetrics
                               {
                                   areaType = grp.Key,
                                   areaCount = grp.Count(),
                                   containedArea = grp.Sum(x => x.Geog.Intersection(geometry).Area) * 0.000247105,
                               }

                               ).ToListAsync();



            int numberFires = fires.Count() > 0 ? fires[0].rowCount : 0;
            decimal totalDailyAcres = fires.Count() > 0 ? (decimal)fires[0].rowSum : (decimal)0.0;
            int numberDroughts = droughts.Count() > 0 ?  droughts[0].rowCount : 0;
            decimal acresDroughts = droughts.Count() > 0 ?  (decimal)droughts[0].containedArea : (decimal)0.0;



            ViewMetrics metrics = new ViewMetrics();

            metrics.numberFires = numberFires;
            metrics.totalDailyAcres = totalDailyAcres;
            metrics.numberDroughts = numberDroughts;
            metrics.acresDroughts = acresDroughts;
            metrics.ViewAdvisoryAreasMetrics = areas;


            return metrics;

        }
    }
}
