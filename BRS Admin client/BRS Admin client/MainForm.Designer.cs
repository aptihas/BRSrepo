namespace BRS_Admin_client
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.perechenDisciplin = new System.Windows.Forms.PictureBox();
            this.perechenDlyaBRS = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.perechenDisciplin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perechenDlyaBRS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Перечень дисциплин\r\n        по группам";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Итоговая таблица\r\n         данных";
            // 
            // perechenDisciplin
            // 
            this.perechenDisciplin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.perechenDisciplin.Image = ((System.Drawing.Image)(resources.GetObject("perechenDisciplin.Image")));
            this.perechenDisciplin.Location = new System.Drawing.Point(24, 53);
            this.perechenDisciplin.Name = "perechenDisciplin";
            this.perechenDisciplin.Size = new System.Drawing.Size(110, 110);
            this.perechenDisciplin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.perechenDisciplin.TabIndex = 8;
            this.perechenDisciplin.TabStop = false;
            this.perechenDisciplin.Click += new System.EventHandler(this.perechenDisciplin_Click);
            // 
            // perechenDlyaBRS
            // 
            this.perechenDlyaBRS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.perechenDlyaBRS.Image = ((System.Drawing.Image)(resources.GetObject("perechenDlyaBRS.Image")));
            this.perechenDlyaBRS.Location = new System.Drawing.Point(159, 53);
            this.perechenDlyaBRS.Name = "perechenDlyaBRS";
            this.perechenDlyaBRS.Size = new System.Drawing.Size(110, 110);
            this.perechenDlyaBRS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.perechenDlyaBRS.TabIndex = 7;
            this.perechenDlyaBRS.TabStop = false;
            this.perechenDlyaBRS.Click += new System.EventHandler(this.perechenDlyaBRS_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.функцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = " Файл";
            // 
            // функцииToolStripMenuItem
            // 
            this.функцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem,
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem});
            this.функцииToolStripMenuItem.Name = "функцииToolStripMenuItem";
            this.функцииToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.функцииToolStripMenuItem.Text = "Функции";
            // 
            // сформироватьПереченьДисциплинДляГруппToolStripMenuItem
            // 
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem.Name = "сформироватьПереченьДисциплинДляГруппToolStripMenuItem";
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem.Text = "Сформировать перечень дисциплин для групп";
            this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem.Click += new System.EventHandler(this.сформироватьПереченьДисциплинДляГруппToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // сформироватьИтоговуюТаблицуДанныхToolStripMenuItem
            // 
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem.Name = "сформироватьИтоговуюТаблицуДанныхToolStripMenuItem";
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem.Text = "Сформировать итоговую таблицу данных";
            this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem.Click += new System.EventHandler(this.сформироватьИтоговуюТаблицуДанныхToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 211);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.perechenDisciplin);
            this.Controls.Add(this.perechenDlyaBRS);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BRS Admin client";
            ((System.ComponentModel.ISupportInitialize)(this.perechenDisciplin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perechenDlyaBRS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox perechenDisciplin;
        private System.Windows.Forms.PictureBox perechenDlyaBRS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem функцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьПереченьДисциплинДляГруппToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьИтоговуюТаблицуДанныхToolStripMenuItem;
    }
}

