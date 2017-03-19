using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS_Admin_client
{
    public partial class SubjectListForm : Form
    {
        public SubjectListForm()
        {
            InitializeComponent();
        }

        private void сохранитьПереченьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                c1FlexGridPerechen.SaveExcel(saveFileDialog.FileName);
                //сохранение в книгу
                MessageBox.Show("Файл сохранён!!!", "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void сформироватьПереченьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    c1FlexGridPerechen[0, 0] = "Группа";
                    c1FlexGridPerechen[0, 1] = "№";
                    c1FlexGridPerechen[0, 2] = "Дисциплина";
                    c1FlexGridPerechen[0, 3] = "Часы";
                    c1FlexGridPerechen[0, 4] = "Отчетность";
                    c1FlexGridPerechen[0, 5] = "КР_КП";
                    c1FlexGridPerechen[0, 6] = "Преподаватель";

                    string[] Gruppi_s_Nagruzki = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    string prepod = "", disciplina = "", gruppa = "", chasi = "";
                    int chislo = 1, nomer = 1;

                    //если в файлах есть столбец слева то 1 иначе 0
                    int stolbec = 1;
                int stolc_lek = 0, stolc_lab = 0, stolc_prak = 0;
                    for (int i = 0; i < Gruppi_s_Nagruzki.Length; i++)
                    {
                        c1FlexGridAutoOtkrite.LoadExcel(Gruppi_s_Nagruzki[i]);
                        nomer = 1;

                        for (int j = 11; j < c1FlexGridAutoOtkrite.Rows.Count; j++)
                        {
                            //MessageBox.Show(c1FlexGridAutoOtkrite[j, 2].ToString());
                            if (c1FlexGridAutoOtkrite[j, 0 + stolbec] != null && c1FlexGridAutoOtkrite[j, 0 + stolbec].ToString() != "" && c1FlexGridAutoOtkrite[j, 1 + stolbec] != null && c1FlexGridAutoOtkrite[j, 1 + stolbec].ToString().ToUpper().IndexOf("ИТОГО") == -1)
                            {
                                c1FlexGridPerechen.Rows.Add(1);

                                prepod = (string)c1FlexGridAutoOtkrite[j, 4 + stolbec];
                                //stolc_lek = c1FlexGridAutoOtkrite[j, 11]?.ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 11].ToString());
                                //stolc_lab = c1FlexGridAutoOtkrite[j, 11]?.ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 12].ToString());
                                //stolc_prak = c1FlexGridAutoOtkrite[j, 11]?.ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 13].ToString());

                                stolc_lek = c1FlexGridAutoOtkrite[j, 11].ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 11].ToString());
                                stolc_lab = c1FlexGridAutoOtkrite[j, 11].ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 12].ToString());
                                stolc_prak = c1FlexGridAutoOtkrite[j, 11].ToString() == null ? 0 : int.Parse(c1FlexGridAutoOtkrite[j, 13].ToString());

                                chasi = (stolc_lek + stolc_lab + stolc_prak).ToString();
                                //Когда название планаа совпадает с названием группы
                                //gruppa = Gruppi_s_Nagruzki[i].Substring(Gruppi_s_Nagruzki[i].LastIndexOf("\\") + 1, Gruppi_s_Nagruzki[i].LastIndexOf(".") - Gruppi_s_Nagruzki[i].LastIndexOf("\\") - 1);

                            //когда название плана не совпадает с названием группы
                            gruppa = c1FlexGridAutoOtkrite[4, 0 + stolbec].ToString().Substring(16).Replace(".","");

                                disciplina = (string)c1FlexGridAutoOtkrite[j, 1 + stolbec];

                                c1FlexGridPerechen[chislo, 0] = gruppa;
                                c1FlexGridPerechen[chislo, 1] = nomer;
                                c1FlexGridPerechen[chislo, 2] = disciplina;
                                c1FlexGridPerechen[chislo, 3] = chasi;

                                if (c1FlexGridAutoOtkrite[j, 14 + stolbec].ToString().Substring(0, 1) != "0")
                                {
                                    c1FlexGridPerechen[chislo, 4] = "1";//экзамен
                                }
                                else if (c1FlexGridAutoOtkrite[j, 15 + stolbec].ToString().Substring(0, 1) != "0")
                                {
                                    c1FlexGridPerechen[chislo, 4] = "2";//дифзачет
                                }
                                else if (c1FlexGridAutoOtkrite[j, 16 + stolbec].ToString().Substring(0, 1) != "0")
                                {
                                    c1FlexGridPerechen[chislo, 4] = "3";//зачет
                                }
                                else
                                {
                                    c1FlexGridPerechen[chislo, 4] = "0";// если нету вида отчетности
                                }

                                if (c1FlexGridAutoOtkrite[j, 17 + stolbec].ToString().Substring(0, 1) != "0")
                                {
                                    c1FlexGridPerechen[chislo, 5] = "2";//КП
                                }
                                else if (c1FlexGridAutoOtkrite[j, 18 + stolbec].ToString().Substring(0, 1) != "0")
                                {
                                    c1FlexGridPerechen[chislo, 5] = "1";//КР
                                }
                                else
                                {
                                    c1FlexGridPerechen[chislo, 5] = "0";// если нету вида отчетности
                                }

                                c1FlexGridPerechen[chislo, 6] = prepod;
                                chislo++;
                                nomer++;
                            }
                        }
                    }
                    сохранитьПереченьToolStripMenuItem.Enabled = true;
                    for (int i = 1; i < c1FlexGridPerechen.Rows.Count; i++)
                    {
                        if (c1FlexGridPerechen[i, 6] ==null || c1FlexGridPerechen[i, 6].ToString() == "")
                        {
                            c1FlexGridPerechen[i, 6] = "Преподаватель неизвестен";
                        }
                    }
                }

            //}
            //catch
            //{
            //    MessageBox.Show("Возникла ошибка! Проверьте правильность исходных данных.");
            //}
        }
    }
}
