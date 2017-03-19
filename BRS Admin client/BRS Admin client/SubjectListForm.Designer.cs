namespace BRS_Admin_client
{
    partial class SubjectListForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПереченьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьПереченьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.c1FlexGridPerechen = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1FlexGridAutoOtkrite = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPerechen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridAutoOtkrite)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.функцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьПереченьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьПереченьToolStripMenuItem
            // 
            this.сохранитьПереченьToolStripMenuItem.Enabled = false;
            this.сохранитьПереченьToolStripMenuItem.Name = "сохранитьПереченьToolStripMenuItem";
            this.сохранитьПереченьToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.сохранитьПереченьToolStripMenuItem.Text = "Сохранить перечень";
            this.сохранитьПереченьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПереченьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // функцииToolStripMenuItem
            // 
            this.функцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьПереченьToolStripMenuItem});
            this.функцииToolStripMenuItem.Name = "функцииToolStripMenuItem";
            this.функцииToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.функцииToolStripMenuItem.Text = "Функции";
            // 
            // сформироватьПереченьToolStripMenuItem
            // 
            this.сформироватьПереченьToolStripMenuItem.Name = "сформироватьПереченьToolStripMenuItem";
            this.сформироватьПереченьToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.сформироватьПереченьToolStripMenuItem.Text = "Сформировать перечень из нагрузок групп";
            this.сформироватьПереченьToolStripMenuItem.Click += new System.EventHandler(this.сформироватьПереченьToolStripMenuItem_Click);
            // 
            // c1FlexGridPerechen
            // 
            this.c1FlexGridPerechen.ColumnInfo = "7,0,0,0,0,95,Columns:2{Width:300;}\t";
            this.c1FlexGridPerechen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridPerechen.Location = new System.Drawing.Point(0, 24);
            this.c1FlexGridPerechen.Name = "c1FlexGridPerechen";
            this.c1FlexGridPerechen.Rows.Count = 1;
            this.c1FlexGridPerechen.Rows.DefaultSize = 19;
            this.c1FlexGridPerechen.Rows.Fixed = 0;
            this.c1FlexGridPerechen.Size = new System.Drawing.Size(875, 384);
            this.c1FlexGridPerechen.TabIndex = 2;
            // 
            // c1FlexGridAutoOtkrite
            // 
            this.c1FlexGridAutoOtkrite.ColumnInfo = "0,0,0,0,0,95,Columns:";
            this.c1FlexGridAutoOtkrite.Location = new System.Drawing.Point(285, 202);
            this.c1FlexGridAutoOtkrite.Name = "c1FlexGridAutoOtkrite";
            this.c1FlexGridAutoOtkrite.Rows.Count = 0;
            this.c1FlexGridAutoOtkrite.Rows.DefaultSize = 19;
            this.c1FlexGridAutoOtkrite.Rows.Fixed = 0;
            this.c1FlexGridAutoOtkrite.Size = new System.Drawing.Size(240, 150);
            this.c1FlexGridAutoOtkrite.TabIndex = 3;
            this.c1FlexGridAutoOtkrite.Visible = false;
            // 
            // SubjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 408);
            this.Controls.Add(this.c1FlexGridAutoOtkrite);
            this.Controls.Add(this.c1FlexGridPerechen);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(891, 447);
            this.MinimumSize = new System.Drawing.Size(891, 447);
            this.Name = "SubjectListForm";
            this.Text = "SubjectListForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPerechen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridAutoOtkrite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПереченьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьПереченьToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPerechen;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridAutoOtkrite;
    }
}