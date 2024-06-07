using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace second_product_lab2
{
    public partial class BackgroundThemeForm : Form
    {

        //private int gradientIndex = 0;
        public int gridIndex = 0;
        public int themeIndex = 0;
        public List<Color> colors = new List<Color>();

        public BackgroundThemeForm()
        {
            InitializeComponent();



            colors.Add(Color.Empty);
            colors.Add(Color.Empty);

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            this.FormClosing += BackgroundThemeForm_FormClosing;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(RomanticBtn, "Романтическая тема");
            toolTip.SetToolTip(TiredBtn, "Тема \"Дописал вторую лабу\"");
            toolTip.SetToolTip(NewYearBtn, "Новогодняя тема");
            toolTip.SetToolTip(MeBtn, "Тема \"Сдал вторую лабу\"");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SquareGridBtn_Click(object sender, EventArgs e)
        {
            gridIndex = 1;
        }

        private void CircularGridBtn_Click(object sender, EventArgs e)
        {
            gridIndex = 2;
        }

        private void BackgroundThemeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if()
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GradientBtn_Click(object sender, EventArgs e)
        {
            // Создаем диалог выбора цветов
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result;

            // Первый цвет
            result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color startColor = colorDialog.Color;

                // Второй цвет
                result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Color endColor = colorDialog.Color;

                    // Подгоняю область закрашивания градиентом мою самую любимую кнопочку в этом проекте
                    LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        new Rectangle(373, 233, 137, 101),
                        startColor,
                        endColor,
                        LinearGradientMode.Vertical);

                    // Устанавливаю цвет фона кнопки в начальный цвет градиента
                    GradientBtn.BackColor = startColor;

                    colors[0] = startColor;
                    colors[1] = endColor;

                    // Устанавливаю градиент как фон кнопки
                    GradientBtn.BackgroundImage = new Bitmap(GradientBtn.Width, GradientBtn.Height);
                    using (Graphics g = Graphics.FromImage(GradientBtn.BackgroundImage))
                    {
                        g.FillRectangle(gradientBrush, new Rectangle(0, 0, GradientBtn.Width, GradientBtn.Height));
                    }

                    // Освобождаю ресурсы
                    gradientBrush.Dispose();
                }
            }
        }

        private void AcceptBackBtn_Click(object sender, EventArgs e)
        {
            if (!GridCheck.Checked)
            {
                gridIndex = 0;
            }

            if (!GradientCheck.Checked)
            {
                colors[0] = Color.Empty;
                colors[1] = Color.Empty;
            }

            if(!ThemeCheck.Checked)
            {
                themeIndex = 0;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NewYearBtn_Click(object sender, EventArgs e)
        {
            themeIndex = 3;
        }

        private void MeBtn_Click(object sender, EventArgs e)
        {
            themeIndex = 4;
        }

        private void RomanticBtn_Click(object sender, EventArgs e)
        {
            themeIndex = 1;
        }

        private void TiredBtn_Click(object sender, EventArgs e)
        {
            themeIndex = 2;
        }

        private void GridCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SquareGridBtn.Visible)
            {
                SquareGridBtn.Visible = false;
                CircularGridBtn.Visible = false;
            }
            else
            {
                SquareGridBtn.Visible = true;
                CircularGridBtn.Visible = true;
            }
        }

        private void BackgroundThemeForm_Load(object sender, EventArgs e)
        {
            SquareGridBtn.Visible = false;
            CircularGridBtn.Visible = false;

            GradientBtn.Visible = false;

            RomanticBtn.Visible = false;
            TiredBtn.Visible = false;
            NewYearBtn.Visible = false;
            MeBtn.Visible = false;
        }

        private void GradientCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (GradientBtn.Visible)
            {
                GradientBtn.Visible = false;
            }
            else {
                GradientBtn.Visible = true;
            }
        }

        private void ThemeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (RomanticBtn.Visible)
            {
                RomanticBtn.Visible = false;
                TiredBtn.Visible = false;
                NewYearBtn.Visible = false;
                MeBtn.Visible = false;
            }
            else
            {
                RomanticBtn.Visible = true;
                TiredBtn.Visible = true;
                NewYearBtn.Visible = true;
                MeBtn.Visible = true;
            }
        }
    }
}
