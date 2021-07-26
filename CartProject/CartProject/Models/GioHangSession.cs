using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartProject.Models
{
    public class GioHangSession
    {
        public string MaLK { get; set; }
        public string TenLK { get; set; }
        public string HangSX { get; set; }
        public decimal? DonGiaLK { get; set; }
        public int SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
    }
}