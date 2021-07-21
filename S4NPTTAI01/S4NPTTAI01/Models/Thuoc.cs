namespace S4NPTTAI01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [Key]
        [StringLength(6)]
        public string MaT { get; set; }

        [Required]
        [StringLength(50)]
        public string TenT { get; set; }

        [StringLength(20)]
        public string DangThuoc { get; set; }

        public string CachDung { get; set; }

        [StringLength(4)]
        public string MaBenh { get; set; }

        public virtual LoaiBenh LoaiBenh { get; set; }
    }
}
