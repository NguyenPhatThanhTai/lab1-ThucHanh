using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace S4NPTTAI01.Models
{
    public partial class DAO : DbContext
    {
        public DAO()
            : base("name=DAO")
        {
        }

        public virtual DbSet<Benh> Benh { get; set; }
        public virtual DbSet<LoaiBenh> LoaiBenh { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benh>()
                .Property(e => e.MaB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Benh>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Benh>()
                .Property(e => e.MaBenh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiBenh>()
                .Property(e => e.MaBenh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaBenh)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
