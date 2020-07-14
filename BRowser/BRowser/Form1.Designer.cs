namespace BRowser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.новаяВкладкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.nw = new System.Windows.Forms.WebBrowser();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ночнаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripDropDownButton1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1023, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 24);
            this.toolStripButton1.Text = "Назад";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 24);
            this.toolStripButton2.Text = "Вперед";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(82, 24);
            this.toolStripButton3.Text = "Обновить";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(54, 24);
            this.toolStripButton5.Text = "Home";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяВкладкаToolStripMenuItem,
            this.закрытьВкладкуToolStripMenuItem,
            this.историяToolStripMenuItem,
            this.загрузкиToolStripMenuItem,
            this.ночнаяТемаToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 24);
            this.toolStripDropDownButton1.Text = "Menu";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // новаяВкладкаToolStripMenuItem
            // 
            this.новаяВкладкаToolStripMenuItem.Name = "новаяВкладкаToolStripMenuItem";
            this.новаяВкладкаToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.новаяВкладкаToolStripMenuItem.Text = "Новая вкладка";
            this.новаяВкладкаToolStripMenuItem.Click += new System.EventHandler(this.новаяВкладкаToolStripMenuItem_Click);
            // 
            // закрытьВкладкуToolStripMenuItem
            // 
            this.закрытьВкладкуToolStripMenuItem.Name = "закрытьВкладкуToolStripMenuItem";
            this.закрытьВкладкуToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.закрытьВкладкуToolStripMenuItem.Text = "Закрыть вкладку";
            this.закрытьВкладкуToolStripMenuItem.Click += new System.EventHandler(this.закрытьВкладкуToolStripMenuItem_Click);
            // 
            // историяToolStripMenuItem
            // 
            this.историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            this.историяToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.историяToolStripMenuItem.Text = "История";
            this.историяToolStripMenuItem.Click += new System.EventHandler(this.историяToolStripMenuItem_Click);
            // 
            // загрузкиToolStripMenuItem
            // 
            this.загрузкиToolStripMenuItem.Name = "загрузкиToolStripMenuItem";
            this.загрузкиToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.загрузкиToolStripMenuItem.Text = "Загрузки";
            this.загрузкиToolStripMenuItem.Click += new System.EventHandler(this.загрузкиToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(400, 27);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.Transparent;
            this.TabPage1.Controls.Add(this.nw);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1015, 469);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Новая вкладка 1";
            // 
            // nw
            // 
            this.nw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nw.Location = new System.Drawing.Point(3, 3);
            this.nw.MinimumSize = new System.Drawing.Size(20, 20);
            this.nw.Name = "nw";
            this.nw.Size = new System.Drawing.Size(1009, 463);
            this.nw.TabIndex = 0;
            this.nw.Url = new System.Uri("https://google.com", System.UriKind.Absolute);
            this.nw.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.nw.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.nw_Navigated);
            this.nw.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.nw_Navigating);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 27);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1023, 498);
            this.TabControl1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ночнаяТемаToolStripMenuItem
            // 
            this.ночнаяТемаToolStripMenuItem.Checked = true;
            this.ночнаяТемаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ночнаяТемаToolStripMenuItem.Name = "ночнаяТемаToolStripMenuItem";
            this.ночнаяТемаToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ночнаяТемаToolStripMenuItem.Text = "Ночная тема";
            this.ночнаяТемаToolStripMenuItem.Click += new System.EventHandler(this.ночнаяТемаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 525);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.WebBrowser nw;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.ToolStripMenuItem новаяВкладкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ночнаяТемаToolStripMenuItem;
    }
}

