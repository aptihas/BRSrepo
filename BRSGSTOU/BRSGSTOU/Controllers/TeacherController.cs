using BRSGSTOU.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BRSGSTOU.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        Models.dbBRSEntities contextDB = new dbBRSEntities();
        string FIOTeacher;
        List<string> DiscipliniVM = new List<string>()
        {
            "Высшая математика",
            "Математика",
            "Линейная алгебра",
            "Математический анализ",
            "Теория вероятности и математическая статистика",
            "Теория функций комплексных переменных Операционное исчисление",
            "Уравнения математической физики",
            "Математическое моделирование",
            "Математическое моделирование геопространственных данных",
            "Основы системного анализа",
            "Системный анализ",
            "Математика для экономистов",
            "Математические модели и методы в экономике",
            "Математическое моделирование в машиностроении",
            "Математическое моделирование технологических процессов",
            "Методы оптимальных решений",
            "Теория игр",
            "Эконометрика",
            "Экономико-математические методы и моделирование",
            "Экономико-математическое моделирование в управлении",
            "Общая теория статистики",
            "Социально-экономическая статистика",
            "Статистика",
            "Статистика: теория статистики и экономическая статистика",
            "Таможенная статистика"
        };

        public ActionResult Login()
        {
            ViewBag.TeacherAccounts = contextDB.teachersAccounts;
            return View();

        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("TeacherCabinet", "Teacher");
                    }
                }
                else if (ValidateAdmin(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("MainPanel", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("ViborFaculteta", "Student");
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;
            try
            {
                var user = (from u in contextDB.teachersAccounts
                            where u.Login == login && u.Password == password
                            select u).FirstOrDefault();
                if (user != null)
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        private bool ValidateAdmin(string login, string password)
        {
            bool isValid = false;
            try
            {
                var admin = (from u in contextDB.tableAdmins
                             where u.Login == login && u.Password == password
                             select u).FirstOrDefault();
                if (admin != null)
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        [Authorize]
        public ActionResult TeacherGrupps()
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
        public ActionResult GruppsSubject()
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

                int Gruppa_ID = int.Parse(Request.QueryString.Get(0));
                string GruppName =
                    (from gn in contextDB.tableGrupp
                     where gn.ID == Gruppa_ID
                     select gn.Name).First();
                ViewBag.GruppName = GruppName;

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
        [Authorize]
        public ActionResult TeacherCabinet()
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
        public ActionResult IzmenitVedomost()
        {
            try
            {
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));
                int Grupp_ID = int.Parse(Request.QueryString.Get(1));
                int Disciplina_ID = int.Parse(Request.QueryString.Get(2));

                int vidOt =
                    (from v in contextDB.tablePrinadlegnistDisciplin
                     where v.ID_Facultet == Facultet_ID && v.ID_Gruppi == Grupp_ID && v.ID_Disciplini == Disciplina_ID
                     select v.Otchetnost).First();
                string vidOtchetnosti = "";
                if (vidOt == 1)
                {
                    vidOtchetnosti = "Экзамен";
                }
                else
                {
                    vidOtchetnosti = "Зачет";
                }

                int Prepod_ID =
                    //2 раза
                   (from t in contextDB.teachersAccounts
                    where t.Login == User.Identity.Name
                    from p in contextDB.tablePrepods
                    where t.ID_Prepoda == p.ID
                    select p.ID).First();

                var BalliStudnets =
                    from balli in contextDB.tableBalli
                    where balli.ID_Gruppi == Grupp_ID && balli.ID_Disciplini == Disciplina_ID
                    join s in contextDB.tableStudents on balli.ID_Studenta equals s.ID
                    orderby s.Name
                    select new Vedomost { StudentName = s.Name, Student_ID = s.ID, Pos1 = balli.Pos1, Tek1 = balli.Tek1, Rub1 = balli.Rub1, Pos2 = balli.Pos2, Tek2 = balli.Tek2, Rub2 = balli.Rub2, Samost = balli.Samost, Dosdacha = balli.Dosdacha, Premial = balli.Premial, Itog = balli.Itog };
                ViewBag.Vedomost = BalliStudnets;

                string[] Dannie = new string[4];
                Dannie[0] = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                Dannie[1] = (from t in contextDB.tableGrupp where t.ID == Grupp_ID select t.Name).First().ToString();
                Dannie[2] = (from t in contextDB.tableDisciplin where t.ID == Disciplina_ID select t.Name).First().ToString();
                Dannie[3] = (from t in contextDB.tablePrepods where t.ID == Prepod_ID select t.Name).First().ToString();
                ViewBag.Prepod_ID = Prepod_ID;

                ViewBag.DiscipliniVM = DiscipliniVM;
                ViewBag.Dannie = Dannie;
                ViewBag.VidOtchetnosti = vidOtchetnosti;

                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public JavaScriptResult UpdateStudValue()
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
                return JavaScript("createInfoBlock(1, false, 'Возникла ошибка! Баллы не могут быть сохранены, обратитесь к администратору.');");
            }
            if (rol == 2)
            {
                try
                {
                    int Facultet_ID = int.Parse(Request.Params.Get("Facultet_ID"));
                    int Gruppa_ID = int.Parse(Request.Params.Get("Gruppa_ID"));
                    int Disciplina_ID = int.Parse(Request.Params.Get("Disciplina_ID"));
                    string vidBallov = Request.Params.Get("vidBallov");
                    int Student_ID = int.Parse(Request.Params.Get("student"));
                    int value = int.Parse(Request.Params.Get("value"));

                    string Disciplina =
                        (from t in contextDB.tableDisciplin
                         where t.ID == Disciplina_ID
                         select t.Name).First().ToString();

                    int Prepod_ID =
                        //2 раза
                       (from t in contextDB.teachersAccounts
                        where t.Login == User.Identity.Name
                        from p in contextDB.tablePrepods
                        where t.ID_Prepoda == p.ID
                        select p.ID).First();

                    var StudentsPoint =
                        (from sp in contextDB.tableBalli
                         where sp.ID_Gruppi == Gruppa_ID && sp.ID_Disciplini == Disciplina_ID && sp.ID_prepoda == Prepod_ID && sp.ID_Studenta == Student_ID
                         select sp).First();

                    int tek = 15, rub = 20;
                    if (DiscipliniVM.Contains(Disciplina))
                    {
                        tek = 10; rub = 25;
                    }
                    if (System.IO.File.Exists(Server.MapPath(Url.Content("/Models/AT.cs"))))
                    {
                        switch (vidBallov)
                        {
                            case "Tek1":
                                value = value > tek ? tek : value;
                                StudentsPoint.Tek1 = value;
                                break;

                            case "Rub1":
                                value = value > rub ? rub : value;
                                StudentsPoint.Rub1 = value;
                                break;
                        }
                        StudentsPoint.Itog = StudentsPoint.Pos1 + StudentsPoint.Tek1 + StudentsPoint.Rub1 + StudentsPoint.Pos2 + StudentsPoint.Tek2 + StudentsPoint.Rub2 + StudentsPoint.Samost + StudentsPoint.Dosdacha + StudentsPoint.Premial;
                        contextDB.SaveChanges();
                        return JavaScript("createInfoBlock(1, false, 'Данные сохранены');$('input').removeAttr('disabled'); $('#center_loader').hide();");
                    }
                    else if (System.IO.File.Exists(Server.MapPath(Url.Content("/Models/ATT.cs"))))
                    {
                        switch (vidBallov)
                        {
                            case "Tek2":
                                value = value > tek ? tek : value;
                                StudentsPoint.Tek2 = value;
                                break;
                            case "Rub2":
                                value = value > rub ? rub : value;
                                StudentsPoint.Rub2 = value;
                                break;
                            case "Samost":
                                value = value > 15 ? 15 : value;
                                StudentsPoint.Samost = value;
                                break;
                            case "Dosdacha":
                                value = value > 20 ? 20 : value;
                                StudentsPoint.Dosdacha = value;
                                break;
                            case "Premial":
                                value = value > 20 ? 20 : value;
                                StudentsPoint.Premial = value;
                                break;
                        }
                        StudentsPoint.Itog = StudentsPoint.Pos1 + StudentsPoint.Tek1 + StudentsPoint.Rub1 + StudentsPoint.Pos2 + StudentsPoint.Tek2 + StudentsPoint.Rub2 + StudentsPoint.Samost + StudentsPoint.Dosdacha + StudentsPoint.Premial;
                        contextDB.SaveChanges();
                        return JavaScript("createInfoBlock(1, false, 'Данные сохранены');$('input').removeAttr('disabled'); $('#center_loader').hide();");
                    }
                    else
                    {
                        return JavaScript("");
                    }
                }
                catch
                {
                    return JavaScript("createInfoBlock(1, false, 'Возникла ошибка! Баллы не могут быть сохранены, обратитесь к администратору.');");
                }
            }
            else
            {
                return JavaScript("createInfoBlock(1, false, 'Возникла ошибка! Баллы не могут быть сохранены, обратитесь к администратору.');");
            }
        }

        private ActionResult isTeacherMetod()
        {
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
                if (controller == "Teacher" && action == "ProsmotrAttVedomosti")
                {
                    return View();
                }
                else
                {
                    return View("NotFound");
                }
            }
        }

        public PartialViewResult Profile()
        {
            try
            {
                int rol = 0;
                if (Request.IsAuthenticated)
                {
                    if (User.Identity.Name != "" && User.Identity.Name != null)
                    {
                        try
                        {
                            FIOTeacher =
                                (from t in contextDB.teachersAccounts
                                 where t.Login == User.Identity.Name
                                 from p in contextDB.tablePrepods
                                 where t.ID_Prepoda == p.ID
                                 select p.Name).First().ToString();

                            rol =
                               (from r in contextDB.teachersAccounts
                                where r.Login == User.Identity.Name
                                select r.Role_ID).First();
                        }
                        catch
                        {
                            FIOTeacher =
                                (from t in contextDB.tableAdmins
                                 where t.Login == User.Identity.Name
                                 from p in contextDB.tableFacultet
                                 where t.Facultet_ID == p.ID
                                 select p.Name).First().ToString();

                            rol =
                               (from r in contextDB.tableAdmins
                                where r.Login == User.Identity.Name
                                select r.Role_ID).First();
                        }
                    }
                }


                ViewBag.FIOTeacher = FIOTeacher;
                ViewBag.Rol = rol;
                return PartialView();
            }
            catch
            {
                return PartialView("Error");
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
                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }
        }


        public ActionResult PDF(string Facultet, string Gruppa, string Disciplina)
        {
            try
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                string nazvanie = "";
                htmlToPdf.Orientation = NReco.PdfGenerator.PageOrientation.Landscape;
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

                string Host = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Teacher") - 1);
                string Zapros = Url.Action("ProsmotrAttVedomosti", "Teacher", new { Facultet = Facultet, Gruppa = Gruppa, Disciplina = Disciplina });
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


        [Authorize]
        public ActionResult Tickets()
        {
            return isTeacherMetod();
        }

        [Authorize]
        [HttpPost]
        public ActionResult TicketsView(string ticketsList, string ticketsCount, string questionsCount, string shapka, string podlogka)
        {
            try
            {
                
                string[] _ticketsList = ticketsList.Replace("\n", "").Split('\r');
                List<string> actualTicketList = new List<string>();

                foreach (string t in _ticketsList)
                {
                    if (t != "")
                        actualTicketList.Add(t);
                }

                int _ticketsCount = int.Parse(ticketsCount), _questionsCount = int.Parse(questionsCount);

                if (actualTicketList.Count < _questionsCount)
                    return View("Error");

                string[] _shapka = shapka.Split('\n');
                ViewBag.ticketsCount = _ticketsCount;
                ViewBag.questionsCount = _questionsCount;
                ViewBag.actualTicketList = actualTicketList;
                ViewBag.podlogka = podlogka;
                ViewBag.shapka = _shapka;

                List<string> proverka = new List<string>();//список для проверки
                List<string> finishQuestions = new List<string>();
                Random rnd = new Random();
                int x = 0;
                for (int i = 0; i < _ticketsCount; i++)
                {
                    while (x < _questionsCount)
                    {
                        int index = rnd.Next(0, actualTicketList.Count);
                        if (proverka.Contains(actualTicketList[index]))
                        {

                        }
                        else
                        {
                            proverka.Add(actualTicketList[index]);
                            finishQuestions.Add(actualTicketList[index]);
                            x++;
                        }
                    }
                    proverka.Clear();
                    x = 0;
                }
                ViewBag.finishQuestions = finishQuestions;
                return isTeacherMetod();
            }
            catch
            {
                return View("Error");
            }
         }
    }
}
