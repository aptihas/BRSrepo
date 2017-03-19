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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void сформироватьПереченьДисциплинДляГруппToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectListForm slf = new SubjectListForm();
            slf.ShowDialog();
        }

        private void perechenDisciplin_Click(object sender, EventArgs e)
        {
            сформироватьПереченьДисциплинДляГруппToolStripMenuItem.PerformClick();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сформироватьИтоговуюТаблицуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateItogTable cit = new CreateItogTable();
            cit.ShowDialog();
        }

        private void perechenDlyaBRS_Click(object sender, EventArgs e)
        {
            сформироватьИтоговуюТаблицуДанныхToolStripMenuItem.PerformClick();
        }
    }
}
