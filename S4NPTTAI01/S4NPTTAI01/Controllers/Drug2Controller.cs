using S4NPTTAI01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S4NPTTAI01.Controllers
{
    public class Drug2Controller : Controller
    {
        // GET: Drug2
        public ActionResult DanhSachThuoc()
        {
            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            return View(new DAOController().dsThuoc(null));
        }

        public ActionResult Fillter(string Id)
        {
            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            return View("DanhSachThuoc", new DAOController().dsThuoc(Id));
        }

        public ActionResult ThemThuoc()
        {
            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemThuoc(Thuoc thuoc)
        {
            string day = DateTime.Now.ToString("dd");
            string Min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");

            var MaT = "Th" + Min + "" + sec;

            thuoc.MaT = MaT;

            if (new DAOController().themThuoc(thuoc))
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
            else
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("ThemThuoc");
            }
        }

        public ActionResult SuaThuoc(string Id)
        {
            if(new DAOController().LayThuoc(Id) != null)
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View(new DAOController().LayThuoc(Id));
            }
            else
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SuaThuoc(Thuoc thuoc)
        {
            if (new DAOController().SuaThuoc(thuoc))
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
            else
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View(new DAOController().LayThuoc(thuoc.MaT));
            }
        }

        public ActionResult XoaThuoc(string Id)
        {
            if(new DAOController().XoaThuoc(Id))
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
            else
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
        }

        public ActionResult ChiTiet(string Id)
        {
            if (new DAOController().LayThuoc(Id) != null)
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View(new DAOController().LayThuoc(Id));
            }
            else
            {
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View("DanhSachThuoc", new DAOController().dsThuoc(null));
            }
        }

        public ActionResult GioHang()
        {
            List<Giohang> list = (List<Giohang>)Session["GioHang"];
            return View(list);
        }

        public ActionResult themGioHang(string Id)
        {
            string day = DateTime.Now.ToString("dd");
            string Min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");

            Thuoc thuoc = new DAOController().LayThuoc(Id);

            if (Session["GioHang"] == null)
            {
                Giohang gh = new Giohang
                {
                    MaGioHang = "GH" + Min + "" + sec,
                    MaHang = thuoc.MaT,
                    TenHang = thuoc.TenT,
                    SoLuong = 1
                };
                List<Giohang> list = new List<Giohang>();
                list.Add(gh);
                Session["GioHang"] = list;
            }
            else
            {
                var lists = Session["GioHang"] as List<Giohang>;
                var check = lists.FirstOrDefault(p => p.MaHang.Equals(Id));
                if (check != null)
                {
                    check.SoLuong += 1;
                    Session["GioHang"] = lists;
                }
                else
                {
                    Giohang gh = new Giohang
                    {
                        MaGioHang = "GH" + Min + "" + sec,
                        MaHang = thuoc.MaT,
                        TenHang = thuoc.TenT,
                        SoLuong = 1
                    };
                    var li = (List<Giohang>)Session["GioHang"];
                    li.Add(gh);
                    Session["GioHang"] = li;
                }
            }

            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            return RedirectToAction("DanhSachThuoc", "Drug2", new DAOController().dsThuoc(null));
        }

        public ActionResult TangGiamGH(string Id, string flag)
        {
            if (Id != null && flag == "Tang")
            {
                var lists = Session["GioHang"] as List<Giohang>;
                var check = lists.FirstOrDefault(p => p.MaHang.Equals(Id));
                if (check != null)
                {
                    check.SoLuong += 1;
                    Session["GioHang"] = lists;
                }
            }
            else if(flag == "Giam")
            {
                var lists = Session["GioHang"] as List<Giohang>;
                var check = lists.FirstOrDefault(p => p.MaHang.Equals(Id));
                if (check != null)
                {
                    check.SoLuong -= 1;
                    Session["GioHang"] = lists;
                }
            }
            else
            {
                var lists = Session["GioHang"] as List<Giohang>;
                var check = lists.FirstOrDefault(p => p.MaHang.Equals(Id));
                if (check != null)
                {
                    lists.Remove(check);
                    Session["GioHang"] = lists;
                }
            }

            List<Giohang> list = (List<Giohang>)Session["GioHang"];
            return View("GioHang", list);
        }
    }
}