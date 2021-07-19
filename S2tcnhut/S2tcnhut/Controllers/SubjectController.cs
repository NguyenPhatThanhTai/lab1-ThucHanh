using S2tcnhut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2tcnhut.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult DanhSach()
        {
            return View(new DAOController().listMH());
        }

        public ActionResult ThemMonHoc()
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View();
        }

        [HttpPost]
        public ActionResult ThemMonHoc(MonHoc mh)
        {
            string day = DateTime.Now.ToString("dd");
            string Min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");

            var MaMH = "MH" + "" + Min + "" + sec;

            mh.MaMH = MaMH;

            if(new DAOController().addMH(mh))
            {
                return RedirectToAction("DanhSach", new DAOController().listMH());
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                ViewBag.ListNganh = new DAOController().listNH();
                return View("ThemMonHoc");
            }
        }

        public ActionResult suaMH(string Id)
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View(new DAOController().getMH(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult suaMH(MonHoc mh)
        {
            if (new DAOController().updateMH(mh))
            {
                return View("DanhSach", new DAOController().listMH());
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                return View(new DAOController().getMH(mh.MaMH));
            }
        }

        public ActionResult xoaMH(string Id)
        {
            if(new DAOController().deleteMH(Id))
            {
                return RedirectToAction("DanhSach", new DAOController().listMH());
            }
            else
            {
                return RedirectToAction("DanhSach", new DAOController().listMH());
            }
        }
    }
}