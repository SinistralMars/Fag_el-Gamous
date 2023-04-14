using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// This code defines the BurialContext class, which inherits from DbContext
// and serves as the main point of interaction with the database for the Fag_el_Gamous project.
// It includes DbSet properties for the NewTable model and methods for configuring and building the Entity Framework
// model, as well as a partial method for extending the model building process.


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fag_el_Gamous.Models
{
    public partial class BurialContext : DbContext
    {
        public BurialContext()
        {
        }

        public BurialContext(DbContextOptions<BurialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewTable> NewTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=burial.cxooaxz3nwld.us-east-1.rds.amazonaws.com;Database=burial;User Id=postgres;Password=Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewTable>(entity =>
            {
                entity.ToTable("new_table");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adultsubadult)
                    .HasColumnName("adultsubadult")
                    .HasMaxLength(200);

                entity.Property(e => e.Ageatdeath)
                    .HasColumnName("ageatdeath")
                    .HasMaxLength(200);

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(200);

                entity.Property(e => e.Burialid).HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasColumnName("burialmaterials")
                    .HasMaxLength(5);

                entity.Property(e => e.Burialnumber)
                    .HasColumnName("burialnumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Clusternumber)
                    .HasColumnName("clusternumber")
                    .HasMaxLength(200);

                entity.Property(e => e.ColorValue).HasMaxLength(500);

                entity.Property(e => e.Dataexpertinitials)
                    .HasColumnName("dataexpertinitials")
                    .HasMaxLength(200);

                entity.Property(e => e.Dateofexcavation).HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasColumnName("depth")
                    .HasMaxLength(200);

                entity.Property(e => e.Eastwest)
                    .HasColumnName("eastwest")
                    .HasMaxLength(200);

                entity.Property(e => e.Estimatestature).HasColumnName("estimatestature");

                entity.Property(e => e.Excavationrecorder)
                    .HasColumnName("excavationrecorder")
                    .HasMaxLength(100);

                entity.Property(e => e.Facebundles)
                    .HasColumnName("facebundles")
                    .HasMaxLength(200);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasColumnName("fieldbookexcavationyear")
                    .HasMaxLength(200);

                entity.Property(e => e.Fieldbookpage)
                    .HasColumnName("fieldbookpage")
                    .HasMaxLength(200);

                entity.Property(e => e.Goods)
                    .HasColumnName("goods")
                    .HasMaxLength(200);

                entity.Property(e => e.Hair)
                    .HasColumnName("hair")
                    .HasMaxLength(5);

                entity.Property(e => e.Haircolor)
                    .HasColumnName("haircolor")
                    .HasMaxLength(200);

                entity.Property(e => e.Headdirection)
                    .HasColumnName("headdirection")
                    .HasMaxLength(200);

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasMaxLength(200);

                entity.Property(e => e.Northsouth)
                    .HasColumnName("northsouth")
                    .HasMaxLength(200);

                entity.Property(e => e.Photos)
                    .HasColumnName("photos")
                    .HasMaxLength(5);

                entity.Property(e => e.Preservation)
                    .HasColumnName("preservation")
                    .HasMaxLength(200);

                entity.Property(e => e.Samplescollected)
                    .HasColumnName("samplescollected")
                    .HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(200);

                entity.Property(e => e.Shaftnumber)
                    .HasColumnName("shaftnumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Southtofeet)
                    .HasColumnName("southtofeet")
                    .HasMaxLength(200);

                entity.Property(e => e.Southtohead)
                    .HasColumnName("southtohead")
                    .HasMaxLength(200);

                entity.Property(e => e.Squareeastwest)
                    .HasColumnName("squareeastwest")
                    .HasMaxLength(200);

                entity.Property(e => e.Squarenorthsouth)
                    .HasColumnName("squarenorthsouth")
                    .HasMaxLength(200);

                entity.Property(e => e.StructureValue).HasMaxLength(500);

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(2000);

                entity.Property(e => e.TextileFunctionValue).HasMaxLength(200);

                entity.Property(e => e.Westtofeet)
                    .HasColumnName("westtofeet")
                    .HasMaxLength(200);

                entity.Property(e => e.Westtohead)
                    .HasColumnName("westtohead")
                    .HasMaxLength(200);

                entity.Property(e => e.Wrapping)
                    .HasColumnName("wrapping")
                    .HasMaxLength(200);
            });

            modelBuilder.HasSequence("excelimporter$template_nr_mxseq");

            modelBuilder.HasSequence("system$filedocument_fileid_mxseq");

            modelBuilder.HasSequence("system$queuedtask_sequence_mxseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
