using S2tcnhut.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2tcnhut.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult TrangChu()
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View(new DAOController().listSV(null));
        }

        public ActionResult Fillter(string Id)
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View("TrangChu", new DAOController().listSV(Id));
        }

        public ActionResult ThemSinhVien()
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSinhVien(SinhVienViewModels svmd)
        {
            string day = DateTime.Now.ToString("dd");
            string Min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");

            var MaSV = "1811" + "" + day + "" + Min + "" + sec;

            //lấy ảnh đã chọn từ front-end
            string fileName = System.IO.Path.GetFileNameWithoutExtension(svmd.Icon.FileName);
            //string extension = System.IO.Path.GetExtension(create.ImageFile.FileName);
            fileName = fileName + ".jpg";
            string pathSave = "~/Images/charICon/" + fileName;
            fileName = System.IO.Path.Combine(Server.MapPath("~/Content/avatar/"), MaSV + ".jpg");
            svmd.Icon.SaveAs(fileName);

            SinhVien sv = new SinhVien {
                MaSV = MaSV,
                HoTen = svmd.HoTen,
                GioiTinh = svmd.GioiTinh,
                Hinh = MaSV + ".jpg",
                NgaySinh = svmd.NgaySinh,
                MaNganh = svmd.MaNganh
            };

            //System.Diagnostics.Debug.WriteLine(sv);

            if (new DAOController().addStudent(sv))
            {
                ViewBag.ListNganh = new DAOController().listNH();
                return RedirectToAction("TrangChu", new DAOController().listSV(null));
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                return View("ThemSinhVien");
            }
        }

        public ActionResult suaSinhVien(string Id)
        {
            ViewBag.ListNganh = new DAOController().listNH();
            return View(new DAOController().getSV(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult suaSinhVien(SinhVienViewModels svmd)
        {
            //Xóa ảnh cũ đi nếu có
            try
            {
                string path = System.Web.Hosting.HostingEnvironment.MapPath("Content\\avatar" + svmd.MaSV + ".jpg");
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }
            }
            catch (Exception ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            //lấy ảnh đã chọn từ front-end
            string fileName = System.IO.Path.GetFileNameWithoutExtension(svmd.Icon.FileName);
            //string extension = System.IO.Path.GetExtension(create.ImageFile.FileName);
            fileName = fileName + ".jpg";
            string pathSave = "~/Content/avatar/" + fileName;
            fileName = System.IO.Path.Combine(Server.MapPath("~/Content/avatar/"), svmd.MaSV + ".jpg");

            //save ảnh lại
            svmd.Icon.SaveAs(fileName);

            SinhVien sv = new SinhVien
            {
                MaSV = svmd.MaSV,
                HoTen = svmd.HoTen,
                GioiTinh = svmd.GioiTinh,
                NgaySinh = svmd.NgaySinh,
                Hinh = svmd.MaSV + ".jpg",
                MaNganh = svmd.MaNganh
            };

            if(new DAOController().updateSV(sv))
            {
                ViewBag.ListNganh = new DAOController().listNH();
                return RedirectToAction("TrangChu", new DAOController().listSV(null));
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                ViewBag.ListNganh = new DAOController().listNH();
                return View("suaSinhVien",new DAOController().getSV(svmd.MaSV));
            }
        }

        public ActionResult xoaSinhVien(string Id)
        {
            if(new DAOController().deleteSV(Id))
            {
                //Xóa ảnh cũ đi nếu có
                try
                {
                    string path = System.Web.Hosting.HostingEnvironment.MapPath("Content\\avatar" + Id + ".jpg");
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                }
                catch (Exception ioExp)
                {
                    Console.WriteLine(ioExp.Message);
                }

                ViewBag.ListNganh = new DAOController().listNH();
                return RedirectToAction("TrangChu", new DAOController().listSV(null));
            }
            else
            {
                ViewBag.ListNganh = new DAOController().listNH();
                return RedirectToAction("TrangChu", new DAOController().listSV(null));
            }
        }
    }
}