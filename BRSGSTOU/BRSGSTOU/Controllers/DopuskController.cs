using BRSGSTOU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRSGSTOU.Controllers
{
    public class DopuskController : Controller
    {
        //
        // GET: /Dopusk/
        Models.dbBRSEntities contextDB = new dbBRSEntities();

        [Authorize]
        public ActionResult SpisokGrupp()
        {
            try
            {
                int Facultet_ID =
                   (from r in contextDB.tableAdmins
                    where r.Login == User.Identity.Name
                    select r.Facultet_ID).First();

                ViewBag.Facultet_ID = Facultet_ID;

                var GruppList =
                    from gl in contextDB.tableGrupp
                    where gl.IDFacultet == Facultet_ID
                    select gl;

                ViewBag.GruppList = GruppList;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        
        [Authorize]
        public ActionResult SpisokStudentov()
        {
            try
            {
                int GruppID = int.Parse(Request.QueryString.Get(1));

                int Facultet_ID =
                   (from r in contextDB.tableAdmins
                    where r.Login == User.Identity.Name
                    select r.Facultet_ID).First();

                ViewBag.GruppID = GruppID;
                ViewBag.Facultet_ID = Facultet_ID;

                string GruppName =
                    (from gn in contextDB.tableGrupp
                     where gn.ID == GruppID
                     select gn.Name).First();

                ViewBag.GruppName = GruppName;

                var Students =
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == GruppID
                    select s;

                ViewBag.Students = Students;

                ViewBag.Message = "";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult SpisokStudentov(string Facultet_ID, string Grupp_ID)
        {
            try
            {
                int GruppID = int.Parse(Grupp_ID);
                ViewBag.GruppID = GruppID;
                ViewBag.Facultet_ID = Facultet_ID;

                string GruppName =
                    (from gn in contextDB.tableGrupp
                     where gn.ID == GruppID
                     select gn.Name).First();

                ViewBag.GruppName = GruppName;
                int k=1;
                foreach (var s in Request.Form.AllKeys)
                {
                    if (k <= Request.Form.AllKeys.Length-2)
                    {
                        int idStud = 0;
                        byte otmetka = 0;
                        if (int.TryParse(s, out idStud))
                        {
                            idStud = int.Parse(s);
                            if (Request.Form.Get(s) == "false")
                            {
                                otmetka = 0;
                            }
                            else
                            {
                                otmetka = 1;
                            }
                            var stud =
                                (from st in contextDB.tableStudents
                                 where st.ID == idStud
                                 select st).First();
                            stud.DopuskKSessii = otmetka;
                        }
                    }
                    else
                    {
                        break;
                    }
                    k++;
                }
                contextDB.SaveChanges();

                var Students =
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == GruppID
                    select s;

                ViewBag.Students = Students;
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        private ActionResult isAdminMetod()
        {
            try
            {
                int rol = 0;
                try
                {
                    rol =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Role_ID).First();
                }
                catch
                {

                }
                if (rol == 1)
                {
                    return View();
                }
                else
                {
                    return View("NotFound");
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
