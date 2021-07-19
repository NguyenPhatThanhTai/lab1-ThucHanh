using S2tcnhut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2tcnhut.Controllers
{
    public class DAOController
    {
        private DAO dao = null;
        public DAOController()
        {
            dao = new DAO();
        }

        public List<SinhVien> listSV(string Id)
        {
            if(Id == null)
            {
                return dao.SinhVien.ToList();
            }
            else
            {
                return dao.SinhVien.Where(p => p.MaNganh.Equals(Id)).ToList();
            }
        }

        public List<NganhHoc> listNH()
        {
            return dao.NganhHoc.ToList();
        }

        public bool addStudent(SinhVien sv)
        {
            try
            {
                dao.SinhVien.Add(sv);
                dao.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public SinhVien getSV(string Id)
        {
            var SV = dao.SinhVien.FirstOrDefault(p => p.MaSV.Equals(Id));
            if(SV != null)
            {
                return SV;
            }
            else
            {
                return null;
            }
        }

        public bool updateSV(SinhVien sv)
        {
            try
            {
                var SV = dao.SinhVien.FirstOrDefault(p => p.MaSV.Equals(sv.MaSV));
                if (SV != null)
                {
                    SV.HoTen = sv.HoTen;
                    SV.GioiTinh = sv.GioiTinh;
                    SV.Hinh = sv.Hinh;
                    SV.NgaySinh = sv.NgaySinh;
                    SV.MaNganh = sv.MaNganh;

                    dao.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public bool deleteSV(string Id)
        {
            try
            {
                var SV = dao.SinhVien.FirstOrDefault(p => p.MaSV.Equals(Id));
                if (SV != null)
                {
                    dao.SinhVien.Remove(SV);
                    dao.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public List<MonHoc> listMH()
        {
            return dao.MonHoc.ToList();
        }

        public bool addMH(MonHoc mh)
        {
            try
            {
                dao.MonHoc.Add(mh);
                dao.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public MonHoc getMH(string Id)
        {
            if (dao.MonHoc.FirstOrDefault(p => p.MaMH.Equals(Id)) != null)
            {
                return dao.MonHoc.FirstOrDefault(p => p.MaMH.Equals(Id));
            }
            else
            {
                return null;
            }
        }

        public bool updateMH(MonHoc mh)
        {
            var MH = dao.MonHoc.FirstOrDefault(p => p.MaMH.Equals(mh.MaMH));
            if(MH != null)
            {
                MH.TenMH = mh.TenMH;
                MH.SoTinChi = mh.SoTinChi;
                MH.MaNganh = mh.MaNganh;
                MH.HocKi = mh.HocKi;

                dao.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteMH(string Id)
        {
            var MH = dao.MonHoc.FirstOrDefault(p => p.MaMH.Equals(Id));
            if (MH != null)
            {
                dao.MonHoc.Remove(MH);

                dao.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}