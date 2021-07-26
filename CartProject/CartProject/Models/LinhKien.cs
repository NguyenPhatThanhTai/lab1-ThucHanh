namespace CartProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinhKien")]
    public partial class LinhKien
    {
        [Key]
        [StringLength(6)]
        public string MaLK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLK { get; set; }

        public string MoTa { get; set; }

        [StringLength(20)]
        public string HangSX { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaLK { get; set; }

        public int? SoLuongTon { get; set; }
    }
}
