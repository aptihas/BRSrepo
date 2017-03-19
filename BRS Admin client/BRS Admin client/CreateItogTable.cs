using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS_Admin_client
{
    public partial class CreateItogTable : Form
    {
        public CreateItogTable()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void открытьЗагрузитьСписокСтудентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //После необходимо заполнить таблицу Администраторов системы



            //Порядок столбцов таблиы
            //0Группа
            //1Номер зачетки
            //2Студент
            //3Факультет
            //4Профиль
            openFileDialog1.Filter = "Excel (*.xls)|*.xls*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                c1FlexGridStudents.LoadExcel(openFileDialog1.FileName);
                //сохранение в книгу
            }
            загрузитьСписокДисциплинToolStripMenuItem.Enabled = true;
        }

        private void загрузитьСписокДисциплинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel (*.xls)|*.xls*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                c1FlexGridDisciplins.LoadExcel(openFileDialog1.FileName);
                //сохранение в книгу
            }
            сформироватьИтоговуюТаблицуToolStripMenuItem.Enabled = true;
        }

        private void сформироватьИтоговуюТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nomerStroki=0;
            for (int i = 1; i < c1FlexGridDisciplins.Rows.Count; i++)
            {
                for(int j = 0; j < c1FlexGridStudents.Rows.Count; j++)
                {
                    if (c1FlexGridDisciplins[i, 0].ToString() == c1FlexGridStudents[j, 0].ToString())
                    {
                        c1FlexGridItogTable.Rows.Add(1);
                        c1FlexGridItogTable[nomerStroki, 0] = c1FlexGridStudents[j, 3].ToString();
                        c1FlexGridItogTable[nomerStroki, 1] = c1FlexGridDisciplins[i, 0].ToString();
                        c1FlexGridItogTable[nomerStroki, 2] = c1FlexGridDisciplins[i, 2].ToString();
                        c1FlexGridItogTable[nomerStroki, 3] = c1FlexGridDisciplins[i, 4].ToString();
                        c1FlexGridItogTable[nomerStroki, 4] = c1FlexGridDisciplins[i, 5].ToString();
                        c1FlexGridItogTable[nomerStroki, 5] = c1FlexGridDisciplins[i, 3].ToString();
                        if (c1FlexGridDisciplins[i, 6].ToString().IndexOf("(") != -1)
                        {
                            c1FlexGridItogTable[nomerStroki, 6] = c1FlexGridDisciplins[i, 6].ToString().Substring(0, c1FlexGridDisciplins[i, 6].ToString().IndexOf("(")-1);
                        }
                        else
                        {
                            c1FlexGridItogTable[nomerStroki, 6] = c1FlexGridDisciplins[i, 6].ToString();
                        }
                        c1FlexGridItogTable[nomerStroki, 7] = c1FlexGridStudents[j, 1];
                        c1FlexGridItogTable[nomerStroki, 8] = c1FlexGridStudents[j, 2].ToString();
                        c1FlexGridItogTable[nomerStroki, 9] = c1FlexGridStudents[j, 4].ToString();
                        nomerStroki++;
                    }
                }
            }
        }

        private void занестиВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbBRSEntities ContextDB = new dbBRSEntities();

            List<string> Disciplins = new List<string>();
            List<string> Prepods = new List<string>();
            Dictionary<string, string> Students = new Dictionary<string, string>();
            List<string> Grupps = new List<string>();
            List<string> Facultets = new List<string>();
            List<string> Profiles = new List<string>();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = c1FlexGridItogTable.Rows.Count;
            //получение даннхы из таблицы
            for (int i = 0; i < c1FlexGridItogTable.Rows.Count; i++)
            {
                if (Facultets.Contains(c1FlexGridItogTable[i, 0].ToString()))
                {

                }
                else
                {
                    Facultets.Add(c1FlexGridItogTable[i, 0].ToString());
                }

                if (Profiles.Contains(c1FlexGridItogTable[i, 9].ToString()))
                {

                }
                else
                {
                    Profiles.Add(c1FlexGridItogTable[i, 9].ToString());
                }

                if (Grupps.Contains(c1FlexGridItogTable[i, 1].ToString()))
                {

                }
                else
                {
                    Grupps.Add(c1FlexGridItogTable[i, 1].ToString());
                }

                if (Disciplins.Contains(c1FlexGridItogTable[i, 2].ToString()))
                {

                }
                else
                {
                    Disciplins.Add(c1FlexGridItogTable[i, 2].ToString());
                }

                if (Prepods.Contains(c1FlexGridItogTable[i, 6].ToString()))
                {

                }
                else
                {
                    Prepods.Add(c1FlexGridItogTable[i, 6].ToString());
                }

                if (Students.ContainsKey(c1FlexGridItogTable[i, 7].ToString()))
                {

                }
                else
                {
                    Students.Add(c1FlexGridItogTable[i, 7].ToString(), c1FlexGridItogTable[i, 8].ToString());
                }
                progressBar1.Value++;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            //занесение данных

            ContextDB.tableRoles.Add(new tableRoles { Name = "Admin" });
            ContextDB.tableRoles.Add(new tableRoles { Name = "Teacher" });
            ContextDB.tableRoles.Add(new tableRoles { Name = "Student" });
            ContextDB.SaveChanges();

            foreach(var f in Facultets)
            {
                ContextDB.tableFacultet.Add(new tableFacultet { Name = f.ToString() });
            }
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 10;

            foreach (var p in Profiles)
            {
                ContextDB.tableProfile.Add(new tableProfile { Name = p.ToString() });
            }
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 20;
            foreach (var g in Grupps)
            {
                string facultName="";
                for (int i = 0; i < c1FlexGridItogTable.Rows.Count; i++)
                {
                    if (c1FlexGridItogTable[i, 1].ToString() == g.ToString())
                    {
                        facultName = c1FlexGridItogTable[i, 0].ToString();
                        break;
                    }
                }

                string profileName = "";
                for (int i = 0; i < c1FlexGridItogTable.Rows.Count; i++)
                {
                    if (c1FlexGridItogTable[i, 1].ToString() == g.ToString())
                    {
                        profileName = c1FlexGridItogTable[i, 9].ToString();
                        break;
                    }
                }

                int FacultID =
                    (from f in ContextDB.tableFacultet
                     where f.Name == facultName
                     select f.ID).First();

                int ProfileID =
                    (from f in ContextDB.tableProfile
                     where f.Name == profileName
                     select f.ID).First();

                ContextDB.tableGrupp.Add(new tableGrupp { Name = g.ToString(), IDFacultet = FacultID, IDProfile = ProfileID });
            }
            progressBar1.Value = 30;
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 40;
            foreach (var d in Disciplins)
            {
                ContextDB.tableDisciplin.Add(new tableDisciplin {Name = d.ToString()});
            }
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 50;
            foreach (var s in Students)
            {
                string gruppName = "";
                for (int i = 0; i < c1FlexGridItogTable.Rows.Count; i++)
                {
                    if (c1FlexGridItogTable[i, 8].ToString() == s.Value.ToString())
                    {
                        gruppName = c1FlexGridItogTable[i, 1].ToString();
                        break;
                    }
                }
                int gruppID =
                    (from g in ContextDB.tableGrupp
                     where g.Name == gruppName
                     select g.ID).First();
                string nomerZachetki = s.Key;
                ContextDB.tableStudents.Add(new tableStudents { Name = s.Value, NomerZachetki = nomerZachetki, ID_Gruppi = gruppID,DopuskKSessii=1});
            }
            ContextDB.SaveChanges();
            progressBar1.Value = 60;
            foreach (var p in Prepods)
            {
                ContextDB.tablePrepods.Add(new tablePrepods { Name = p.ToString() });
            }

            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 70;
            //принадлежность дисциплин
            var pdis =
                from pd in ContextDB.tableDisciplin
                select pd;
            progressBar1.Value = 0;
            progressBar1.Maximum = pdis.Count();
            foreach (var pd in pdis)
            {
                foreach (var grup in Grupps)
                {
                    for (int i = 0; i < c1FlexGridItogTable.Rows.Count; i++)
                    {
                        if (c1FlexGridItogTable[i, 2].ToString() == pd.Name && grup == c1FlexGridItogTable[i, 1].ToString())
                        {

                                ModelGruppi gruppaID =
                                    (from g in ContextDB.tableGrupp
                                     where g.Name == grup
                                     select new ModelGruppi { GruppaID = g.ID, FacultetID = g.IDFacultet, GruppaName = g.Name }).First();

                                string gr2 = c1FlexGridItogTable[i, 6].ToString();

                                int idPrepod =
                                    (from p in ContextDB.tablePrepods
                                     where p.Name == gr2
                                     select p.ID).First();

                                int otchetnost = int.Parse(c1FlexGridItogTable[i, 3].ToString());
                                int KR_KP = int.Parse(c1FlexGridItogTable[i, 4].ToString());
                                int chasiDisciplini = int.Parse(c1FlexGridItogTable[i, 5].ToString());

                                ContextDB.tablePrinadlegnistDisciplin.Add(new tablePrinadlegnistDisciplin { ID_Facultet = gruppaID.FacultetID, ID_Gruppi = gruppaID.GruppaID, ID_Disciplini = pd.ID, ID_Prepoda = idPrepod, Otchetnost = otchetnost, KR_KP = KR_KP, ChasiDisciplini = chasiDisciplini });

                                break;
                            
                        }
                    }
                }
                progressBar1.Value++;
            }
            progressBar1.Maximum = 100;
            progressBar1.Value = 80;
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 90;
            //баллы
            var balli =
                from s in ContextDB.tableStudents
                from pd in ContextDB.tablePrinadlegnistDisciplin
                where s.ID_Gruppi == pd.ID_Gruppi
                select new modelBalli {ID_Gruppi=s.ID_Gruppi,ID_Disciplini=pd.ID_Disciplini,ID_prepoda=pd.ID_Prepoda,ID_Studenta=s.ID};

            progressBar1.Maximum = balli.Count();
            progressBar1.Value = 0;
            foreach (var tb in balli)
            {
                ContextDB.tableBalli.Add(new tableBalli { ID_Gruppi=tb.ID_Gruppi,ID_Disciplini=tb.ID_Disciplini,ID_prepoda=tb.ID_prepoda,ID_Studenta=tb.ID_Studenta,Pos1=0,Tek1=0,Rub1=0,Pos2=0,Tek2=0,Rub2=0,Samost=0,Dosdacha=0,Premial=0,Itog=0});
                progressBar1.Value++;
            }
            progressBar1.Value = 90;
            progressBar1.Maximum = 100;
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            progressBar1.Value = 95;
            // учетки преподов
            var prepods =
                from p in ContextDB.tablePrepods
                select p;

            Translit trans = new Translit();
            foreach (var p in prepods)
            {
                string Login = trans.TranslitFileName(p.Name);
                string Parol = trans.GenPassword(p.Name).Substring(trans.GenPassword(p.Name).Length / 2);
                if (Login.Length > 16)
                {
                    Login = Login.Substring(0, 16);
                }
                if (Parol.Length > 8)
                {
                    Parol = Parol.Substring(0, 8);
                }
                int Rol = 2;
                ContextDB.teachersAccounts.Add(new teachersAccounts { Role_ID = Rol, ID_Prepoda = p.ID, Login = Login, Password = Parol });
            }
            try
            {
                ContextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            progressBar1.Value = 100;

            MessageBox.Show("Занесение данных успешно закончено!");

        }

        private void удалитьВсеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbBRSEntities contextDB = new dbBRSEntities();

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            //удаление студентов
            var balli =
                from s in contextDB.tableBalli
                select s;
            foreach (var s in balli)
            {
                contextDB.tableBalli.Remove(s);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 10;
            var pos =
                from p in contextDB.tablePoseshenie
                select p;
            foreach (var p in contextDB.tablePoseshenie)
            {
                contextDB.tablePoseshenie.Remove(p);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 20;
            var zan =
                from z in contextDB.tableZanyatiy
                select z;
            foreach (var z in contextDB.tableZanyatiy)
            {
                contextDB.tableZanyatiy.Remove(z);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 30;
            //удаление студентов
            var students =
                from s in contextDB.tableStudents
                select s;
            foreach (var s in students)
            {
                contextDB.tableStudents.Remove(s);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 40;

            //
            var pd =
                from p in contextDB.tablePrinadlegnistDisciplin
                select p;

            foreach (var p in pd)
            {
                contextDB.tablePrinadlegnistDisciplin.Remove(p);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 50;
            //удаление групп
            var grupps =
                from g in contextDB.tableGrupp
                select g;

            foreach (var g in grupps)
            {
                contextDB.tableGrupp.Remove(g);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 60;

            //удаление профилей
            var prof =
                from f in contextDB.tableProfile
                select f;

            foreach (var f in prof)
            {
                contextDB.tableProfile.Remove(f);
            }
            contextDB.SaveChanges();
            //-----
            progressBar1.Value = 70;
            //-------
            var admins =
                from f in contextDB.tableAdmins
                select f;

            foreach (var f in admins)
            {
                contextDB.tableAdmins.Remove(f);
            }
            contextDB.SaveChanges();
            //
            //------


            progressBar1.Value = 80;
            //удаление
            var fac =
                from f in contextDB.tableFacultet
                select f;

            foreach (var f in fac)
            {
                contextDB.tableFacultet.Remove(f);
            }
            contextDB.SaveChanges();
            //

            progressBar1.Value = 90;
            //удаление

            var techac =
                from t in contextDB.teachersAccounts
                select t;

            foreach (var t in techac)
            {
                contextDB.teachersAccounts.Remove(t);
            }
            contextDB.SaveChanges();

            progressBar1.Value = 95;
            var prep =
                from p in contextDB.tablePrepods
                select p;
            foreach (var p in prep)
            {
                contextDB.tablePrepods.Remove(p);
            }
            contextDB.SaveChanges();

            progressBar1.Value = 98;
            //удаление
            var dis =
                from d in contextDB.tableDisciplin
                select d;

            foreach (var d in dis)
            {
                contextDB.tableDisciplin.Remove(d);
            }
            contextDB.SaveChanges();
            progressBar1.Value = 100;
            progressBar1.Value = 0;
        }

        private void инфаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "Список дисциплин нужно брать который сформировала данная программа! Первая строка в списке не учтивается. Это заголовки\n\nСписок студентов должен быть в следующей форме. \n1)Группа\n2)Номер зачетки\n3)Студент\n4)Факультет\n5)Профиль";

            MessageBox.Show(s);
        }
    }
}
