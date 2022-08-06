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
        public virtual DbSet<PrcpAdvisory> PrcpAdvisories { get; set; } = null!;
        public virtual DbSet<SoilsAdvisory> SoilsAdvisories { get; set; } = null!;
        public virtual DbSet<StormCondition> StormConditions { get; set; } = null!;
        public virtual DbSet<StormTrackLin> StormTrackLins { get; set; } = null!;
        public virtual DbSet<StormTrackPgn> StormTrackPgns { get; set; } = null!;
        public virtual DbSet<StormTrackPt> StormTrackPts { get; set; } = null!;
        public virtual DbSet<TempAdvisory> TempAdvisories { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Server=doommapserver.postgres.database.azure.com;Database=DoomMap;Port=5432;User Id=doommap2022;Password=blueridge9!23;", x => x.UseNetTopologySuite());
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<AdvisoryArea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("advisory_areas");

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

                entity.Property(e => e.Geog)
                    .HasColumnType("geography")
                    .HasColumnName("geog")
                    .HasComputedColumnSql("(geom)::geography", true);

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .HasColumnName("geom");

                entity.Property(e => e.Gid).HasColumnName("gid");

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
                entity.HasNoKey();

                entity.ToTable("drought_conditions");

                entity.HasIndex(e => e.Geometry, "idx_drought_conditions_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.Dm).HasColumnName("DM");

                entity.Property(e => e.Geometry)
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .HasColumnName("geometry");

                entity.Property(e => e.Objectid).HasColumnName("OBJECTID");

                entity.Property(e => e.ShapeArea).HasColumnName("Shape_Area");

                entity.Property(e => e.ShapeLeng).HasColumnName("Shape_Leng");
            });

            modelBuilder.Entity<PrcpAdvisory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Prcp_advisories");

                entity.HasIndex(e => e.Geometry, "idx_Prcp_advisories_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.EndDate).HasColumnName("End_Date");

                entity.Property(e => e.EndDt2).HasColumnName("End_Dt2");

                entity.Property(e => e.Geometry)
                    .HasColumnType("geometry(Geometry,4326)")
                    .HasColumnName("geometry");

                entity.Property(e => e.StartDate).HasColumnName("Start_Date");

                entity.Property(e => e.StartDt2).HasColumnName("Start_Dt2");
            });

            modelBuilder.Entity<SoilsAdvisory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Soils_advisories");

                entity.HasIndex(e => e.Geometry, "idx_Soils_advisories_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.EndDate).HasColumnName("End_Date");

                entity.Property(e => e.EndDt2).HasColumnName("End_Dt2");

                entity.Property(e => e.Geometry)
                    .HasColumnType("geometry(Geometry,4326)")
                    .HasColumnName("geometry");

                entity.Property(e => e.StartDate).HasColumnName("Start_Date");

                entity.Property(e => e.StartDt2).HasColumnName("Start_Dt2");
            });

            modelBuilder.Entity<StormCondition>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("storm_conditions");

                entity.Property(e => e.Geom)
                    .HasColumnType("geometry(MultiPolygon)")
                    .HasColumnName("geom");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.MaxFt).HasColumnName("max_ft");

                entity.Property(e => e.MinFt).HasColumnName("min_ft");
            });

            modelBuilder.Entity<StormTrackLin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("storm_track_lin");

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

                entity.Property(e => e.Gid).HasColumnName("gid");

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
                entity.HasNoKey();

                entity.ToTable("storm_track_pgn");

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

                entity.Property(e => e.Gid).HasColumnName("gid");

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
                entity.HasNoKey();

                entity.ToTable("storm_track_pts");

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

                entity.Property(e => e.Gid).HasColumnName("gid");

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

            modelBuilder.Entity<TempAdvisory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Temp_advisories");

                entity.HasIndex(e => e.Geometry, "idx_Temp_advisories_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.EndDate).HasColumnName("End_Date");

                entity.Property(e => e.EndDt2).HasColumnName("End_Dt2");

                entity.Property(e => e.FArea).HasColumnName("F_AREA");

                entity.Property(e => e.Geometry)
                    .HasColumnType("geometry(Geometry,4326)")
                    .HasColumnName("geometry");

                entity.Property(e => e.StartDate).HasColumnName("Start_Date");

                entity.Property(e => e.StartDt2).HasColumnName("Start_Dt2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
