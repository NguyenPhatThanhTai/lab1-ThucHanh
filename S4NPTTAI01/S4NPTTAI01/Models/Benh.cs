namespace S4NPTTAI01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Benh")]
    public partial class Benh
    {
        [Key]
        [StringLength(10)]
        public string MaB { get; set; }

        [Required]
        [StringLength(50)]
        public string TenB { get; set; }

        public string TrieuChung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBenh { get; set; }

        [StringLength(30)]
        public string Hinh { get; set; }

        [StringLength(4)]
        public string MaBenh { get; set; }

        public virtual LoaiBenh LoaiBenh { get; set; }
    }
}
