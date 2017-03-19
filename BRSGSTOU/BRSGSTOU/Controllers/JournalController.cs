using BRSGSTOU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRSGSTOU.Controllers
{
    public class JournalController : Controller
    {
        //
        // GET: /Journal/
        Models.dbBRSEntities contextDB = new dbBRSEntities();

        [Authorize]
        public ActionResult JournalGrupps()
        {
            try
            {
                var prepodID =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.ID).First();

                var prepodName =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.Name).First();

                ViewBag.PrepodName = prepodName;


                var gruppiPrepoda =
                    from u in contextDB.tablePrinadlegnistDisciplin
                    where u.ID_Disciplini == u.tableDisciplin.ID && u.ID_Prepoda == prepodID
                    orderby u.ID_Disciplini
                    select new TeachersData { Gruppa = u.tableGrupp.Name, Gruppa_ID = u.tableGrupp.ID };
                ViewBag.PrepodDisciplins = gruppiPrepoda.Distinct();

                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }

        }

        [Authorize]
        public ActionResult JournalGruppsSubject()
        {
            try
            {
                var prepodID =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.ID).First();

                var prepodName =
                    //2 раза
                       (from t in contextDB.teachersAccounts
                        where t.Login == User.Identity.Name
                        from p in contextDB.tablePrepods
                        where t.ID_Prepoda == p.ID
                        select p.Name).First();
                ViewBag.PrepodName = prepodName;
                int Gruppa_ID = int.Parse(Request.QueryString.Get(0));
                string GruppaName =
                    (from g in contextDB.tableGrupp
                     where g.ID == Gruppa_ID
                     select g.Name).First();

                ViewBag.GruppaName = GruppaName;

                var discipliniPrepoda =
                    from u in contextDB.tablePrinadlegnistDisciplin
                    where u.ID_Disciplini == u.tableDisciplin.ID && u.ID_Prepoda == prepodID && u.tableGrupp.ID == Gruppa_ID
                    orderby u.ID_Disciplini
                    select new TeachersData { Disciplina = u.tableDisciplin.Name, Disciplina_ID = u.tableDisciplin.ID, Facultet_ID = u.tableGrupp.IDFacultet, Gruppa_ID = u.tableGrupp.ID, Prepod_ID = u.ID_Prepoda, Prepod = prepodName };

                ViewBag.PrepodDisciplins = discipliniPrepoda;
                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }

            
        }

        public JavaScriptResult DeleteDay(string Facultet_ID, string Gruppa_ID, string Disciplina_ID, string PrepodID, string IDZanyatiya)
        {
            try
            {
                int idZanyatiya = int.Parse(IDZanyatiya);

                var otmetki =
                    from o in contextDB.tablePoseshenie
                    where o.ID_Zanyatiya == idZanyatiya
                    select o;

                foreach (var o in otmetki)
                {
                    contextDB.tablePoseshenie.Remove(o);
                }

                var zanyatie =
                    (from z in contextDB.tableZanyatiy
                     where z.ID == idZanyatiya
                     select z).First();

                contextDB.tableZanyatiy.Remove(zanyatie);
                contextDB.SaveChanges();
                int GruppaID = int.Parse(Gruppa_ID);
                int DisciplinaID = int.Parse(Disciplina_ID);
                int Prepod_ID = int.Parse(PrepodID);

                var students =
                    from s in contextDB.tableStudents
                    where GruppaID == s.ID_Gruppi
                    orderby s.Name
                    select s;
                balliZaPoseshenie(GruppaID, DisciplinaID, Prepod_ID, students);
                var script = "$('input').removeAttr('disabled'); $('#center_loader').hide();" + "window.location ='" + Url.Action("JournalForSubjectofGrupp", "Journal", new { Facultet = Facultet_ID, Gruppa = Gruppa_ID, Predmet = Disciplina_ID, Prepodvatel = PrepodID }) + "' ;";
                return JavaScript(script);
            }
            catch
            {
                return JavaScript("createInfoBlock(4, false, 'Возникла ошибка! Дата не может быть удалена, обратитесь к администратору.');$('input').removeAttr('disabled'); $('#center_loader').hide();");
            }
        }

        [Authorize]
        public ActionResult JournalForSubjectofGrupp()
        {
            try
            {
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));
                int Gruppa_ID = int.Parse(Request.QueryString.Get(1));
                int Disciplina_ID = int.Parse(Request.QueryString.Get(2));
                int Prepod_ID = int.Parse(Request.QueryString.Get(3));

                var students =
                    from s in contextDB.tableStudents
                    where Gruppa_ID == s.ID_Gruppi
                    orderby s.Name
                    select s;

                ViewBag.Students = students;

                var сhisloZanyatiy =
                    from d in contextDB.tableZanyatiy
                    select d;
                ViewBag.ChisloZanyatiy = сhisloZanyatiy;


                var prepodName =
                    // 2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.Name).First();
                ViewBag.PrepodName = prepodName;


                string GruppaName =
                    (from g in contextDB.tableGrupp
                     where g.ID == Gruppa_ID
                     select g.Name).First();

                ViewBag.GruppaName = GruppaName;

                string SubjectName =
                    (from s in contextDB.tableDisciplin
                     where s.ID == Disciplina_ID
                     select s.Name).First();
                ViewBag.SubjectName = SubjectName;
                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult JournalForSubjectofGrupp(string Facultet_ID, string Gruppa_ID, string Disciplina_ID, string Prepod_ID, string Vremya)
        {
            try
            {

                int FacultetID = int.Parse(Facultet_ID);
                int GruppaID = int.Parse(Gruppa_ID);
                int DisciplinaID = int.Parse(Disciplina_ID);
                int PrepodID = int.Parse(Prepod_ID);
                DateTime proverkaDate;            
                //Проверка правильности даты
                if (DateTime.TryParse(Vremya.ToString(), out proverkaDate))
                {
                    if (DateTime.Now.Month >= 9 && DateTime.Now.Month <= 12)
                    {
                        if (proverkaDate.Month >= 9 && proverkaDate.Month <= 12)
                        {
                            contextDB.tableZanyatiy.Add(new tableZanyatiy { ID_Gruppi = GruppaID, ID_Disciplini = DisciplinaID, ID_Prepoda = PrepodID, Vremya = proverkaDate });
                            contextDB.SaveChanges();
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                    else if (DateTime.Now.Month >= 2 && DateTime.Now.Month <= 5)
                    {
                        if (proverkaDate.Month >= 2 && proverkaDate.Month <= 5)
                        {
                            contextDB.tableZanyatiy.Add(new tableZanyatiy { ID_Gruppi = GruppaID, ID_Disciplini = DisciplinaID, ID_Prepoda = PrepodID, Vremya = proverkaDate });
                            contextDB.SaveChanges();
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                    else
                    {
                        return View("Error");
                    }
                    
                }
                else
                {
                    return View("Error");
                }
                var idZanyatiya =
                     from z in contextDB.tableZanyatiy
                     where z.ID_Disciplini == DisciplinaID && z.ID_Gruppi == GruppaID && z.ID_Prepoda == PrepodID
                     orderby z.ID
                     select z.ID;//найти ид последней записи

                int idz = idZanyatiya.ToList().Last();

                foreach (var s in Request.Form.AllKeys)
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
                        contextDB.tablePoseshenie.Add(new tablePoseshenie { ID_Studenta = idStud, ID_Zanyatiya = idz, Otmetka = otmetka });
                    }
                }

                contextDB.SaveChanges();

                var prepodName =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.Name).First();
                ViewBag.PrepodName = prepodName;


                string GruppaName =
                    (from g in contextDB.tableGrupp
                     where g.ID == GruppaID
                     select g.Name).First();

                ViewBag.GruppaName = GruppaName;

                string SubjectName =
                    (from s in contextDB.tableDisciplin
                     where s.ID == DisciplinaID
                     select s.Name).First();
                ViewBag.SubjectName = SubjectName;

                var сhisloZanyatiy =
                    from d in contextDB.tableZanyatiy
                    select d;
                ViewBag.ChisloZanyatiy = сhisloZanyatiy;

                var students =
                    from s in contextDB.tableStudents
                    where GruppaID == s.ID_Gruppi
                    orderby s.Name
                    select s;

                ViewBag.Students = students;

                string[] Dannie = { Facultet_ID, Gruppa_ID, Disciplina_ID, Prepod_ID };
                ViewBag.Dannie = Dannie;

                balliZaPoseshenie(GruppaID, DisciplinaID, PrepodID, students);


                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        private void balliZaPoseshenie(int GruppaID, int DisciplinaID, int PrepodID, IOrderedQueryable<tableStudents> students)
        {
            DateTime osenNachalo = DateTime.Parse("01.09." + DateTime.Now.Year.ToString());
            DateTime osenKonec = DateTime.Parse("31.12." + DateTime.Now.Year.ToString());

            DateTime vesnaNachalo = DateTime.Parse("01.01." + DateTime.Now.Year.ToString());
            DateTime vesnaKonec = DateTime.Parse("01.06." + DateTime.Now.Year.ToString());
            DateTime pervayaAttestaciya = DateTime.Parse("07.11." + DateTime.Now.Year.ToString());
            DateTime vtorayaAttestaciya = DateTime.Parse("07.03." + DateTime.Now.Year.ToString());
            IEnumerable<tableZanyatiy> chisloParPervoyAttestacii;
            IEnumerable<tableZanyatiy> chisloParVtoroyAttestacii;
            if (DateTime.Now.Month >= 7 && DateTime.Now.Month <= 12)
            {
                    chisloParPervoyAttestacii =
                    from cz in contextDB.tableZanyatiy
                    where cz.ID_Gruppi == GruppaID && cz.ID_Disciplini == DisciplinaID && cz.ID_Prepoda == PrepodID && cz.Vremya>osenNachalo && cz.Vremya < pervayaAttestaciya
                    select cz;

                    chisloParVtoroyAttestacii =
                    from cz in contextDB.tableZanyatiy
                    where cz.ID_Gruppi == GruppaID && cz.ID_Disciplini == DisciplinaID && cz.ID_Prepoda == PrepodID && cz.Vremya > pervayaAttestaciya && cz.Vremya < osenKonec
                    select cz;
            }
            else
            {
                    chisloParPervoyAttestacii =
                    from cz in contextDB.tableZanyatiy
                    where cz.ID_Gruppi == GruppaID && cz.ID_Disciplini == DisciplinaID && cz.ID_Prepoda == PrepodID && cz.Vremya>vesnaNachalo && cz.Vremya < vtorayaAttestaciya
                    select cz;

                    chisloParVtoroyAttestacii =
                    from cz in contextDB.tableZanyatiy
                    where cz.ID_Gruppi == GruppaID && cz.ID_Disciplini == DisciplinaID && cz.ID_Prepoda == PrepodID && cz.Vremya > vtorayaAttestaciya && cz.Vremya<vesnaKonec
                    select cz;
            }

            foreach (var stud in students)
            {
                var chisloOtmetokPervoyAtt =
                    //2 раза
                    from z in chisloParPervoyAttestacii
                    from p in contextDB.tablePoseshenie
                    where z.ID == p.ID_Zanyatiya && p.ID_Studenta == stud.ID && p.Otmetka == 1
                    select p;

                var chisloOtmetokVtoroyAtt =
                    //2 раза
                    from z in chisloParVtoroyAttestacii
                    from p in contextDB.tablePoseshenie
                    where z.ID == p.ID_Zanyatiya && p.ID_Studenta == stud.ID && p.Otmetka == 1
                    select p;

                int pos1 = 0, pos2 = 0;
                if (chisloParPervoyAttestacii.Count() > 0)
                {
                    pos1 = chisloOtmetokPervoyAtt.Count() * 5 / chisloParPervoyAttestacii.Count();
                }
                if (chisloParVtoroyAttestacii.Count() > 0)
                {
                    pos2 = chisloOtmetokVtoroyAtt.Count() * 10 / chisloParVtoroyAttestacii.Count();
                }

                var StudentsPoint =
                    (from sp in contextDB.tableBalli
                     where sp.ID_Gruppi == GruppaID && sp.ID_Disciplini == DisciplinaID && sp.ID_prepoda == PrepodID && sp.ID_Studenta == stud.ID
                     select sp).First();
                StudentsPoint.Pos1 = pos1;
                StudentsPoint.Pos2 = pos2;

                StudentsPoint.Itog = StudentsPoint.Pos1 + StudentsPoint.Tek1 + StudentsPoint.Rub1 + StudentsPoint.Pos2 + StudentsPoint.Tek2 + StudentsPoint.Rub2 + StudentsPoint.Samost + StudentsPoint.Dosdacha + StudentsPoint.Premial;

            }
            contextDB.SaveChanges();
        }

        //Журнал для распечатки
        public ActionResult CreateJournal(string prepod_ID)
        {
            try
            {
                int ID_Prepoda = int.Parse(prepod_ID);
                string PrepodName =
                    (from p in contextDB.tablePrepods
                     where p.ID == ID_Prepoda
                     select p.Name).First();
                ViewBag.PrepodName = PrepodName;

                var prinadlegnostDisciplin =
                     from pd in contextDB.tablePrinadlegnistDisciplin
                     where pd.ID_Prepoda == ID_Prepoda
                     orderby pd.ID_Gruppi, pd.ID_Disciplini
                     select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = PrepodName, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;

                var students =
                    from s in contextDB.tableStudents
                    select s;
                ViewBag.Students = students;

                string controller = RouteData.GetRequiredString("controller");
                string action = RouteData.GetRequiredString("action");
                int rol = 0;
                try
                {
                    rol =
                       (from r in contextDB.teachersAccounts
                        where r.Login == User.Identity.Name
                        select r.Role_ID).First();
                }
                catch
                {

                }
                if (rol == 2)
                {
                    return View();
                }
                else
                {
                    if (controller == "Journal" && action == "CreateJournal")
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
        public ActionResult PDFJournal()
        {
            try
            {
                int ID_Prepoda =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.ID).First();

                string PrepodName =
                    (from p in contextDB.tablePrepods
                     where p.ID == ID_Prepoda
                     select p.Name).First();
                ViewBag.PrepodName = PrepodName;

                var prinadlegnostDisciplin =
                     from pd in contextDB.tablePrinadlegnistDisciplin
                     where pd.ID_Prepoda == ID_Prepoda
                     orderby pd.ID_Gruppi, pd.ID_Disciplini
                     select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = PrepodName, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;


                var students =
                    from s in contextDB.tableStudents
                    select s;
                ViewBag.Students = students;


                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                string nazvanie = "Журнал.pdf";
                htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Portrait;

                string Host = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Journal") - 1);
                string Zapros = Url.Action("CreateJournal", "Journal", new {prepod_ID = ID_Prepoda });
                string put = Host + Zapros;
                int rol = 0;
                try
                {
                    rol =
                       (from r in contextDB.teachersAccounts
                        where r.Login == User.Identity.Name
                        select r.Role_ID).First();
                }
                catch
                {

                }
                if (rol == 2)
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
        //Журнал для распечатки
        private ActionResult isTeacherMetod()
        {
            int rol = 0;
            try
            {
                rol =
                   (from r in contextDB.teachersAccounts
                    where r.Login == User.Identity.Name
                    select r.Role_ID).First();
            }
            catch
            {

            }

            if (rol == 2)
            {
                return View();
            }
            else
            {
                return View("NotFound");
            }
        }
    }
}
