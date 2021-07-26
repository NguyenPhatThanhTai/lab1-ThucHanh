namespace CartProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        public int ID { get; set; }

        public string ThongTinLK { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }
    }
}
