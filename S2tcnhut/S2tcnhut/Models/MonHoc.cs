namespace S2tcnhut.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonHoc")]
    public partial class MonHoc
    {
        [Key]
        [StringLength(6)]
        public string MaMH { get; set; }

        [StringLength(50)]
        public string TenMH { get; set; }

        public int? SoTinChi { get; set; }

        [StringLength(2)]
        public string HocKi { get; set; }

        [StringLength(4)]
        public string MaNganh { get; set; }

        public virtual NganhHoc NganhHoc { get; set; }
    }
}
