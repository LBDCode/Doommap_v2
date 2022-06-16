using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoomMap_v2.Models
{
    public partial class DoomMapContext : DbContext
    {
        public DoomMapContext()
        {
        }

        public DoomMapContext(DbContextOptions<DoomMapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdvisoryArea> AdvisoryAreas { get; set; } = null!;
        public virtual DbSet<CurrentFire> CurrentFires { get; set; } = null!;
        public virtual DbSet<DroughtCondition> DroughtConditions { get; set; } = null!;
        public virtual DbSet<Fire> Fires { get; set; } = null!;
        public virtual DbSet<Gage> Gages { get; set; } = null!;
        public virtual DbSet<None> Nones { get; set; } = null!;
        public virtual DbSet<StormCondition> StormConditions { get; set; } = null!;
        public virtual DbSet<StormTrackLin> StormTrackLins { get; set; } = null!;
        public virtual DbSet<StormTrackPgn> StormTrackPgns { get; set; } = null!;
        public virtual DbSet<StormTrackPt> StormTrackPts { get; set; } = null!;
        public virtual DbSet<WfigsCurrentFire> WfigsCurrentFires { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Host=localhost;Database=DoomMap;Username=postgres;Password=postgresPWlbd", x => x.UseNetTopologySuite());
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<AdvisoryArea>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("currentfireshapefile_pkey");

                entity.ToTable("advisory_areas");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .HasDefaultValueSql("nextval('currentfireshapefile_gid_seq'::regclass)");

                entity.Property(e => e.CapId)
                    .HasMaxLength(254)
                    .HasColumnName("cap_id");

                entity.Property(e => e.Ends)
                    .HasMaxLength(25)
                    .HasColumnName("ends");

                entity.Property(e => e.Event)
                    .HasMaxLength(4)
                    .HasColumnName("event");

                entity.Property(e => e.Expiration)
                    .HasMaxLength(25)
                    .HasColumnName("expiration");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .HasColumnName("geom");

                entity.Property(e => e.Issuance)
                    .HasMaxLength(25)
                    .HasColumnName("issuance");

                entity.Property(e => e.MsgType)
                    .HasMaxLength(3)
                    .HasColumnName("msg_type");

                entity.Property(e => e.Onset)
                    .HasMaxLength(25)
                    .HasColumnName("onset");

                entity.Property(e => e.Phenom)
                    .HasMaxLength(2)
                    .HasColumnName("phenom");

                entity.Property(e => e.ProdType)
                    .HasMaxLength(40)
                    .HasColumnName("prod_type");

                entity.Property(e => e.Sig)
                    .HasMaxLength(1)
                    .HasColumnName("sig");

                entity.Property(e => e.Url)
                    .HasMaxLength(254)
                    .HasColumnName("url");

                entity.Property(e => e.Vtec)
                    .HasMaxLength(48)
                    .HasColumnName("vtec");

                entity.Property(e => e.Wfo)
                    .HasMaxLength(4)
                    .HasColumnName("wfo");
            });

            modelBuilder.Entity<CurrentFire>(entity =>
            {
                entity.HasKey(e => e.Objectid)
                    .HasName("current_fires_pkey");

                entity.ToTable("current_fires");

                entity.Property(e => e.Objectid)
                    .ValueGeneratedNever()
                    .HasColumnName("objectid");

                entity.Property(e => e.CreatedondatetimeDt).HasColumnName("createdondatetime_dt");

                entity.Property(e => e.Dailyacres).HasColumnName("dailyacres");

                entity.Property(e => e.Estimatedcosttodate).HasColumnName("estimatedcosttodate");

                entity.Property(e => e.Firebehaviorgeneral).HasColumnName("firebehaviorgeneral");

                entity.Property(e => e.Firebehaviorgeneral1).HasColumnName("firebehaviorgeneral1");

                entity.Property(e => e.Firebehaviorgeneral2).HasColumnName("firebehaviorgeneral2");

                entity.Property(e => e.Firebehaviorgeneral3).HasColumnName("firebehaviorgeneral3");

                entity.Property(e => e.Firediscoverydatetime).HasColumnName("firediscoverydatetime");

                entity.Property(e => e.Firemgmtcomplexity).HasColumnName("firemgmtcomplexity");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(Point,4326)")
                    .HasColumnName("geom");

                entity.Property(e => e.Incidentname).HasColumnName("incidentname");

                entity.Property(e => e.Incidentshortdescription).HasColumnName("incidentshortdescription");

                entity.Property(e => e.ModifiedondatetimeDt).HasColumnName("modifiedondatetime_dt");

                entity.Property(e => e.Totalincidentpersonnel).HasColumnName("totalincidentpersonnel");
            });

            modelBuilder.Entity<DroughtCondition>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("drought_conditions_pkey");

                entity.ToTable("drought_conditions");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Dm).HasColumnName("dm");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .HasColumnName("geom");

                entity.Property(e => e.Objectid).HasColumnName("objectid");

                entity.Property(e => e.ShapeArea).HasColumnName("shape_area");

                entity.Property(e => e.ShapeLeng).HasColumnName("shape_leng");
            });

            modelBuilder.Entity<Fire>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("fireshapefile_pkey");

                entity.ToTable("fires");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .HasDefaultValueSql("nextval('fireshapefile_gid_seq'::regclass)");

                //entity.Property(e => e.AcqDate).HasColumnName("acq_date");

                entity.Property(e => e.AcqTime)
                    .HasMaxLength(4)
                    .HasColumnName("acq_time");

                entity.Property(e => e.BrightT31).HasColumnName("bright_t31");

                entity.Property(e => e.Brightness).HasColumnName("brightness");

                entity.Property(e => e.Confidence).HasColumnName("confidence");

                entity.Property(e => e.Daynight)
                    .HasMaxLength(1)
                    .HasColumnName("daynight");

                entity.Property(e => e.Frp).HasColumnName("frp");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(Point)")
                    .HasColumnName("geom");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Satellite)
                    .HasMaxLength(1)
                    .HasColumnName("satellite");

                entity.Property(e => e.Scan).HasColumnName("scan");

                entity.Property(e => e.Track).HasColumnName("track");

                entity.Property(e => e.Version)
                    .HasMaxLength(6)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Gage>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("gages_pkey");

                entity.ToTable("gages");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AgencyCd).HasColumnName("agency_cd");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.DatumType).HasColumnName("datum_type");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.LocationGeom)
                    .HasColumnType("geometry(Point,4326)")
                    .HasColumnName("location_geom");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.SiteNo).HasColumnName("site_no");

                entity.Property(e => e.StateAbv).HasColumnName("state_abv");

                entity.Property(e => e.StationNm).HasColumnName("station_nm");
            });

            modelBuilder.Entity<None>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("none_pkey");

                entity.ToTable("none");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.CapId)
                    .HasMaxLength(254)
                    .HasColumnName("cap_id");

                entity.Property(e => e.Ends)
                    .HasMaxLength(25)
                    .HasColumnName("ends");

                entity.Property(e => e.Event)
                    .HasMaxLength(4)
                    .HasColumnName("event");

                entity.Property(e => e.Expiration)
                    .HasMaxLength(25)
                    .HasColumnName("expiration");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .HasColumnName("geom");

                entity.Property(e => e.Issuance)
                    .HasMaxLength(25)
                    .HasColumnName("issuance");

                entity.Property(e => e.MsgType)
                    .HasMaxLength(3)
                    .HasColumnName("msg_type");

                entity.Property(e => e.Onset)
                    .HasMaxLength(25)
                    .HasColumnName("onset");

                entity.Property(e => e.Phenom)
                    .HasMaxLength(2)
                    .HasColumnName("phenom");

                entity.Property(e => e.ProdType)
                    .HasMaxLength(40)
                    .HasColumnName("prod_type");

                entity.Property(e => e.Sig)
                    .HasMaxLength(1)
                    .HasColumnName("sig");

                entity.Property(e => e.Url)
                    .HasMaxLength(254)
                    .HasColumnName("url");

                entity.Property(e => e.Vtec)
                    .HasMaxLength(48)
                    .HasColumnName("vtec");

                entity.Property(e => e.Wfo)
                    .HasMaxLength(4)
                    .HasColumnName("wfo");
            });

            modelBuilder.Entity<StormCondition>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("storm_conditions_pkey");

                entity.ToTable("storm_conditions");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon)")
                    .HasColumnName("geom");

                entity.Property(e => e.MaxFt).HasColumnName("max_ft");

                entity.Property(e => e.MinFt).HasColumnName("min_ft");
            });

            modelBuilder.Entity<StormTrackLin>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("storm_track_lin_pkey");

                entity.ToTable("storm_track_lin");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Advdate)
                    .HasMaxLength(50)
                    .HasColumnName("advdate");

                entity.Property(e => e.Advisnum)
                    .HasMaxLength(50)
                    .HasColumnName("advisnum");

                entity.Property(e => e.Basin)
                    .HasMaxLength(50)
                    .HasColumnName("basin");

                entity.Property(e => e.Fcstprd).HasColumnName("fcstprd");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiLineString)")
                    .HasColumnName("geom");

                entity.Property(e => e.Stormname)
                    .HasMaxLength(50)
                    .HasColumnName("stormname");

                entity.Property(e => e.Stormnum).HasColumnName("stormnum");

                entity.Property(e => e.Stormtype)
                    .HasMaxLength(50)
                    .HasColumnName("stormtype");
            });

            modelBuilder.Entity<StormTrackPgn>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("storm_track_pgn_pkey");

                entity.ToTable("storm_track_pgn");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Advdate)
                    .HasMaxLength(50)
                    .HasColumnName("advdate");

                entity.Property(e => e.Advisnum)
                    .HasMaxLength(50)
                    .HasColumnName("advisnum");

                entity.Property(e => e.Basin)
                    .HasMaxLength(50)
                    .HasColumnName("basin");

                entity.Property(e => e.Fcstprd).HasColumnName("fcstprd");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon)")
                    .HasColumnName("geom");

                entity.Property(e => e.Stormname)
                    .HasMaxLength(50)
                    .HasColumnName("stormname");

                entity.Property(e => e.Stormnum).HasColumnName("stormnum");

                entity.Property(e => e.Stormtype)
                    .HasMaxLength(50)
                    .HasColumnName("stormtype");
            });

            modelBuilder.Entity<StormTrackPt>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("storm_track_pts_pkey");

                entity.ToTable("storm_track_pts");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Advdate)
                    .HasMaxLength(50)
                    .HasColumnName("advdate");

                entity.Property(e => e.Advisnum)
                    .HasMaxLength(50)
                    .HasColumnName("advisnum");

                entity.Property(e => e.Basin)
                    .HasMaxLength(50)
                    .HasColumnName("basin");

                entity.Property(e => e.Datelbl)
                    .HasMaxLength(50)
                    .HasColumnName("datelbl");

                entity.Property(e => e.Dvlbl)
                    .HasMaxLength(50)
                    .HasColumnName("dvlbl");

                entity.Property(e => e.Fcstprd).HasColumnName("fcstprd");

                entity.Property(e => e.Fldatelbl)
                    .HasMaxLength(50)
                    .HasColumnName("fldatelbl");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(Point)")
                    .HasColumnName("geom");

                entity.Property(e => e.Gust).HasColumnName("gust");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Maxwind).HasColumnName("maxwind");

                entity.Property(e => e.Mslp).HasColumnName("mslp");

                entity.Property(e => e.Ssnum).HasColumnName("ssnum");

                entity.Property(e => e.Stormname)
                    .HasMaxLength(50)
                    .HasColumnName("stormname");

                entity.Property(e => e.Stormnum).HasColumnName("stormnum");

                entity.Property(e => e.Stormsrc)
                    .HasMaxLength(50)
                    .HasColumnName("stormsrc");

                entity.Property(e => e.Stormtype)
                    .HasMaxLength(50)
                    .HasColumnName("stormtype");

                entity.Property(e => e.Tau).HasColumnName("tau");

                entity.Property(e => e.Tcdir).HasColumnName("tcdir");

                entity.Property(e => e.Tcdvlp)
                    .HasMaxLength(50)
                    .HasColumnName("tcdvlp");

                entity.Property(e => e.Tcspd).HasColumnName("tcspd");

                entity.Property(e => e.Timezone)
                    .HasMaxLength(50)
                    .HasColumnName("timezone");

                entity.Property(e => e.Validtime)
                    .HasMaxLength(50)
                    .HasColumnName("validtime");
            });

            modelBuilder.Entity<WfigsCurrentFire>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("wfigs_current_fires_pkey");

                entity.ToTable("wfigs_current_fires");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Abcdmisc)
                    .HasMaxLength(4)
                    .HasColumnName("abcdmisc");

                entity.Property(e => e.Adspermiss)
                    .HasMaxLength(7)
                    .HasColumnName("adspermiss");

                entity.Property(e => e.Calculated).HasColumnName("calculated");

                entity.Property(e => e.Containmen).HasColumnName("containmen");

                entity.Property(e => e.Controldat).HasColumnName("controldat");

                entity.Property(e => e.Createdbys)
                    .HasMaxLength(16)
                    .HasColumnName("createdbys");

                entity.Property(e => e.Createdond).HasColumnName("createdond");

                entity.Property(e => e.Dailyacres).HasColumnName("dailyacres");

                entity.Property(e => e.Discoverya).HasColumnName("discoverya");

                entity.Property(e => e.Dispatchce)
                    .HasMaxLength(6)
                    .HasColumnName("dispatchce");

                entity.Property(e => e.Finalfir1)
                    .HasMaxLength(1)
                    .HasColumnName("finalfir_1");

                entity.Property(e => e.Finalfir2).HasColumnName("finalfir_2");

                entity.Property(e => e.Finalfirer)
                    .HasMaxLength(1)
                    .HasColumnName("finalfirer");

                entity.Property(e => e.Firebeha1)
                    .HasMaxLength(17)
                    .HasColumnName("firebeha_1");

                entity.Property(e => e.Firebeha2)
                    .HasMaxLength(20)
                    .HasColumnName("firebeha_2");

                entity.Property(e => e.Firebeha3)
                    .HasMaxLength(20)
                    .HasColumnName("firebeha_3");

                entity.Property(e => e.Firebehavi)
                    .HasMaxLength(8)
                    .HasColumnName("firebehavi");

                entity.Property(e => e.Firecause)
                    .HasMaxLength(12)
                    .HasColumnName("firecause");

                entity.Property(e => e.Firecauseg)
                    .HasMaxLength(19)
                    .HasColumnName("firecauseg");

                entity.Property(e => e.Firecauses)
                    .HasMaxLength(36)
                    .HasColumnName("firecauses");

                entity.Property(e => e.Firecode)
                    .HasMaxLength(4)
                    .HasColumnName("firecode");

                entity.Property(e => e.Firedepart)
                    .HasMaxLength(5)
                    .HasColumnName("firedepart");

                entity.Property(e => e.Firediscov).HasColumnName("firediscov");

                entity.Property(e => e.Firemgmtco)
                    .HasMaxLength(15)
                    .HasColumnName("firemgmtco");

                entity.Property(e => e.Fireoutdat).HasColumnName("fireoutdat");

                entity.Property(e => e.Firestra1).HasColumnName("firestra_1");

                entity.Property(e => e.Firestra2).HasColumnName("firestra_2");

                entity.Property(e => e.Firestra3).HasColumnName("firestra_3");

                entity.Property(e => e.Firestrate).HasColumnName("firestrate");

                entity.Property(e => e.Fsjobcode)
                    .HasMaxLength(2)
                    .HasColumnName("fsjobcode");

                entity.Property(e => e.Fsoverride)
                    .HasMaxLength(4)
                    .HasColumnName("fsoverride");

                entity.Property(e => e.Gacc)
                    .HasMaxLength(4)
                    .HasColumnName("gacc");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(Point)")
                    .HasColumnName("geom");

                entity.Property(e => e.Ics209re1).HasColumnName("ics209re_1");

                entity.Property(e => e.Ics209re2).HasColumnName("ics209re_2");

                entity.Property(e => e.Ics209re3)
                    .HasMaxLength(1)
                    .HasColumnName("ics209re_3");

                entity.Property(e => e.Ics209repo).HasColumnName("ics209repo");

                entity.Property(e => e.Incident1)
                    .HasMaxLength(2)
                    .HasColumnName("incident_1");

                entity.Property(e => e.Incidentma)
                    .HasMaxLength(11)
                    .HasColumnName("incidentma");

                entity.Property(e => e.Incidentna)
                    .HasMaxLength(30)
                    .HasColumnName("incidentna");

                entity.Property(e => e.Incidentsh)
                    .HasMaxLength(73)
                    .HasColumnName("incidentsh");

                entity.Property(e => e.Incidentty)
                    .HasMaxLength(2)
                    .HasColumnName("incidentty");

                entity.Property(e => e.Initiallat).HasColumnName("initiallat");

                entity.Property(e => e.Initiallon).HasColumnName("initiallon");

                entity.Property(e => e.Initialr1).HasColumnName("initialr_1");

                entity.Property(e => e.Initialres).HasColumnName("initialres");

                entity.Property(e => e.Irwinid)
                    .HasMaxLength(36)
                    .HasColumnName("irwinid");

                entity.Property(e => e.Isdispatch).HasColumnName("isdispatch");

                entity.Property(e => e.Isfirecaus).HasColumnName("isfirecaus");

                entity.Property(e => e.Isfirecode).HasColumnName("isfirecode");

                entity.Property(e => e.Isfsassist).HasColumnName("isfsassist");

                entity.Property(e => e.Ismultijur).HasColumnName("ismultijur");

                entity.Property(e => e.Isreimburs).HasColumnName("isreimburs");

                entity.Property(e => e.Istrespass).HasColumnName("istrespass");

                entity.Property(e => e.Isunifiedc).HasColumnName("isunifiedc");

                entity.Property(e => e.Localincid)
                    .HasMaxLength(10)
                    .HasColumnName("localincid");

                entity.Property(e => e.Modifiedby)
                    .HasMaxLength(16)
                    .HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon).HasColumnName("modifiedon");

                entity.Property(e => e.Objectid).HasColumnName("objectid");

                entity.Property(e => e.Organizati)
                    .HasMaxLength(15)
                    .HasColumnName("organizati");

                entity.Property(e => e.Percentcon).HasColumnName("percentcon");

                entity.Property(e => e.Percentper).HasColumnName("percentper");

                entity.Property(e => e.Poocity)
                    .HasMaxLength(33)
                    .HasColumnName("poocity");

                entity.Property(e => e.Poocounty)
                    .HasMaxLength(20)
                    .HasColumnName("poocounty");

                entity.Property(e => e.Poodispatc)
                    .HasMaxLength(6)
                    .HasColumnName("poodispatc");

                entity.Property(e => e.Poofips)
                    .HasMaxLength(5)
                    .HasColumnName("poofips");

                entity.Property(e => e.Poojuris1)
                    .HasMaxLength(5)
                    .HasColumnName("poojuris_1");

                entity.Property(e => e.Poojuris2)
                    .HasMaxLength(1)
                    .HasColumnName("poojuris_2");

                entity.Property(e => e.Poojurisdi)
                    .HasMaxLength(5)
                    .HasColumnName("poojurisdi");

                entity.Property(e => e.Poolando1)
                    .HasMaxLength(7)
                    .HasColumnName("poolando_1");

                entity.Property(e => e.Poolandown)
                    .HasMaxLength(7)
                    .HasColumnName("poolandown");

                entity.Property(e => e.Poolegal1)
                    .HasMaxLength(2)
                    .HasColumnName("poolegal_1");

                entity.Property(e => e.Poolegal2)
                    .HasMaxLength(2)
                    .HasColumnName("poolegal_2");

                entity.Property(e => e.Poolegal3)
                    .HasMaxLength(4)
                    .HasColumnName("poolegal_3");

                entity.Property(e => e.Poolegal4).HasColumnName("poolegal_4");

                entity.Property(e => e.Poolegal5)
                    .HasMaxLength(4)
                    .HasColumnName("poolegal_5");

                entity.Property(e => e.Poolegalde)
                    .HasMaxLength(14)
                    .HasColumnName("poolegalde");

                entity.Property(e => e.Poopredict)
                    .HasMaxLength(5)
                    .HasColumnName("poopredict");

                entity.Property(e => e.Pooprote1)
                    .HasMaxLength(6)
                    .HasColumnName("pooprote_1");

                entity.Property(e => e.Pooprotect)
                    .HasMaxLength(3)
                    .HasColumnName("pooprotect");

                entity.Property(e => e.Poostate)
                    .HasMaxLength(5)
                    .HasColumnName("poostate");

                entity.Property(e => e.Predomin1)
                    .HasMaxLength(3)
                    .HasColumnName("predomin_1");

                entity.Property(e => e.Predominan)
                    .HasMaxLength(11)
                    .HasColumnName("predominan");

                entity.Property(e => e.Primaryfue)
                    .HasMaxLength(30)
                    .HasColumnName("primaryfue");

                entity.Property(e => e.Secondaryf)
                    .HasMaxLength(30)
                    .HasColumnName("secondaryf");

                entity.Property(e => e.Source)
                    .HasMaxLength(5)
                    .HasColumnName("source");

                entity.Property(e => e.Strategicd).HasColumnName("strategicd");

                entity.Property(e => e.Totalincid).HasColumnName("totalincid");

                entity.Property(e => e.Uniquefire)
                    .HasMaxLength(21)
                    .HasColumnName("uniquefire");

                entity.Property(e => e.Wfdssdecis)
                    .HasMaxLength(17)
                    .HasColumnName("wfdssdecis");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
