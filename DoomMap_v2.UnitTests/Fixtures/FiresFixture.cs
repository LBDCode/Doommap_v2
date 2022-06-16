using DoomMap_v2.Models;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomMap_v2.UnitTests.Fixtures
{
    public static class FiresFixture
    {

        public static List<Fire> GetEmptyFiresList()
        {
            return new List<Fire>();
        }


        public static List<Fire> GetTestFireByID() => new()
        {
            new Fire
            {
                Gid = 1,
                Latitude = (decimal?)18.925,
                Longitude = (decimal?)-70.349,
                Brightness = (decimal?)320.1,
                Scan = 1,
                Track = 1,
                AcqTime = "0250",
                Satellite = "T",
                Confidence = 100,
                Version = "6.1NRT",
                BrightT31 = (decimal?)293.9,
                Frp = (decimal?)16.9,
                Daynight = "N",
                Geom = new Point(-70.349, 18.925)
            },

        };


        public static List<Fire> GetTestFires() => new()
        {

            new Fire
            {
                Gid = 1,
                Latitude = (decimal?)18.925,
                Longitude = (decimal?)-70.349,
                Brightness = (decimal?)320.1,
                Scan = 1,
                Track = 1,
                AcqTime = "0250",
                Satellite = "T",
                Confidence = 100,
                Version = "6.1NRT",
                BrightT31 = (decimal?)293.9,
                Frp = (decimal?)16.9,
                Daynight = "N",
                Geom = new Point(-70.349, 18.925)
            },            
            new Fire
            {
                Gid = 2,
                Latitude = (decimal?)18.923,
                Longitude = (decimal?)-70.359,
                Brightness = (decimal?)320.9,
                Scan = 1,
                Track = 1,
                AcqTime = "0250",
                Satellite = "T",
                Confidence = 100,
                Version = "6.1NRT",
                BrightT31 = (decimal?)294.2,
                Frp = (decimal?)17.8,
                Daynight = "N",
                Geom = new Point(-70.359, 18.923)
            },
            new Fire
            {
                Gid = 3,
                Latitude = (decimal?)42.298,
                Longitude = (decimal?)-83.153,
                Brightness = (decimal?)300.5,
                Scan = (decimal?)1.9,
                Track = (decimal?)1.3,
                AcqTime = "0300",
                Satellite = "T",
                Confidence = 29,
                Version = "6.1NRT",
                BrightT31 = (decimal?)286,
                Frp = (decimal?)12.9,
                Daynight = "N",
                Geom = new Point(-83.153, 42.298)
            }
        };
    }
}





