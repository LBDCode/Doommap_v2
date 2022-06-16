using DoomMap_v2.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoomMap_v2.Services
{
    public interface IFiresService
    {
        public Task<List<Fire>> GetAllFires();
        public Task<List<Fire>> GetFireByID(int fireID);

    }

    public class FiresService: IFiresService
    {
        private readonly DoomMapContext _context;

        public FiresService(DoomMapContext context)
        {
            _context = context;
        }

        public async Task<List<Fire>> GetAllFires()
        { 
            List<Fire> fires = new List<Fire>();
            fires = await (from FireList in _context.Fires select FireList).ToListAsync();

            return fires;            

        }



        public async Task<List<Fire>> GetFireByID(int fireID)
        {
            List<Fire> fire = new List<Fire>();
            fire = await (from FireList in _context.Fires where FireList.Gid == fireID select FireList)
                .ToListAsync();

            return fire;

        }
    }
}
