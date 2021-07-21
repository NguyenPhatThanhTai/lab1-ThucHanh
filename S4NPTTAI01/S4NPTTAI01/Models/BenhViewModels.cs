using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S4NPTTAI01.Models
{
    public class BenhViewModels
    {
        public string MaB { get; set; }
        public string TenB { get; set; }

        public string TrieuChung { get; set; }
        public DateTime? NgayBenh { get; set; }
        public string MaBenh { get; set; }
        public HttpPostedFileBase Icon { get; set; }
    }
}