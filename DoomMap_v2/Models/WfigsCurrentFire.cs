using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DoomMap_v2.Models
{
    public partial class WfigsCurrentFire
    {
        public int Gid { get; set; }
        public int? Objectid { get; set; }
        public string? Abcdmisc { get; set; }
        public string? Adspermiss { get; set; }
        public decimal? Calculated { get; set; }
        public DateOnly? Containmen { get; set; }
        public DateOnly? Controldat { get; set; }
        public decimal? Dailyacres { get; set; }
        public decimal? Discoverya { get; set; }
        public string? Dispatchce { get; set; }
        public string? Finalfirer { get; set; }
        public string? Finalfir1 { get; set; }
        public DateOnly? Finalfir2 { get; set; }
        public string? Firebehavi { get; set; }
        public string? Firebeha1 { get; set; }
        public string? Firebeha2 { get; set; }
        public string? Firebeha3 { get; set; }
        public string? Firecause { get; set; }
        public string? Firecauseg { get; set; }
        public string? Firecauses { get; set; }
        public string? Firecode { get; set; }
        public string? Firedepart { get; set; }
        public DateOnly? Firediscov { get; set; }
        public string? Firemgmtco { get; set; }
        public DateOnly? Fireoutdat { get; set; }
        public short? Firestrate { get; set; }
        public short? Firestra1 { get; set; }
        public short? Firestra2 { get; set; }
        public short? Firestra3 { get; set; }
        public string? Fsjobcode { get; set; }
        public string? Fsoverride { get; set; }
        public string? Gacc { get; set; }
        public DateOnly? Ics209repo { get; set; }
        public DateOnly? Ics209re1 { get; set; }
        public DateOnly? Ics209re2 { get; set; }
        public string? Ics209re3 { get; set; }
        public string? Incidentma { get; set; }
        public string? Incidentna { get; set; }
        public string? Incidentsh { get; set; }
        public string? Incidentty { get; set; }
        public string? Incident1 { get; set; }
        public decimal? Initiallat { get; set; }
        public decimal? Initiallon { get; set; }
        public decimal? Initialres { get; set; }
        public DateOnly? Initialr1 { get; set; }
        public string? Irwinid { get; set; }
        public short? Isfirecaus { get; set; }
        public short? Isfirecode { get; set; }
        public short? Isfsassist { get; set; }
        public short? Ismultijur { get; set; }
        public short? Isreimburs { get; set; }
        public short? Istrespass { get; set; }
        public short? Isunifiedc { get; set; }
        public string? Localincid { get; set; }
        public short? Percentcon { get; set; }
        public short? Percentper { get; set; }
        public string? Poocity { get; set; }
        public string? Poocounty { get; set; }
        public string? Poodispatc { get; set; }
        public string? Poofips { get; set; }
        public string? Poojurisdi { get; set; }
        public string? Poojuris1 { get; set; }
        public string? Poojuris2 { get; set; }
        public string? Poolandown { get; set; }
        public string? Poolando1 { get; set; }
        public string? Poolegalde { get; set; }
        public string? Poolegal1 { get; set; }
        public string? Poolegal2 { get; set; }
        public string? Poolegal3 { get; set; }
        public short? Poolegal4 { get; set; }
        public string? Poolegal5 { get; set; }
        public string? Poopredict { get; set; }
        public string? Pooprotect { get; set; }
        public string? Pooprote1 { get; set; }
        public string? Poostate { get; set; }
        public string? Predominan { get; set; }
        public string? Predomin1 { get; set; }
        public string? Primaryfue { get; set; }
        public string? Secondaryf { get; set; }
        public short? Totalincid { get; set; }
        public string? Uniquefire { get; set; }
        public string? Wfdssdecis { get; set; }
        public string? Createdbys { get; set; }
        public string? Modifiedby { get; set; }
        public short? Isdispatch { get; set; }
        public string? Organizati { get; set; }
        public DateOnly? Strategicd { get; set; }
        public DateOnly? Createdond { get; set; }
        public DateOnly? Modifiedon { get; set; }
        public string? Source { get; set; }
        public Point? Geom { get; set; }
    }
}
