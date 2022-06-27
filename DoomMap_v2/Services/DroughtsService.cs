using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IDroughtsService
    {
        public Task<List<DroughtCondition>> GetAllDroughts();
        //public Task<List<Fire>> GetFireByID(int fireID);

        public Task<List<DroughtCondition>> GetDroughtsInView(ViewBounds viewBounds);

    }

    public class DroughtsService: IDroughtsService
    {
        private readonly DoomMapContext _context;

        public DroughtsService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<DroughtCondition>> GetAllDroughts()
        { 
            List<DroughtCondition> droughts = new List<DroughtCondition>();
            droughts = await (from DroughtList in _context.DroughtConditions select DroughtList).ToListAsync();

            return droughts;            

        }



        //public async Task<List<Fire>> GetFireByID(int fireID)
        //{
        //    List<Fire> fire = new List<Fire>();
        //    fire = await (from FireList in _context.Fires where FireList.Gid == fireID select FireList)
        //        .ToListAsync();

        //    return fire;

        //}


        public async Task<List<DroughtCondition>> GetDroughtsInView(ViewBounds viewBounds)
        {

            Envelope envelope = new(viewBounds.xmin, viewBounds.xmax, viewBounds.ymin, viewBounds.ymax);
            GeometryFactory factory = new(new PrecisionModel(), 4326);
            Geometry geometry = factory.ToGeometry(envelope);


            List<DroughtCondition> droughts = await _context.DroughtConditions.Where(c => geometry.Contains(c.Geom)).ToListAsync();


            return droughts;

        }
    }
}
