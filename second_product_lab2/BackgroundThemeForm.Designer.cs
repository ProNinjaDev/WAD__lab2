namespace second_product_lab2
{
    partial class BackgroundThemeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.GridCheck = new System.Windows.Forms.CheckBox();
            this.GradientCheck = new System.Windows.Forms.CheckBox();
            this.AcceptBackBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.GradientBtn = new System.Windows.Forms.Button();
            this.ThemeCheck = new System.Windows.Forms.CheckBox();
            this.MeBtn = new System.Windows.Forms.Button();
            this.NewYearBtn = new System.Windows.Forms.Button();
            this.TiredBtn = new System.Windows.Forms.Button();
            this.RomanticBtn = new System.Windows.Forms.Button();
            this.CircularGridBtn = new System.Windows.Forms.Button();
            this.SquareGridBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TT Firs Neue DemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(328, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Настройка фона";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GridCheck
            // 
            this.GridCheck.AutoSize = true;
            this.GridCheck.Font = new System.Drawing.Font("TT Firs Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridCheck.Location = new System.Drawing.Point(152, 242);
            this.GridCheck.Margin = new System.Windows.Forms.Padding(4);
            this.GridCheck.Name = "GridCheck";
            this.GridCheck.Size = new System.Drawing.Size(94, 30);
            this.GridCheck.TabIndex = 1;
            this.GridCheck.Text = "Сетка";
            this.GridCheck.UseVisualStyleBackColor = true;
            this.GridCheck.CheckedChanged += new System.EventHandler(this.GridCheck_CheckedChanged);
            // 
            // GradientCheck
            // 
            this.GradientCheck.AutoSize = true;
            this.GradientCheck.Font = new System.Drawing.Font("TT Firs Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GradientCheck.Location = new System.Drawing.Point(497, 242);
            this.GradientCheck.Margin = new System.Windows.Forms.Padding(4);
            this.GradientCheck.Name = "GradientCheck";
            this.GradientCheck.Size = new System.Drawing.Size(125, 30);
            this.GradientCheck.TabIndex = 5;
            this.GradientCheck.Text = "Градиент";
            this.GradientCheck.UseVisualStyleBackColor = true;
            this.GradientCheck.CheckedChanged += new System.EventHandler(this.GradientCheck_CheckedChanged);
            // 
            // AcceptBackBtn
            // 
            this.AcceptBackBtn.Location = new System.Drawing.Point(357, 475);
            this.AcceptBackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AcceptBackBtn.Name = "AcceptBackBtn";
            this.AcceptBackBtn.Size = new System.Drawing.Size(131, 50);
            this.AcceptBackBtn.TabIndex = 6;
            this.AcceptBackBtn.Text = "Принять";
            this.AcceptBackBtn.UseVisualStyleBackColor = true;
            this.AcceptBackBtn.Click += new System.EventHandler(this.AcceptBackBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(533, 475);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(131, 50);
            this.CloseBtn.TabIndex = 7;
            this.CloseBtn.Text = "Отменить";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // GradientBtn
            // 
            this.GradientBtn.Location = new System.Drawing.Point(497, 287);
            this.GradientBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GradientBtn.Name = "GradientBtn";
            this.GradientBtn.Size = new System.Drawing.Size(183, 153);
            this.GradientBtn.TabIndex = 8;
            this.GradientBtn.UseVisualStyleBackColor = true;
            this.GradientBtn.Click += new System.EventHandler(this.GradientBtn_Click);
            // 
            // ThemeCheck
            // 
            this.ThemeCheck.AutoSize = true;
            this.ThemeCheck.Font = new System.Drawing.Font("TT Firs Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeCheck.Location = new System.Drawing.Point(751, 242);
            this.ThemeCheck.Margin = new System.Windows.Forms.Padding(4);
            this.ThemeCheck.Name = "ThemeCheck";
            this.ThemeCheck.Size = new System.Drawing.Size(127, 30);
            this.ThemeCheck.TabIndex = 9;
            this.ThemeCheck.Text = "Тематика";
            this.ThemeCheck.UseVisualStyleBackColor = true;
            this.ThemeCheck.CheckedChanged += new System.EventHandler(this.ThemeCheck_CheckedChanged);
            // 
            // MeBtn
            // 
            this.MeBtn.BackgroundImage = global::second_product_lab2.Properties.Resources.face_exhaling_1f62e_200d_1f4a8;
            this.MeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MeBtn.Location = new System.Drawing.Point(841, 363);
            this.MeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.MeBtn.Name = "MeBtn";
            this.MeBtn.Size = new System.Drawing.Size(83, 76);
            this.MeBtn.TabIndex = 13;
            this.MeBtn.UseVisualStyleBackColor = true;
            this.MeBtn.Click += new System.EventHandler(this.MeBtn_Click);
            // 
            // NewYearBtn
            // 
            this.NewYearBtn.BackgroundImage = global::second_product_lab2.Properties.Resources.snowman_without_snow_26c4;
            this.NewYearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewYearBtn.Location = new System.Drawing.Point(751, 363);
            this.NewYearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.NewYearBtn.Name = "NewYearBtn";
            this.NewYearBtn.Size = new System.Drawing.Size(83, 76);
            this.NewYearBtn.TabIndex = 12;
            this.NewYearBtn.UseVisualStyleBackColor = true;
            this.NewYearBtn.Click += new System.EventHandler(this.NewYearBtn_Click);
            // 
            // TiredBtn
            // 
            this.TiredBtn.BackgroundImage = global::second_product_lab2.Properties.Resources.hot_face_1f975;
            this.TiredBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TiredBtn.Location = new System.Drawing.Point(841, 287);
            this.TiredBtn.Margin = new System.Windows.Forms.Padding(4);
            this.TiredBtn.Name = "TiredBtn";
            this.TiredBtn.Size = new System.Drawing.Size(83, 76);
            this.TiredBtn.TabIndex = 11;
            this.TiredBtn.UseVisualStyleBackColor = true;
            this.TiredBtn.Click += new System.EventHandler(this.TiredBtn_Click);
            // 
            // RomanticBtn
            // 
            this.RomanticBtn.BackgroundImage = global::second_product_lab2.Properties.Resources.smiling_face_with_hearts_1f9701;
            this.RomanticBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RomanticBtn.Location = new System.Drawing.Point(751, 287);
            this.RomanticBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RomanticBtn.Name = "RomanticBtn";
            this.RomanticBtn.Size = new System.Drawing.Size(83, 76);
            this.RomanticBtn.TabIndex = 10;
            this.RomanticBtn.UseVisualStyleBackColor = true;
            this.RomanticBtn.Click += new System.EventHandler(this.RomanticBtn_Click);
            // 
            // CircularGridBtn
            // 
            this.CircularGridBtn.Image = global::second_product_lab2.Properties.Resources.Screenshot_89;
            this.CircularGridBtn.Location = new System.Drawing.Point(224, 287);
            this.CircularGridBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CircularGridBtn.Name = "CircularGridBtn";
            this.CircularGridBtn.Size = new System.Drawing.Size(183, 153);
            this.CircularGridBtn.TabIndex = 3;
            this.CircularGridBtn.UseVisualStyleBackColor = true;
            this.CircularGridBtn.Click += new System.EventHandler(this.CircularGridBtn_Click);
            // 
            // SquareGridBtn
            // 
            this.SquareGridBtn.Image = global::second_product_lab2.Properties.Resources.Screenshot_90;
            this.SquareGridBtn.Location = new System.Drawing.Point(16, 287);
            this.SquareGridBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SquareGridBtn.Name = "SquareGridBtn";
            this.SquareGridBtn.Size = new System.Drawing.Size(183, 153);
            this.SquareGridBtn.TabIndex = 2;
            this.SquareGridBtn.UseVisualStyleBackColor = true;
            this.SquareGridBtn.Click += new System.EventHandler(this.SquareGridBtn_Click);
            // 
            // BackgroundThemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 554);
            this.Controls.Add(this.MeBtn);
            this.Controls.Add(this.NewYearBtn);
            this.Controls.Add(this.TiredBtn);
            this.Controls.Add(this.RomanticBtn);
            this.Controls.Add(this.ThemeCheck);
            this.Controls.Add(this.GradientBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.AcceptBackBtn);
            this.Controls.Add(this.GradientCheck);
            this.Controls.Add(this.CircularGridBtn);
            this.Controls.Add(this.SquareGridBtn);
            this.Controls.Add(this.GridCheck);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BackgroundThemeForm";
            this.Text = "Стиль фона";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundThemeForm_FormClosing);
            this.Load += new System.EventHandler(this.BackgroundThemeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox GridCheck;
        private System.Windows.Forms.Button SquareGridBtn;
        private System.Windows.Forms.Button CircularGridBtn;
        private System.Windows.Forms.CheckBox GradientCheck;
        private System.Windows.Forms.Button AcceptBackBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button GradientBtn;
        private System.Windows.Forms.CheckBox ThemeCheck;
        private System.Windows.Forms.Button RomanticBtn;
        private System.Windows.Forms.Button TiredBtn;
        private System.Windows.Forms.Button NewYearBtn;
        private System.Windows.Forms.Button MeBtn;
    }
}