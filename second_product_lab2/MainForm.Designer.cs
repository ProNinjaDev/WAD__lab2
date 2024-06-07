namespace second_product_lab2
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DrawCurveBtn = new System.Windows.Forms.Button();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.BackChangeBtn = new System.Windows.Forms.Button();
            this.ColorGraphicBtn = new System.Windows.Forms.Button();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.RandomFuncBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveCurveBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveCurveBtn);
            this.groupBox1.Controls.Add(this.DrawCurveBtn);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ScaleLabel);
            this.groupBox1.Controls.Add(this.BackChangeBtn);
            this.groupBox1.Controls.Add(this.ColorGraphicBtn);
            this.groupBox1.Controls.Add(this.SaveFileBtn);
            this.groupBox1.Controls.Add(this.RandomFuncBtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(600, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Функционал";
            // 
            // DrawCurveBtn
            // 
            this.DrawCurveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DrawCurveBtn.Location = new System.Drawing.Point(26, 55);
            this.DrawCurveBtn.Name = "DrawCurveBtn";
            this.DrawCurveBtn.Size = new System.Drawing.Size(144, 46);
            this.DrawCurveBtn.TabIndex = 6;
            this.DrawCurveBtn.Text = "Аппроксимация";
            this.DrawCurveBtn.UseVisualStyleBackColor = false;
            this.DrawCurveBtn.Click += new System.EventHandler(this.DrawCurveBtn_Click);
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(85, 402);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(40, 16);
            this.ScaleLabel.TabIndex = 4;
            this.ScaleLabel.Text = "100%";
            this.ScaleLabel.Visible = false;
            // 
            // BackChangeBtn
            // 
            this.BackChangeBtn.Location = new System.Drawing.Point(44, 303);
            this.BackChangeBtn.Name = "BackChangeBtn";
            this.BackChangeBtn.Size = new System.Drawing.Size(112, 46);
            this.BackChangeBtn.TabIndex = 3;
            this.BackChangeBtn.Text = "Стиль фона";
            this.BackChangeBtn.UseVisualStyleBackColor = true;
            this.BackChangeBtn.Click += new System.EventHandler(this.BackChangeBtn_Click);
            // 
            // ColorGraphicBtn
            // 
            this.ColorGraphicBtn.Location = new System.Drawing.Point(44, 241);
            this.ColorGraphicBtn.Name = "ColorGraphicBtn";
            this.ColorGraphicBtn.Size = new System.Drawing.Size(112, 46);
            this.ColorGraphicBtn.TabIndex = 2;
            this.ColorGraphicBtn.Text = "Выбор цвета";
            this.ColorGraphicBtn.UseVisualStyleBackColor = true;
            this.ColorGraphicBtn.Click += new System.EventHandler(this.ColorGraphicBtn_Click);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Location = new System.Drawing.Point(44, 179);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(112, 46);
            this.SaveFileBtn.TabIndex = 1;
            this.SaveFileBtn.Text = "Сохранить";
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // RandomFuncBtn
            // 
            this.RandomFuncBtn.Location = new System.Drawing.Point(44, 117);
            this.RandomFuncBtn.Name = "RandomFuncBtn";
            this.RandomFuncBtn.Size = new System.Drawing.Size(112, 46);
            this.RandomFuncBtn.TabIndex = 0;
            this.RandomFuncBtn.Text = "Случайная функция";
            this.RandomFuncBtn.UseVisualStyleBackColor = true;
            this.RandomFuncBtn.Click += new System.EventHandler(this.RandomFuncBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 450);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SaveCurveBtn
            // 
            this.SaveCurveBtn.BackgroundImage = global::second_product_lab2.Properties.Resources.Save_Button_PNG_Transparent_Images;
            this.SaveCurveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveCurveBtn.Location = new System.Drawing.Point(164, 414);
            this.SaveCurveBtn.Name = "SaveCurveBtn";
            this.SaveCurveBtn.Size = new System.Drawing.Size(33, 30);
            this.SaveCurveBtn.TabIndex = 7;
            this.SaveCurveBtn.UseVisualStyleBackColor = true;
            this.SaveCurveBtn.Click += new System.EventHandler(this.SaveCurveBtn_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::second_product_lab2.Properties.Resources.Antu_view_refresh_svg;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(164, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Приветствие";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RandomFuncBtn;
        private System.Windows.Forms.Button ColorGraphicBtn;
        private System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.Button BackChangeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ScaleLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DrawCurveBtn;
        private System.Windows.Forms.Button SaveCurveBtn;
    }
}

