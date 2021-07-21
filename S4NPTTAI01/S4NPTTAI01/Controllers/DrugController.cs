using S4NPTTAI01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S4NPTTAI01.Controllers
{
    public class DrugController : Controller
    {
        // GET: Drug
        public ActionResult TrangChu()
        {
            return View(new DAOController().dsBenh());
        }

        public ActionResult chiTiet(string Id)
        {
            if(new DAOController().layBenh(Id) != null)
            {
                return View(new DAOController().layBenh(Id));
            }
            else
            {
                return View("TrangChu", new DAOController().dsBenh());
            }
        }

        public ActionResult ThemThuoc()
        {
            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemThuoc(BenhViewModels benh)
        {
            string day = DateTime.Now.ToString("dd");
            string Min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");

            var MaB = "Benh" + "" + day + "" + Min + "" + sec;

            //lấy ảnh đã chọn từ front-end
            string fileName = System.IO.Path.GetFileNameWithoutExtension(benh.Icon.FileName);
            //string extension = System.IO.Path.GetExtension(create.ImageFile.FileName);
            fileName = fileName + ".jpg";
            string pathSave = "~/Images/charICon/" + fileName;
            fileName = System.IO.Path.Combine(Server.MapPath("~/Content/avatar/"), MaB + ".jpg");
            benh.Icon.SaveAs(fileName);

            Benh be = new Benh
            {
                MaB = MaB,
                TenB = benh.TenB,
                Hinh = MaB + ".jpg",
                MaBenh = benh.MaBenh,
                NgayBenh = benh.NgayBenh,
                TrieuChung = benh.TrieuChung
            };

            //System.Diagnostics.Debug.WriteLine(sv);

            if (new DAOController().themBenh(be))
            {
                return View("TrangChu", new DAOController().dsBenh());
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                return View("ThemThuoc");
            }
        }

        public ActionResult suaBenh(string Id)
        {
            ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
            if(new DAOController().layBenh(Id) != null)
            {
                return View(new DAOController().layBenh(Id));
            }
            return View("TrangChu", new DAOController().dsBenh());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult suaBenh(BenhViewModels benh)
        {
            //Xóa ảnh cũ đi nếu có
            try
            {
                string path = System.Web.Hosting.HostingEnvironment.MapPath("Content\\avatar" + benh.MaB + ".jpg");
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
            string fileName = System.IO.Path.GetFileNameWithoutExtension(benh.Icon.FileName);
            //string extension = System.IO.Path.GetExtension(create.ImageFile.FileName);
            fileName = fileName + ".jpg";
            string pathSave = "~/Content/avatar/" + fileName;
            fileName = System.IO.Path.Combine(Server.MapPath("~/Content/avatar/"), benh.MaB + ".jpg");

            //save ảnh lại
            benh.Icon.SaveAs(fileName);

            Benh be = new Benh
            {
                MaB = benh.MaB,
                TenB = benh.TenB,
                Hinh = benh.MaB + ".jpg",
                MaBenh = benh.MaBenh,
                NgayBenh = benh.NgayBenh,
                TrieuChung = benh.TrieuChung
            };

            if (new DAOController().suaBenh(be))
            {
                return View("TrangChu", new DAOController().dsBenh());
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra rồi");
                ViewBag.dsLoaiBenh = new DAOController().dsLoaiBenh();
                return View(new DAOController().layBenh(benh.MaB));
            }
        }

        public ActionResult xoaBenh(string Id)
        {
            if(new DAOController().xoaBenh(Id))
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

                return View("TrangChu", new DAOController().dsBenh());
            }
            else
            {
                return View("TrangChu", new DAOController().dsBenh());
            }
        }
    }
}