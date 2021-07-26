using CartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartProject.Controllers
{
    public class CartController : Controller
    {
        public ActionResult TrangChu()
        {
            List<LinhKien> listLK = new DAOController().listLK();
            return View(listLK);
        }

        public ActionResult GioHang()
        {
            var lists = Session["GioHang"] as List<GioHangSession>;
            decimal? money = 0;
            if (lists != null)
            {
                foreach (var items in lists)
                {
                    money += items.ThanhTien;
                }
            }
            ViewBag.TongTien = money;
            return View(lists);
        }

        public ActionResult ThemGioHang(string Id)
        {
            LinhKien lk = new DAOController().getLK(Id);
            if (Session["GioHang"] == null)
            {
                GioHangSession gh = new GioHangSession
                {
                    MaLK = lk.MaLK,
                    TenLK = lk.TenLK,
                    DonGiaLK = lk.GiaLK,
                    HangSX = lk.HangSX,
                    SoLuong = 1,
                    ThanhTien = lk.GiaLK
                };

                List<GioHangSession> giohang = new List<GioHangSession>();
                giohang.Add(gh);
                Session["GioHang"] = giohang;
            }
            else
            {
                var lists = Session["GioHang"] as List<GioHangSession>;
                var check = lists.FirstOrDefault(p => p.MaLK.Equals(Id));
                if(check != null)
                {
                    check.SoLuong += 1;
                    check.ThanhTien += check.DonGiaLK;
                    Session["GioHang"] = lists;
                }
                else
                {
                    GioHangSession gh = new GioHangSession
                    {
                        MaLK = lk.MaLK,
                        TenLK = lk.TenLK,
                        DonGiaLK = lk.GiaLK,
                        HangSX = lk.HangSX,
                        SoLuong = 1,
                        ThanhTien = lk.GiaLK
                    };

                    lists.Add(gh);
                    Session["GioHang"] = lists;
                }
            }

            List<LinhKien> listLK = new DAOController().listLK();
            return RedirectToAction("TrangChu", listLK);
        }

        public ActionResult TangGiamGH(string Id, string flag)
        {
            var lists = Session["GioHang"] as List<GioHangSession>;
            if (Id != null && flag == "Tang")
            {
                var check = lists.FirstOrDefault(p => p.MaLK.Equals(Id));
                if (check != null)
                {
                    check.SoLuong += 1;
                    check.ThanhTien += check.DonGiaLK;
                    Session["GioHang"] = lists;
                }
            }
            else if (flag == "Giam")
            {
                var check = lists.FirstOrDefault(p => p.MaLK.Equals(Id));
                if (check != null)
                {
                    if(check.SoLuong == 1)
                    {
                        check.SoLuong = 1;
                    }
                    else
                    {
                        check.SoLuong -= 1;
                        check.ThanhTien -= check.DonGiaLK;
                    }
                    Session["GioHang"] = lists;
                }
            }
            else
            {
                var check = lists.FirstOrDefault(p => p.MaLK.Equals(Id));
                if (check != null)
                {
                    lists.Remove(check);
                    Session["GioHang"] = lists;
                }
            }

            decimal? money = 0;
            if (lists != null)
            {
                foreach (var items in lists)
                {
                    money += items.ThanhTien;
                }
            }
            ViewBag.TongTien = money;
            return RedirectToAction("Giohang", lists);
        }

        public ActionResult LuuGioHang()
        {
            var lists = Session["GioHang"] as List<GioHangSession>;
            decimal? money = 0;
            string listsLK = "";
            if (lists != null)
            {
                foreach (var items in lists)
                {
                    money += items.ThanhTien;
                    listsLK += items.TenLK + ", ";
                }
            }

            GioHang gh = new GioHang 
            {
                ThongTinLK = listsLK,
                TongTien = money
            };

            new DAOController().addGH(gh);

            List<LinhKien> listLK = new DAOController().listLK();
            return RedirectToAction("TrangChu", listLK);
        }
    }
}