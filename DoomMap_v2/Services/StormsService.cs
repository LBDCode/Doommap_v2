using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IStormsService
    {
        public Task<List<StormCondition>> GetAllStorms();
        //public Task<List<Fire>> GetFireByID(int fireID);

        public Task<List<StormCondition>> GetStormsInView(ViewBounds viewBounds);

    }

    public class StormsService: IStormsService
    {
        private readonly DoomMapContext _context;

        public StormsService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<StormCondition>> GetAllStorms()
        { 

            try
            {
                List<StormCondition> storms = new List<StormCondition>();
                storms = await (from StormsList in _context.StormConditions select StormsList).ToListAsync();

                return storms;
            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting all storm data: " + ex.Message, ex));

            }

        }

        public async Task<List<StormCondition>> GetStormsInView(ViewBounds viewBounds)
        {


            try
            {
                Envelope envelope = new(viewBounds.xmin, viewBounds.xmax, viewBounds.ymin, viewBounds.ymax);
                GeometryFactory factory = new(new PrecisionModel(), 4326);
                Geometry geometry = factory.ToGeometry(envelope);

                List<StormCondition> storms = await _context.StormConditions.Where(c => geometry.Contains(c.Geom)).ToListAsync();

                return storms;

            }
            catch (Exception ex)
            {
                throw (new System.Exception("Error in getting all storm view data: " + ex.Message));
            }

        }
    }
}
