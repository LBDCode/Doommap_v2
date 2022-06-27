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

        public static List<CurrentFire> GetEmptyFiresList()
        {
            return new List<CurrentFire>();
        }


        public static List<CurrentFire> GetTestFires() => new()
        {

            new CurrentFire
            {

                Objectid = 248423,
                Dailyacres = 319840,
                Estimatedcosttodate = 206357595,
                Firebehaviorgeneral = "Moderate",
                Firebehaviorgeneral1 = "Flanking",
                Firebehaviorgeneral2 = "Backing",
                Firebehaviorgeneral3 = "Spotting",
                Firediscoverydatetime = DateTime.Parse("2022-04-06T00:00:00"),
                Firemgmtcomplexity = "Type 1 Incident",
                Incidentname = "Hermits Peak",
                Incidentshortdescription = "12 Miles NW of Las Vegas NM",
                Totalincidentpersonnel = 2685,
                CreatedondatetimeDt =  DateTime.Parse("2022-04-06T00:00:00"),
                ModifiedondatetimeDt =  DateTime.Parse("2022-06-10T00:00:00"),
                Geom = new Point(-105.399, 35.718),
            },
            new CurrentFire
            {
                Objectid = 250161,
                Dailyacres = 59359,
                Estimatedcosttodate = 12500000,
                Firebehaviorgeneral = "Minimal",
                Firebehaviorgeneral1 = "Backing",
                Firebehaviorgeneral2 = "Creeping",
                Firebehaviorgeneral3 = "Smoldering",
                Firediscoverydatetime = DateTime.Parse("2022-04-17T00:00:00"),
                Firemgmtcomplexity = "Type 2 Incident",
                Incidentname = "Cooks Peak",
                Incidentshortdescription = "Northeast of Ocate NM, burning on private and state trust",
                Totalincidentpersonnel = 15,
                CreatedondatetimeDt = DateTime.Parse("2022-04-17T00:00:00"),
                ModifiedondatetimeDt =  DateTime.Parse("2022-05-31T00:00:00"),
                Geom = new Point(-105.037, 36.244),
            },
            new CurrentFire
            {
                Objectid = 250173,
                Dailyacres = 19105,
                Estimatedcosttodate = 5078000,
                Firebehaviorgeneral = "Minimal",
                Firebehaviorgeneral1 = "Smoldering",
                Firebehaviorgeneral2 = "Smoldering",
                Firebehaviorgeneral3 = "Smoldering",
                Firediscoverydatetime = DateTime.Parse("2022-04-17T00:00:00"),
                Firemgmtcomplexity = "Type 4 Incident",
                Incidentname = "Tunnel",
                Incidentshortdescription = "Northeast of city of Flagstaff city limits",
                Totalincidentpersonnel = 0,
                CreatedondatetimeDt = DateTime.Parse("2022-04-17T00:00:00"),
                ModifiedondatetimeDt =  DateTime.Parse("2022-06-02T00:00:00"),
                Geom = new Point(-111.588, 35.304),
            }
        };
    }
}










