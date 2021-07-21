using S4NPTTAI01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S4NPTTAI01.Controllers
{
    public class DAOController
    {
        private DAO dao = null;
        public DAOController()
        {
            dao = new DAO();
        }

        public List<Benh> dsBenh()
        {
            return dao.Benh.ToList();
        }

        public List<LoaiBenh> dsLoaiBenh()
        {
            return dao.LoaiBenh.ToList();
        }

        public bool themBenh(Benh benh)
        {
            try
            {
                dao.Benh.Add(benh);
                dao.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public Benh layBenh(string Id)
        {
            var benh = dao.Benh.FirstOrDefault(p => p.MaB.Equals(Id));
            if(benh != null)
            {
                return benh;
            }
            else
            {
                return null;
            }
        }

        public bool suaBenh(Benh benh)
        {
            try
            {
                var be = dao.Benh.FirstOrDefault(p => p.MaB.Equals(benh.MaB));
                if (be != null)
                {
                    be.MaBenh = benh.MaBenh;
                    be.Hinh = benh.Hinh;
                    be.NgayBenh = benh.NgayBenh;
                    be.TrieuChung = benh.TrieuChung;
                    be.TenB = benh.TenB;

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

        public bool xoaBenh(string Id)
        {
            var benh = dao.Benh.FirstOrDefault(p => p.MaB.Equals(Id));
            if(benh != null)
            {
                dao.Benh.Remove(benh);
                dao.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////
        
        public List<Thuoc> dsThuoc(string Id)
        {
            if(Id == null)
            {
                return dao.Thuoc.ToList();
            }
            else
            {
                return dao.Thuoc.Where(p => p.MaBenh.Equals(Id)).ToList();
            }
        }

        public bool themThuoc(Thuoc thuoc)
        {
            try
            {
                dao.Thuoc.Add(thuoc);
                dao.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public Thuoc LayThuoc(string Id)
        {
            try
            {
                var thuoc = dao.Thuoc.FirstOrDefault(p=>p.MaT.Equals(Id));
                if(thuoc != null)
                {
                    return thuoc;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public bool SuaThuoc(Thuoc thuoc)
        {
            try
            {
                var th = dao.Thuoc.FirstOrDefault(p => p.MaT.Equals(thuoc.MaT));
                if (th != null)
                {
                    th.TenT = thuoc.TenT;
                    th.DangThuoc = thuoc.DangThuoc;
                    th.CachDung = thuoc.CachDung;
                    th.MaBenh = thuoc.MaBenh;

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

        public bool XoaThuoc(string Id)
        {
            var thuoc = dao.Thuoc.FirstOrDefault(p => p.MaT.Equals(Id));
            if (thuoc != null)
            {
                dao.Thuoc.Remove(thuoc);
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