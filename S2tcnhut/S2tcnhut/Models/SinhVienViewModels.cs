using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2tcnhut.Models
{
    public class SinhVienViewModels
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Hinh { get; set; }
        public string MaNganh { get; set; }

        public HttpPostedFileBase Icon { get; set; }
    }
}