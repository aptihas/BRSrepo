using BRSGSTOU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRSGSTOU.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        Models.dbBRSEntities contextDB = new dbBRSEntities();

        [Authorize]
        public ActionResult MainPanel()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                ViewBag.Facultet_ID = Facultet_ID;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult Vedomosti()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                ViewBag.Facultet_ID = Facultet_ID;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult AdminPanel()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                ViewBag.Facultet_ID = Facultet_ID;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult GruppList()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var GruppList =
                    from g in contextDB.tableGrupp
                    where g.IDFacultet == Facultet_ID
                    orderby g.Name
                    select new GruppaModel { Gruppa = g.Name, ID = g.ID, Facultet_ID = g.IDFacultet };

                ViewBag.Facultet_ID = Facultet_ID;
                ViewBag.GruppList = GruppList;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult SubjectList()
        {
            try
            {
                int Gruppa_ID = int.Parse(Request.QueryString.Get(1));
                int Vedomost = int.Parse(Request.QueryString.Get(2));
                string VidVedomost = Request.QueryString.Get(3);

                ViewBag.VidVedomost = VidVedomost;

                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                string Gruppa =
                    (from s in contextDB.tableGrupp
                     where s.IDFacultet == Facultet_ID && s.ID == Gruppa_ID
                     select s.Name).First().ToString();

                ViewBag.Facultet_ID = Facultet_ID;
                ViewBag.Gruppa_ID = Gruppa_ID;
                ViewBag.Vedomost = Vedomost;
                ViewBag.Gruppa = Gruppa;
                
                //2 раза
                var SubjectList =
                    from s in contextDB.tablePrinadlegnistDisciplin
                    where s.ID_Facultet == Facultet_ID && s.ID_Gruppi == Gruppa_ID
                    from d in contextDB.tableDisciplin
                    where s.ID_Disciplini == d.ID
                    orderby d.Name
                    select new Subject { Disciplina_ID = d.ID, Disciplina = d.Name, Otchetnost = s.Otchetnost, KR_KP = s.KR_KP };

                ViewBag.SubjectList = SubjectList;
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult SvodniyJurnal(string Facultet, string Gruppa)
        {
            try
            {
                var contextDB = new Models.dbBRSEntities();

                int Facultet_ID = int.Parse(Facultet);
                int Grupp_ID = int.Parse(Gruppa);

                var Disciplins =
                    from disciplinaID in contextDB.tablePrinadlegnistDisciplin
                    where disciplinaID.ID_Facultet == Facultet_ID && disciplinaID.ID_Gruppi == Grupp_ID && disciplinaID.ID_Disciplini == disciplinaID.tableDisciplin.ID
                    orderby disciplinaID.tableDisciplin.Name
                    select disciplinaID.tableDisciplin;

                var students =
                    from stud in contextDB.tableStudents
                    where stud.ID_Gruppi == Grupp_ID
                    orderby stud.Name
                    select stud;

                var itogi =
                    from i in contextDB.tableBalli
                    from s in students
                    where s.ID == i.ID_Studenta
                    select new SvodnayaVedomost { Student_ID = s.ID, Student = s.Name, Disciplina_ID = i.ID_Disciplini, Itog = i.Itog };

                ViewBag.Faculteti = contextDB.tableFacultet;
                ViewBag.Disciplini = Disciplins;
                ViewBag.Students = students;
                ViewBag.Itogi = itogi;

                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult ProsmotrAttVedomosti()
        {
            try
            {
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));
                int Grupp_ID = int.Parse(Request.QueryString.Get(1));
                int Disciplina_ID = int.Parse(Request.QueryString.Get(2));

                var BalliStudnets =
                    from balli in contextDB.tableBalli
                    where balli.ID_Gruppi == Grupp_ID && balli.ID_Disciplini == Disciplina_ID
                    join s in contextDB.tableStudents on balli.ID_Studenta equals s.ID
                    select new Vedomost { StudentName = s.Name, Pos1 = balli.Pos1, Tek1 = balli.Tek1, Rub1 = balli.Rub1, Pos2 = balli.Pos2, Tek2 = balli.Tek2, Rub2 = balli.Rub2, Samost = balli.Samost, Dosdacha = balli.Dosdacha, Premial = balli.Premial, Itog = balli.Itog };

                ViewBag.Vedomost = BalliStudnets;

                string[] Dannie = new string[3];
                Dannie[0] = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                Dannie[1] = (from t in contextDB.tableGrupp where t.ID == Grupp_ID select t.Name).First().ToString();
                Dannie[2] = (from t in contextDB.tableDisciplin where t.ID == Disciplina_ID select t.Name).First().ToString();
                ViewBag.Dannie = Dannie;
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ProsmotrEkzVedomosti()
        {
            try
            {
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));
                int Grupp_ID = int.Parse(Request.QueryString.Get(1));
                int Disciplina_ID = int.Parse(Request.QueryString.Get(2));
                int Vedomost = int.Parse(Request.QueryString.Get(3));

                var BalliStudnets =
                    from balli in contextDB.tableBalli
                    where balli.ID_Gruppi == Grupp_ID && balli.ID_Disciplini == Disciplina_ID
                    join s in contextDB.tableStudents on balli.ID_Studenta equals s.ID
                    select new Vedomost { StudentName = s.Name,DopuskKSessii=s.DopuskKSessii, NomerZachetki = s.NomerZachetki, Pos1 = balli.Pos1, Tek1 = balli.Tek1, Rub1 = balli.Rub1, Pos2 = balli.Pos2, Tek2 = balli.Tek2, Rub2 = balli.Rub2, Samost = balli.Samost, Dosdacha = balli.Dosdacha, Premial = balli.Premial, Itog = balli.Itog };

                ViewBag.Vedomost = BalliStudnets;

                string[] Dannie = new string[7];
                Dannie[0] = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                Dannie[1] = (from t in contextDB.tableGrupp where t.ID == Grupp_ID select t.Name).First().ToString();
                Dannie[2] = (from t in contextDB.tableDisciplin where t.ID == Disciplina_ID select t.Name).First().ToString();
                Dannie[3] = (from t in contextDB.tablePrinadlegnistDisciplin where t.ID_Disciplini == Disciplina_ID && t.ID_Facultet == Facultet_ID && t.ID_Gruppi == Grupp_ID select t.Otchetnost).First().ToString();
                Dannie[4] = (from t in contextDB.tablePrinadlegnistDisciplin where t.ID_Disciplini == Disciplina_ID && t.ID_Facultet == Facultet_ID && t.ID_Gruppi == Grupp_ID select t.KR_KP).First().ToString();
                Dannie[5] = (from t in contextDB.tablePrinadlegnistDisciplin where t.ID_Disciplini == Disciplina_ID && t.ID_Facultet == Facultet_ID && t.ID_Gruppi == Grupp_ID select t.ChasiDisciplini).First().ToString();
                Dannie[6] = (
                    //2 раза
                    from t in contextDB.tablePrinadlegnistDisciplin
                    where t.ID_Disciplini == Disciplina_ID && t.ID_Facultet == Facultet_ID && t.ID_Gruppi == Grupp_ID
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.Name
                    ).First().ToString();

                ViewBag.Dannie = Dannie;


                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Statistic(string Facultet_ID)
        {
            try{
            int Facult_ID = int.Parse(Facultet_ID);
            var StudentsOfFaculti =
                from s in contextDB.tableStudents
                join g in contextDB.tableGrupp on s.ID_Gruppi equals g.ID
                join f in contextDB.tableFacultet on g.IDFacultet equals f.ID 
                where f.ID == Facult_ID
                select s;

            string Fname =
                (from f in contextDB.tableFacultet
                 where f.ID == Facult_ID
                 select f.Name).First();

            //студенты приступившие к сессии
            int StudentiPrestupivshieKSessii =
                (from ksf in StudentsOfFaculti
                join tb in contextDB.tableBalli on ksf.ID equals tb.ID_Studenta
                where tb.Itog >= 41
                group ksf by ksf.ID into gg
                select new {sss = gg.Key }).Count();
                


            //абсолютная успеваемость
            int AbsolutnayaUspevaemost = 0;

            foreach (var ksf in StudentsOfFaculti)
            {
                foreach (var b in contextDB.tableBalli)
                {
                    if (ksf.ID == b.ID_Studenta && b.Itog >= 41)
                    {
                        
                    }
                    else
                    {
                        AbsolutnayaUspevaemost--;
                        break;
                    }
                }
                AbsolutnayaUspevaemost++;
            }


            int Otlichniki = 0;//отличники
            foreach (var ksf in StudentsOfFaculti)
            {
                foreach (var b in contextDB.tableBalli)
                {
                    if (ksf.ID == b.ID_Studenta && b.Itog >= 81)
                    {

                    }
                    else
                    {
                        Otlichniki--;
                        break;
                    }
                }
                Otlichniki++;
            }

            int Hotoshisti = 0;//хорошисти
            foreach (var ksf in StudentsOfFaculti)
            {
                foreach (var b in contextDB.tableBalli)
                {
                    if (ksf.ID == b.ID_Studenta && b.Itog >= 61 && b.Itog < 81)
                    {
                        
                        
                    }
                    else
                    {
                        Hotoshisti--;
                        break;
                    }
                }
                Hotoshisti++;
            }

            int KachestvennayaUspevaemost = Hotoshisti + Otlichniki;

            int Troeshniki = 0;//троешники
            foreach (var ksf in StudentsOfFaculti)
            {
                foreach (var b in contextDB.tableBalli)
                {
                    if (ksf.ID == b.ID_Studenta && b.Itog >= 41 && b.Itog < 61)
                    {
                        
                    }
                    else
                    {
                        Troeshniki--;
                        break;
                    }
                }
                Troeshniki++;
            }


            int Zadolgniki = 0;//задолжники
            foreach (var ksf in StudentsOfFaculti)
            {
                foreach (var b in contextDB.tableBalli)
                {
                    if (ksf.ID == b.ID_Studenta && b.Itog < 41)
                    {
                        Zadolgniki++;
                        break;
                    }
                    else
                    {

                    }
                }
            }

            ViewBag.KolStudentov = StudentsOfFaculti.Count();
            ViewBag.StudentiPrestupivshieKSessii = StudentiPrestupivshieKSessii;
            ViewBag.AbsolutnayaUspevaemost = AbsolutnayaUspevaemost;
            ViewBag.Otlichniki = Otlichniki;
            ViewBag.Hotoshisti = Hotoshisti;
            ViewBag.KachestvennayaUspevaemost = KachestvennayaUspevaemost;
            ViewBag.Troeshniki = Troeshniki;
            ViewBag.Zadolgniki = Zadolgniki;
            ViewBag.Fname = Fname;
            
            //Профили факультета
            var profiles =
                from p in contextDB.tableProfile
                from g in contextDB.tableGrupp
                where p.ID == g.IDProfile && g.IDFacultet == Facult_ID
                select p;

            profiles = profiles.Distinct();

            //Количество студентов по профилям
            Dictionary<string, int> kolStudProfile = new Dictionary<string, int>();
            int studentProfileKol = 0;
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        studentProfileKol++;
                    }
                }
                string sss = p.Name;
                kolStudProfile.Add(p.Name, studentProfileKol);
                studentProfileKol = 0;
            }


            //Абсолютная успеваемость по профилям и специализациям
            int AbsolutnayaUspevaemosProfile = 0;
            Dictionary<string, int> absUspList = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        foreach (var b in contextDB.tableBalli)
                        {
                            if (ksf.ID == b.ID_Studenta && b.Itog >= 41)
                            {

                            }
                            else
                            {
                                AbsolutnayaUspevaemosProfile--;
                                break;
                            }
                        }
                        AbsolutnayaUspevaemosProfile++;
                    }
                }
                absUspList.Add(p.Name, AbsolutnayaUspevaemosProfile);
                AbsolutnayaUspevaemosProfile = 0;
            }

            //отличники по профилям
            int otlichnikiProfiles = 0;
            Dictionary<string, int> otlProfile = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        foreach (var b in contextDB.tableBalli)
                        {
                            if (ksf.ID == b.ID_Studenta && b.Itog >= 81)
                            {

                            }
                            else
                            {
                                otlichnikiProfiles--;
                                break;
                            }
                        }
                        otlichnikiProfiles++;
                    }
                }
                otlProfile.Add(p.Name, otlichnikiProfiles);
                otlichnikiProfiles = 0;
            }
            
            //хорошисты
            int horoshProfiles = 0;
            Dictionary<string, int> horProfile = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        foreach (var b in contextDB.tableBalli)
                        {
                            if (ksf.ID == b.ID_Studenta && b.Itog >= 61 && b.Itog < 81)
                            {

                            }
                            else
                            {
                                horoshProfiles--;
                                break;
                            }
                        }
                        horoshProfiles++;
                    }
                }
                horProfile.Add(p.Name, horoshProfiles);
                horoshProfiles = 0;
            }

            //качественная успеваемость
            Dictionary<string, int> kachestvenayaUspevaemostProfile = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                kachestvenayaUspevaemostProfile.Add(p.Name, horProfile[p.Name] + otlProfile[p.Name]);
            }

            //троешники
            int troeshProfiles = 0;
            Dictionary<string, int> troeshnikiProfile = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        foreach (var b in contextDB.tableBalli)
                        {
                            if (ksf.ID == b.ID_Studenta && b.Itog >= 41 && b.Itog < 61)
                            {

                            }
                            else
                            {
                                troeshProfiles--;
                                break;
                            }
                        }
                        troeshProfiles++;
                    }
                }
                troeshnikiProfile.Add(p.Name, troeshProfiles);
                troeshProfiles = 0;
            }


            //Задолжники по профилям
            int zadolgnikiProfiles = 0;
            Dictionary<string, int> zadolgnikiProfile = new Dictionary<string, int>();
            foreach (var p in profiles)
            {
                foreach (var ksf in StudentsOfFaculti)
                {
                    if (ksf.tableGrupp.IDProfile == p.ID)
                    {
                        foreach (var b in contextDB.tableBalli)
                        {
                            if (ksf.ID == b.ID_Studenta && b.Itog < 41)
                            {
                                zadolgnikiProfiles++;
                                break;
                            }
                        }
                    }
                }
                zadolgnikiProfile.Add(p.Name, zadolgnikiProfiles);
                zadolgnikiProfiles = 0;
            }

            ViewBag.Profiles = profiles;
            ViewBag.AbsUspList = absUspList;
            ViewBag.OtlProfile = otlProfile;
            ViewBag.horProfile = horProfile;
            ViewBag.KachestvenayaUspevaemostProfile = kachestvenayaUspevaemostProfile;
            ViewBag.TroeshnikiProfile = troeshnikiProfile;
            ViewBag.ZadolgnikiProfile = zadolgnikiProfile;
            ViewBag.KolStudProfile = kolStudProfile;

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
                string controller = RouteData.GetRequiredString("controller");
                string action = RouteData.GetRequiredString("action");
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
                    if (controller == "Admin" && (action == "ProsmotrAttVedomosti" || action == "ProsmotrEkzVedomosti" || action == "SvodniyJurnal" || action == "Statistic" ))
                    {
                        return View();
                    }
                    else
                    {
                        return View("NotFound");
                    }
                }
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult PDF(string Facultet, string Gruppa, string Disciplina, string Vedomost, string VidVedomost)
        {
            try
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                string nazvanie = "";
                string MetodPechati = "";
                int GruppaID = int.Parse(Gruppa);
                int DisciplinaID = int.Parse(Disciplina);

                string GruppaName =
                    (from g in contextDB.tableGrupp
                     where g.ID == GruppaID
                     select g.Name).First().ToString();

                string DisciplinaName =
                    (from g in contextDB.tableDisciplin
                     where g.ID == DisciplinaID
                     select g.Name).First().ToString();

                if (VidVedomost == "ATT")
                {
                    htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Landscape;
                    MetodPechati = "ProsmotrAttVedomosti";
                    nazvanie = "Атт. ведомость " + GruppaName + " по дисциплине " + " .pdf";
                }
                else
                {
                    htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Portrait;
                    MetodPechati = "ProsmotrEkzVedomosti";
                    nazvanie = "Зач./Экз. ведомость " + GruppaName + " по дисциплине " + " .pdf";

                }
                string Host = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Admin")-1);
                string Zapros = Url.Action(MetodPechati, "Admin", new { Facultet = Facultet, Gruppa = Gruppa, Disciplina = Disciplina, Vedomost = Vedomost });
                string put = Host + Zapros;
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
                    byte[] pdfBytes = htmlToPdf.GeneratePdfFromFile(put, null);
                    Response.AddHeader("Content-Disposition", "inline; filename=" + nazvanie);
                    return File(pdfBytes, "application/pdf");
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

        [Authorize]
        public ActionResult PDFStatistic(string Facultet_ID)
        {
            try
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                string Host = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Admin") - 1);
                string Zapros = Url.Action("Statistic", "Admin", new { Facultet_ID = Facultet_ID });
                int Fac_ID = int.Parse(Facultet_ID);
                string FacName =
                    (from fn in contextDB.tableFacultet
                     where fn.ID == Fac_ID
                     select fn.Name).First();
                string nazvanie = FacName+ ": Статистика";
                string put = Host + Zapros;
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
                    byte[] pdfBytes = htmlToPdf.GeneratePdfFromFile(put, null);
                    Response.AddHeader("Content-Disposition", "inline; filename=" + nazvanie);
                    return File(pdfBytes, "application/pdf");
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


        [Authorize]
        public ActionResult PDFSvodJournal(string Facultet, string Gruppa)
        {
            try
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Landscape;
                string Host = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Admin") - 1);
                string Zapros = Url.Action("SvodniyJurnal", "Admin", new { Facultet = Facultet, Gruppa = Gruppa });
                string put = Host + Zapros;
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
                    byte[] pdfBytes = htmlToPdf.GeneratePdfFromFile(put, null);
                    Response.AddHeader("Content-Disposition", "inline; filename=" + "SvodniyJournal");
                    return File(pdfBytes, "application/pdf");
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
