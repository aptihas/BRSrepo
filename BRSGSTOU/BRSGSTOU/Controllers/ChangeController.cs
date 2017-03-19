using BRSGSTOU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRSGSTOU.Controllers
{
    public class ChangeController : Controller
    {
        //
        // GET: /Change/
        Models.dbBRSEntities contextDB = new dbBRSEntities();


        //Добавление преподавателя
        [Authorize]
        public ActionResult AddTeacher()
        {
            try
            {
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
        public ActionResult AddTeacher(string teacherFio)
        {
            try
            {
                tablePrepods prepodObj = new tablePrepods();
                prepodObj.Name = teacherFio;
                contextDB.tablePrepods.Add(prepodObj);
                contextDB.SaveChanges();
                BRSGSTOU.Translit trans = new Translit();

                int prepodID = prepodObj.ID;
                string Login = trans.TranslitFileName(teacherFio);
                string Parol = trans.GenPassword(teacherFio).Substring(trans.GenPassword(teacherFio).Length / 2);
                if (Login.Length > 16)
                {
                    Login = Login.Substring(0, 16);
                }
                if (Parol.Length > 8)
                {
                    Parol = Parol.Substring(0, 8);
                }
                int Rol = 2;
                contextDB.teachersAccounts.Add(new teachersAccounts { Role_ID = Rol, ID_Prepoda = prepodID, Login = Login, Password = Parol });
                contextDB.SaveChanges();


                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        //При измении студента нобходимо изменять  связанные записи в других таблицах. tableBalli и tablePosheniy
        //добавление студента
        [Authorize]
        public ActionResult AddStudent()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Grupps =
                    from g in contextDB.tableGrupp
                    where g.IDFacultet == Facultet_ID
                    select new GruppaModel { Facultet_ID = Facultet_ID, Gruppa = g.Name, ID = g.ID };

                ViewBag.Grupps = Grupps;
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
        public ActionResult AddStudent(string studentFio, string idGruppi, string NomerZachetki)
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Grupps =
                    from g in contextDB.tableGrupp
                    where g.IDFacultet == Facultet_ID
                    select new GruppaModel { Facultet_ID = Facultet_ID, Gruppa = g.Name, ID = g.ID };

                ViewBag.Grupps = Grupps;
                int ID_Gruppi = int.Parse(idGruppi);
                string NomerZach = NomerZachetki;

                string fioLower = studentFio.Trim().ToLower();
                string[] masFio = fioLower.Split(new char[] { ' ' });
                string upperFio = "", firsChar = "";

                foreach (string q in masFio)
                {
                    firsChar = q[0].ToString().ToUpper();
                    upperFio += firsChar + q.Substring(1) + " ";
                }

                studentFio = upperFio;
                contextDB.tableStudents.Add(new tableStudents { ID_Gruppi = ID_Gruppi, Name = studentFio, NomerZachetki = NomerZach });
                contextDB.SaveChanges();

                int idStudenta =
                    (from s in contextDB.tableStudents
                     where s.NomerZachetki == NomerZach
                     select s.ID).First();

                var Disciplins =
                    from d in contextDB.tablePrinadlegnistDisciplin
                    where d.ID_Gruppi == ID_Gruppi
                    select d;
                foreach (var d in Disciplins)
                {
                    contextDB.tableBalli.Add(new tableBalli { ID_Gruppi = ID_Gruppi, ID_Disciplini = d.ID_Disciplini, ID_prepoda = d.ID_Prepoda, ID_Studenta = idStudenta, Pos1 = 0, Tek1 = 0, Rub1 = 0, Pos2 = 0, Tek2 = 0, Rub2 = 0, Samost = 0, Dosdacha = 0, Premial = 0, Itog = 0 });
                }
                contextDB.SaveChanges();

                var chisloZan =
                    from cz in contextDB.tableZanyatiy
                    where cz.ID_Gruppi == ID_Gruppi
                    select cz;

                foreach (var vz in chisloZan)
                {
                    contextDB.tablePoseshenie.Add(new tablePoseshenie { ID_Studenta = idStudenta, ID_Zanyatiya = vz.ID, Otmetka = 0 });
                }
                contextDB.SaveChanges();
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }


        }

        //удаление студента
        [Authorize]
        public ActionResult DelStudent()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Students =
                    //2 раза
                    from g in contextDB.tableGrupp
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == g.ID && g.IDFacultet == Facultet_ID
                    orderby g.Name
                    select new ModelStudent { ID_Gruppi = s.ID_Gruppi, NomerZachetki = s.NomerZachetki, GruppName = g.Name, ID_Studenta = s.ID, FIOStudenta = s.Name };

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
        public ActionResult DelStudent(string idStudenta)
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Students =
                    //2 раза
                    from g in contextDB.tableGrupp
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == g.ID && g.IDFacultet == Facultet_ID
                    orderby g.Name
                    select new ModelStudent { ID_Gruppi = s.ID_Gruppi, NomerZachetki = s.NomerZachetki, GruppName = g.Name, ID_Studenta = s.ID, FIOStudenta = s.Name };

                int IDStudenta = int.Parse(idStudenta);

                var balli =
                    from b in contextDB.tableBalli
                    where b.ID_Studenta == IDStudenta
                    select b;

                foreach (var b in balli)
                {
                    contextDB.tableBalli.Remove(b);
                }
                contextDB.SaveChanges();

                var posesh =
                    from p in contextDB.tablePoseshenie
                    where p.ID_Studenta == IDStudenta
                    select p;

                foreach (var p in posesh)
                {
                    contextDB.tablePoseshenie.Remove(p);
                }
                contextDB.SaveChanges();



                var student =
                    (from s in contextDB.tableStudents
                     where s.ID == IDStudenta
                     select s).First();

                contextDB.tableStudents.Remove(student);
                contextDB.SaveChanges();

                ViewBag.Students = Students;
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult ChangeGruppName()
        {
            try
            {
                int Facult_ID =
                    (from f in contextDB.tableAdmins
                     where f.Login == User.Identity.Name
                     select f.Facultet_ID).First();

                var Grupps =
                    from g in contextDB.tableGrupp
                    where g.IDFacultet == Facult_ID
                    select g;

                ViewBag.Grupps = Grupps;
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
        public ActionResult ChangeGruppName(string idGruppi, string GruppNewName)
        {
            try
            {
                int dvrCifri = int.Parse(GruppNewName.Substring(GruppNewName.IndexOf("-") + 1, 2));
                int ID_gruppi = int.Parse(idGruppi);
                var GruppName =
                    (from gn in contextDB.tableGrupp
                     where gn.ID == ID_gruppi
                     select gn).First();
                GruppName.Name = GruppNewName.ToUpper();
                contextDB.SaveChanges();

                int Facult_ID =
                    (from f in contextDB.tableAdmins
                     where f.Login == User.Identity.Name
                     select f.Facultet_ID).First();

                var Grupps =
                    from g in contextDB.tableGrupp
                    where g.IDFacultet == Facult_ID
                    select g;

                ViewBag.Grupps = Grupps;
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }


        [Authorize]
        public ActionResult ChangePrepodDisciplin()
        {
            try
            {
                int Facult_ID =
                    (from f in contextDB.tableAdmins
                     where f.Login == User.Identity.Name
                     select f.Facultet_ID).First();

                var prinadlegnostDisciplin =
                    from pd in contextDB.tablePrinadlegnistDisciplin
                    where pd.ID_Facultet == Facult_ID && pd.ID_Facultet == pd.tableGrupp.IDFacultet
                    from p in contextDB.tablePrepods
                    where pd.ID_Prepoda == p.ID
                    orderby pd.ID_Gruppi, p.Name, pd.ID_Disciplini
                    select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = p.Name, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;

                var prepods =
                    from p in contextDB.tablePrepods
                    orderby p.Name
                    select p;
                ViewBag.Prepods = prepods;
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
        public ActionResult ChangePrepodDisciplin(string idOldPrepod, string idNewPrepod)
        {
            try
            {
                int idPrinDiscip = int.Parse(idOldPrepod);
                var disciplinaPrepod =
                    (from dp in contextDB.tablePrinadlegnistDisciplin
                     where dp.ID == idPrinDiscip
                     select dp).First();

                disciplinaPrepod.ID_Prepoda = int.Parse(idNewPrepod);
                contextDB.SaveChanges();

                int Facult_ID =
                    (from f in contextDB.tableAdmins
                     where f.Login == User.Identity.Name
                     select f.Facultet_ID).First();

                var prinadlegnostDisciplin =
                    //2 раза
                    from pd in contextDB.tablePrinadlegnistDisciplin
                    where pd.ID_Facultet == Facult_ID && pd.ID_Facultet == pd.tableGrupp.IDFacultet
                    from p in contextDB.tablePrepods
                    where pd.ID_Prepoda == p.ID
                    orderby pd.ID_Gruppi, p.Name, pd.ID_Disciplini

                    select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = p.Name, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;

                var prepods =
                    from p in contextDB.tablePrepods
                    select p;
                ViewBag.Prepods = prepods;
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        // Добавление дисциплины для группы
        [Authorize]
        public ActionResult AddDisciplin()
        {
            try
            {
                int Facult_ID =
                        (from f in contextDB.tableAdmins
                         where f.Login == User.Identity.Name
                         select f.Facultet_ID).First();

                var prepods =
                    from p in contextDB.tablePrepods
                    orderby p.Name
                    select p;

                var Grupps =
                       from g in contextDB.tableGrupp
                       where g.IDFacultet == Facult_ID
                       select g;

                ViewBag.Grupps = Grupps;
                ViewBag.Prepods = prepods;
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
        public ActionResult AddDisciplin(string idGruppi, string idPrepoda, string disciplinName, string vidOtchetnosti, string kursovayaOtchenost, string chasiDisciplini)
        {
            try
            {
                int _idGruppi = int.Parse(idGruppi);
                int _idPrepoda = int.Parse(idPrepoda);
                int _vidOtchetnosti = int.Parse(vidOtchetnosti);
                int _kursovayaOtchenost = int.Parse(kursovayaOtchenost);
                int _chasiDisciplini = int.Parse(chasiDisciplini);



                int Disciplin_ID = 0;
                int Facult_ID =
                        (from f in contextDB.tableAdmins
                         where f.Login == User.Identity.Name
                         select f.Facultet_ID).First();

                var prepods =
                    from p in contextDB.tablePrepods
                    orderby p.Name
                    select p;

                var Grupps =
                       from g in contextDB.tableGrupp
                       where g.IDFacultet == Facult_ID
                       select g;

                ViewBag.Grupps = Grupps;
                ViewBag.Prepods = prepods;

                disciplinName = FirstUpper(disciplinName);
                //добавление в таблицу Принадлежность дисциплин
                var spisokDisciplin =
                    from d in contextDB.tableDisciplin
                    select d.Name;

                if (spisokDisciplin.Contains(disciplinName))
                {
                    Disciplin_ID =
                        (from s in contextDB.tableDisciplin
                         where s.Name == disciplinName
                         select s.ID).First();
                }
                else
                {
                    contextDB.tableDisciplin.Add(new tableDisciplin { Name = disciplinName });
                    contextDB.SaveChanges();
                    Disciplin_ID =
                        (from s in contextDB.tableDisciplin
                         where s.Name == disciplinName
                         select s.ID).First();
                }
                contextDB.tablePrinadlegnistDisciplin.Add(new tablePrinadlegnistDisciplin { ID_Facultet = Facult_ID, ID_Gruppi = _idGruppi, ID_Disciplini = Disciplin_ID, ID_Prepoda = _idPrepoda, Otchetnost = _vidOtchetnosti, KR_KP = _kursovayaOtchenost, ChasiDisciplini = _chasiDisciplini });
                contextDB.SaveChanges();


                var students =
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == _idGruppi
                    select s;

                foreach (var s in students)
                {
                    contextDB.tableBalli.Add(new tableBalli { ID_Gruppi = _idGruppi, ID_Disciplini = Disciplin_ID, ID_prepoda = _idPrepoda, ID_Studenta = s.ID, Pos1 = 0, Tek1 = 0, Rub1 = 0, Pos2 = 0, Tek2 = 0, Rub2 = 0, Samost = 0, Dosdacha = 0, Premial = 0, Itog = 0 });
                }
                contextDB.SaveChanges();
                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        //удаление дисциплины
        [Authorize]
        public ActionResult DelDisciplin()
        {
            try
            {
                int Facult_ID =
                        (from f in contextDB.tableAdmins
                         where f.Login == User.Identity.Name
                         select f.Facultet_ID).First();

                var prinadlegnostDisciplin =
                    from pd in contextDB.tablePrinadlegnistDisciplin
                    where pd.ID_Facultet == Facult_ID && pd.ID_Facultet == pd.tableGrupp.IDFacultet
                    from p in contextDB.tablePrepods
                    where pd.ID_Prepoda == p.ID
                    orderby pd.ID_Gruppi, p.Name, pd.ID_Disciplini
                    select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = p.Name, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;

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
        public ActionResult DelDisciplin(string massivZnach)
        {
            //полностью удалять дисциплину нельзя. Потому что она может читаться в других группах.
            //Этот метод удаляет дисциплину для группы.
            try
            {
                string[] _znach = massivZnach.Split(',');
                int _idDisciplini = int.Parse(_znach[0]);
                int _idGruppa = int.Parse(_znach[1]);
                int Facult_ID =
                    (from f in contextDB.tableAdmins
                     where f.Login == User.Identity.Name
                     select f.Facultet_ID).First();

                var prinadlegnostDisciplin =
                    from pd in contextDB.tablePrinadlegnistDisciplin
                    where pd.ID_Facultet == Facult_ID && pd.ID_Facultet == pd.tableGrupp.IDFacultet
                    from p in contextDB.tablePrepods
                    where pd.ID_Prepoda == p.ID
                    orderby pd.ID_Gruppi, p.Name, pd.ID_Disciplini
                    select new TeachersData { prinadlegnostDisciplin_ID = pd.ID, Gruppa_ID = pd.ID_Gruppi, Gruppa = pd.tableGrupp.Name, Prepod_ID = pd.ID_Prepoda, Prepod = p.Name, Facultet_ID = pd.ID_Facultet, Facultet = pd.tableFacultet.Name, Disciplina_ID = pd.ID_Disciplini, Disciplina = pd.tableDisciplin.Name };
                ViewBag.PrinadlegnostDisciplin = prinadlegnostDisciplin;

                var _tablicaBalli =
                    from b in contextDB.tableBalli
                    where b.ID_Disciplini == _idDisciplini && b.ID_Gruppi == _idGruppa
                    select b;

                foreach (var b in _tablicaBalli)
                {
                    contextDB.tableBalli.Remove(b);
                }

                var _tablicaPD =
                     from p in contextDB.tablePrinadlegnistDisciplin
                     where p.ID_Disciplini == _idDisciplini && p.ID_Gruppi == _idGruppa
                     select p;

                foreach (var p in _tablicaPD)
                {
                    contextDB.tablePrinadlegnistDisciplin.Remove(p);
                }
                contextDB.SaveChanges();

                ViewBag.Message = "ok";
                return isAdminMetod();
            }
            catch
            {
                return View("Error");
            }
        }
        //изменение фамилии студента
        [Authorize]
        public ActionResult ChangeFioStudent()
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Students =
                    //2 раза
                    from g in contextDB.tableGrupp
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == g.ID && g.IDFacultet == Facultet_ID
                    orderby g.Name
                    select new ModelStudent { ID_Gruppi = s.ID_Gruppi, NomerZachetki = s.NomerZachetki, GruppName = g.Name, ID_Studenta = s.ID, FIOStudenta = s.Name };

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
        public ActionResult ChangeFioStudent(string idStudenta, string StudentNewName)
        {
            try
            {
                int Facultet_ID =
                       (from r in contextDB.tableAdmins
                        where r.Login == User.Identity.Name
                        select r.Facultet_ID).First();

                var Students =
                    //2 раза
                    from g in contextDB.tableGrupp
                    from s in contextDB.tableStudents
                    where s.ID_Gruppi == g.ID && g.IDFacultet == Facultet_ID
                    orderby g.Name
                    select new ModelStudent { ID_Gruppi = s.ID_Gruppi, NomerZachetki = s.NomerZachetki, GruppName = g.Name, ID_Studenta = s.ID, FIOStudenta = s.Name };

                int IDStudenta = int.Parse(idStudenta);

                var student =
                    (from s in contextDB.tableStudents
                     where s.ID == IDStudenta
                     select s).First();


                string fioLower = StudentNewName.Trim().ToLower();
                string[] masFio = fioLower.Split(new char[] { ' ' });
                string upperFio = "", firsChar = "";

                foreach (string q in masFio)
                {
                    firsChar = q[0].ToString().ToUpper();
                    upperFio += firsChar + q.Substring(1) + " ";
                }

                student.Name = upperFio;
                contextDB.SaveChanges();

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
                if (controller == "Admin" && (action == "ProsmotrAttVedomosti" || action == "ProsmotrEkzVedomosti"))
                {
                    return View();
                }
                else
                {
                    return View("NotFound");
                }
            }
        }

        public static string FirstUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        }
    }
}
