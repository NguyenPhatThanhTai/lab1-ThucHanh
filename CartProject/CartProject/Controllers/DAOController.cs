using CartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartProject.Controllers
{
    public class DAOController
    {
        DAO dao = new DAO();
        public DAOController()
        {
            dao = new DAO();
        }

        public List<LinhKien> listLK()
        {
            return dao.LinhKiens.ToList();
        }

        public LinhKien getLK(string Id)
        {
            try
            {
                return dao.LinhKiens.FirstOrDefault(p=>p.MaLK.Equals(Id));
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public bool addGH(GioHang gh)
        {
            try
            {
                dao.GioHangs.Add(gh);
                dao.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }
    }
}