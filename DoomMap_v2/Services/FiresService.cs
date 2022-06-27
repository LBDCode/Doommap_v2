﻿using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IFiresService
    {
        public Task<List<CurrentFire>> GetAllFires();
        //public Task<List<Fire>> GetFireByID(int fireID);

        public Task<List<CurrentFire>> GetFiresInView(ViewBounds viewBounds);

    }

    public class FiresService: IFiresService
    {
        private readonly DoomMapContext _context;

        public FiresService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentFire>> GetAllFires()
        { 
            List<CurrentFire> fires = new List<CurrentFire>();
            fires = await (from FireList in _context.CurrentFires select FireList).ToListAsync();

            return fires;            

        }



        //public async Task<List<Fire>> GetFireByID(int fireID)
        //{
        //    List<Fire> fire = new List<Fire>();
        //    fire = await (from FireList in _context.Fires where FireList.Gid == fireID select FireList)
        //        .ToListAsync();

        //    return fire;

        //}


        public async Task<List<CurrentFire>> GetFiresInView(ViewBounds viewBounds)
        {

            Envelope envelope = new(viewBounds.xmin, viewBounds.xmax, viewBounds.ymin, viewBounds.ymax);
            GeometryFactory factory = new(new PrecisionModel(), 4326);
            Geometry geometry = factory.ToGeometry(envelope);


            List<CurrentFire> fires = await _context.CurrentFires.Where(c => geometry.Contains(c.Geom)).ToListAsync();


            return fires;

        }
    }
}
