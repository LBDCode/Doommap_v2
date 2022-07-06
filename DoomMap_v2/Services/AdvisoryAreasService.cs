using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IAdvisoryAreasService
    {
        public Task<List<AdvisoryArea>> GetAllAreas();
        public Task<List<DroughtCondition>> GetDroughtsInView(ViewBounds viewBounds);

    }

    public class AdvisoryAreasService: IAdvisoryAreasService
    {
        private readonly DoomMapContext _context;

        public AdvisoryAreasService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<AdvisoryArea>> GetAllAreas()
        { 
            try
            {
                List<AdvisoryArea> areas = new List<AdvisoryArea>();
                areas = await _context.AdvisoryAreas.Where(a => a.ProdType == "Fire Weather Watch" || a.ProdType == "Heat Advisory" || a.ProdType == "Flood Warning").ToListAsync();


                return areas;

            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting all area0 data: " + ex.Message, ex));

            }

        }



        public async Task<List<DroughtCondition>> GetDroughtsInView(ViewBounds viewBounds)
        {
            try
            {
                Envelope envelope = new(viewBounds.xmin, viewBounds.xmax, viewBounds.ymin, viewBounds.ymax);
                GeometryFactory factory = new(new PrecisionModel(), 4326);
                Geometry geometry = factory.ToGeometry(envelope);


                List<DroughtCondition> droughts = await _context.DroughtConditions.Where(c => geometry.Contains(c.Geom)).ToListAsync();


                return droughts;
            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting area data in view: " + ex.Message, ex));

            }

        }
    }
}
