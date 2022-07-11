using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IStormTracksService
    {
        public Task<List<StormTrackLin>> GetAllStormTrackLines();
        public Task<List<StormTrackPgn>> GetAllStormTrackPolygons();

        public Task<List<StormTrackPt>> GetAllStormTrackPoints();

        //public Task<List<Fire>> GetFireByID(int fireID);

        public Task<List<DroughtCondition>> GetStormTracksInView(ViewBounds viewBounds);

    }

    public class StormTracksService : IStormTracksService
    {
        private readonly DoomMapContext _context;

        public StormTracksService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<StormTrackLin>> GetAllStormTrackLines()
        {

            try
            {
                List<StormTrackLin> stormTrackLines = new List<StormTrackLin>();
                stormTrackLines = await (from StormTrackLinesList in _context.StormTrackLins select StormTrackLinesList).ToListAsync();

                return stormTrackLines;
            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting all strom track data: " + ex.Message, ex));

            }


        }

        public async Task<List<StormTrackPgn>> GetAllStormTrackPolygons()
        {

            try
            {
                List<StormTrackPgn> stormTrackPolygons = new List<StormTrackPgn>();
                stormTrackPolygons = await (from StormTrackPolyList in _context.StormTrackPgns select StormTrackPolyList).ToListAsync();

                return stormTrackPolygons;
            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting all strom cone data: " + ex.Message, ex));

            }


        }

        public async Task<List<StormTrackPt>> GetAllStormTrackPoints()
        {


            try
            {
                List<StormTrackPt> stormTrackPoints = new List<StormTrackPt>();
                stormTrackPoints = await (from StormTrackPointsList in _context.StormTrackPts select StormTrackPointsList).ToListAsync();

                return stormTrackPoints;
            }
            catch (Exception ex)
            {
                throw (new System.Exception("ERROR in getting all strom points data: " + ex.Message, ex));

            }


        }


        public async Task<List<DroughtCondition>> GetStormTracksInView(ViewBounds viewBounds)
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
                throw (new System.Exception("ERROR in getting all strom track view Data: " + ex.Message, ex));

            }


        }
    }
}
