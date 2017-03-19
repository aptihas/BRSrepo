namespace BRS_Admin_client
{
    partial class CreateItogTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.c1FlexGridStudents = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1FlexGridDisciplins = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1FlexGridItogTable = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСписокДисциплинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьИтоговуюТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.занестиВБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.инфаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisciplins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridItogTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1FlexGridStudents
            // 
            this.c1FlexGridStudents.ColumnInfo = "0,0,0,0,0,95,Columns:";
            this.c1FlexGridStudents.Location = new System.Drawing.Point(602, 178);
            this.c1FlexGridStudents.Name = "c1FlexGridStudents";
            this.c1FlexGridStudents.Rows.Count = 0;
            this.c1FlexGridStudents.Rows.DefaultSize = 19;
            this.c1FlexGridStudents.Rows.Fixed = 0;
            this.c1FlexGridStudents.TabIndex = 0;
            this.c1FlexGridStudents.Visible = false;
            // 
            // c1FlexGridDisciplins
            // 
            this.c1FlexGridDisciplins.ColumnInfo = "0,0,0,0,0,95,Columns:";
            this.c1FlexGridDisciplins.Location = new System.Drawing.Point(46, 178);
            this.c1FlexGridDisciplins.Name = "c1FlexGridDisciplins";
            this.c1FlexGridDisciplins.Rows.Count = 0;
            this.c1FlexGridDisciplins.Rows.DefaultSize = 19;
            this.c1FlexGridDisciplins.Rows.Fixed = 0;
            this.c1FlexGridDisciplins.TabIndex = 1;
            this.c1FlexGridDisciplins.Visible = false;
            // 
            // c1FlexGridItogTable
            // 
            this.c1FlexGridItogTable.ColumnInfo = "10,0,0,0,0,95,Columns:";
            this.c1FlexGridItogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridItogTable.Location = new System.Drawing.Point(0, 24);
            this.c1FlexGridItogTable.Name = "c1FlexGridItogTable";
            this.c1FlexGridItogTable.Rows.Count = 0;
            this.c1FlexGridItogTable.Rows.DefaultSize = 19;
            this.c1FlexGridItogTable.Rows.Fixed = 0;
            this.c1FlexGridItogTable.Size = new System.Drawing.Size(885, 398);
            this.c1FlexGridItogTable.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.функцииToolStripMenuItem,
            this.инфаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // функцииToolStripMenuItem
            // 
            this.функцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem,
            this.загрузитьСписокДисциплинToolStripMenuItem,
            this.сформироватьИтоговуюТаблицуToolStripMenuItem,
            this.занестиВБДToolStripMenuItem,
            this.удалитьВсеЗаписиToolStripMenuItem});
            this.функцииToolStripMenuItem.Name = "функцииToolStripMenuItem";
            this.функцииToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.функцииToolStripMenuItem.Text = "Функции";
            // 
            // открытьЗагрузитьСписокСтудентовToolStripMenuItem
            // 
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem.Name = "открытьЗагрузитьСписокСтудентовToolStripMenuItem";
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem.Text = "Загрузить список студентов";
            this.открытьЗагрузитьСписокСтудентовToolStripMenuItem.Click += new System.EventHandler(this.открытьЗагрузитьСписокСтудентовToolStripMenuItem_Click);
            // 
            // загрузитьСписокДисциплинToolStripMenuItem
            // 
            this.загрузитьСписокДисциплинToolStripMenuItem.Enabled = false;
            this.загрузитьСписокДисциплинToolStripMenuItem.Name = "загрузитьСписокДисциплинToolStripMenuItem";
            this.загрузитьСписокДисциплинToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.загрузитьСписокДисциплинToolStripMenuItem.Text = "Загрузить список дисциплин";
            this.загрузитьСписокДисциплинToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСписокДисциплинToolStripMenuItem_Click);
            // 
            // сформироватьИтоговуюТаблицуToolStripMenuItem
            // 
            this.сформироватьИтоговуюТаблицуToolStripMenuItem.Enabled = false;
            this.сформироватьИтоговуюТаблицуToolStripMenuItem.Name = "сформироватьИтоговуюТаблицуToolStripMenuItem";
            this.сформироватьИтоговуюТаблицуToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.сформироватьИтоговуюТаблицуToolStripMenuItem.Text = "Сформировать итоговую таблицу";
            this.сформироватьИтоговуюТаблицуToolStripMenuItem.Click += new System.EventHandler(this.сформироватьИтоговуюТаблицуToolStripMenuItem_Click);
            // 
            // занестиВБДToolStripMenuItem
            // 
            this.занестиВБДToolStripMenuItem.Name = "занестиВБДToolStripMenuItem";
            this.занестиВБДToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.занестиВБДToolStripMenuItem.Text = "Занести в БД";
            this.занестиВБДToolStripMenuItem.Click += new System.EventHandler(this.занестиВБДToolStripMenuItem_Click);
            // 
            // удалитьВсеЗаписиToolStripMenuItem
            // 
            this.удалитьВсеЗаписиToolStripMenuItem.Name = "удалитьВсеЗаписиToolStripMenuItem";
            this.удалитьВсеЗаписиToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.удалитьВсеЗаписиToolStripMenuItem.Text = "Удалить все записи";
            this.удалитьВсеЗаписиToolStripMenuItem.Click += new System.EventHandler(this.удалитьВсеЗаписиToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(222, 164);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(446, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // инфаToolStripMenuItem
            // 
            this.инфаToolStripMenuItem.Name = "инфаToolStripMenuItem";
            this.инфаToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.инфаToolStripMenuItem.Text = "Инфа";
            this.инфаToolStripMenuItem.Click += new System.EventHandler(this.инфаToolStripMenuItem_Click);
            // 
            // CreateItogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 422);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.c1FlexGridStudents);
            this.Controls.Add(this.c1FlexGridDisciplins);
            this.Controls.Add(this.c1FlexGridItogTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CreateItogTable";
            this.Text = "CreateItogTable";
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisciplins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridItogTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridStudents;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDisciplins;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridItogTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьЗагрузитьСписокСтудентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСписокДисциплинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьИтоговуюТаблицуToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem занестиВБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеЗаписиToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem инфаToolStripMenuItem;
    }
}