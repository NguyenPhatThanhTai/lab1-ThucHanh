namespace S2tcnhut.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(30)]
        public string Hinh { get; set; }

        [StringLength(4)]
        public string MaNganh { get; set; }

        public virtual NganhHoc NganhHoc { get; set; }
    }
}
