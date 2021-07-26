using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CartProject.Models
{
    public partial class DAO : DbContext
    {
        public DAO()
            : base("name=DAO")
        {
        }

        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<LinhKien> LinhKiens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GioHang>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.MaLK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.HangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.GiaLK)
                .HasPrecision(19, 4);
        }
    }
}
