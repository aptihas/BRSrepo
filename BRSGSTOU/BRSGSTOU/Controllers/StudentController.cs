using BRSGSTOU.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace BRSGSTOU.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
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

        public ActionResult ViborFaculteta()
        {
            var contextDB = new Models.dbBRSEntities();
            var facults =
                from f in contextDB.tableFacultet
                orderby f.Name
                select f;
            ViewBag.Faculteti = facults;
            return View();
        }

        public ActionResult BalliPoVsemPredmetam(string Facultet, string Gruppa)
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

                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ViborGruppi()
        {
            try
            {
                var contextDB = new Models.dbBRSEntities();
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));

                var Grupps =
                    from gruppa in contextDB.tableGrupp
                    where gruppa.IDFacultet == Facultet_ID
                    orderby gruppa.Name
                    select gruppa;
                ViewBag.Gruppi = Grupps;

                string FacultetName;
                FacultetName = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                ViewBag.FacultetName = FacultetName;

                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ViborDisciplini()
        {
            try
            {
                var contextDB = new Models.dbBRSEntities();
                int Facultet_ID = int.Parse(Request.QueryString.Get(0));
                int Grupp_ID = int.Parse(Request.QueryString.Get(1));

                var Disciplins =
                    from disciplinaID in contextDB.tablePrinadlegnistDisciplin
                    where disciplinaID.ID_Facultet == Facultet_ID && disciplinaID.ID_Gruppi == Grupp_ID && disciplinaID.ID_Disciplini == disciplinaID.tableDisciplin.ID
                    orderby disciplinaID.ID_Disciplini
                    select disciplinaID.tableDisciplin;

                ViewBag.Disciplini = Disciplins;

                string[] Dannie = new string[3];
                Dannie[0] = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                Dannie[1] = (from t in contextDB.tableGrupp where t.ID == Grupp_ID select t.Name).First().ToString();
                ViewBag.Dannie = Dannie;

                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult PokazatVedomost()
        {
            try
            {
                var contextDB = new Models.dbBRSEntities();

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

                var BalliStudnets =
                    from balli in contextDB.tableBalli
                    where balli.ID_Gruppi == Grupp_ID && balli.ID_Disciplini == Disciplina_ID
                    join s in contextDB.tableStudents on balli.ID_Studenta equals s.ID
                    orderby s.Name
                    select new Vedomost { StudentName = s.Name, Pos1 = balli.Pos1, Tek1 = balli.Tek1, Rub1 = balli.Rub1, Pos2 = balli.Pos2, Tek2 = balli.Tek2, Rub2 = balli.Rub2, Samost = balli.Samost, Dosdacha = balli.Dosdacha, Premial = balli.Premial, Itog = balli.Itog };

                ViewBag.Vedomost = BalliStudnets;

                string[] Dannie = new string[3];
                Dannie[0] = (from t in contextDB.tableFacultet where t.ID == Facultet_ID select t.Name).First().ToString();
                Dannie[1] = (from t in contextDB.tableGrupp where t.ID == Grupp_ID select t.Name).First().ToString();
                Dannie[2] = (from t in contextDB.tableDisciplin where t.ID == Disciplina_ID select t.Name).First().ToString();
                ViewBag.Dannie = Dannie;

                //журнал


                var students =
                    from s in contextDB.tableStudents
                    where Grupp_ID == s.ID_Gruppi
                    orderby s.Name
                    select s;

                ViewBag.Students = students;

                var сhisloZanyatiy =
                    from d in contextDB.tableZanyatiy
                    select d;
                ViewBag.ChisloZanyatiy = сhisloZanyatiy;

                string GruppaName =
                    (from g in contextDB.tableGrupp
                     where g.ID == Grupp_ID
                     select g.Name).First();

                ViewBag.GruppaName = GruppaName;

                string SubjectName =
                    (from s in contextDB.tableDisciplin
                     where s.ID == Disciplina_ID
                     select s.Name).First();
                ViewBag.SubjectName = SubjectName;
                ViewBag.VidOtchetnosti = vidOtchetnosti;
                ViewBag.DiscipliniVM = DiscipliniVM;
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

    }
}
