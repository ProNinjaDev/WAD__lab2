using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace second_product_lab2
{
    public partial class MainForm : Form
    {
        private int UnitSegment = 60;
        private double scale = 1;
        private double prevScale = 1;

        private bool moving = false;
        private bool circleMove = false;
        private Point previosLocationMouse;
        private Point offset = Point.Empty;
        private Point offsetRight = Point.Empty;

        private int selectedGrid = 0;
        private List<Color> selectedGradient = new List<Color>();
        private int selectedTheme = 0;

        private List<Smiley> smileys = new List<Smiley>();

        Pen customPen = new Pen(Color.Black, 2);

        IFunction randomFunction = new SquareFunc();

        // Поля для аппроксимации
        private List<PointF> points = new List<PointF>();
        private int prevPanelWidth = 450;
        private int prevPanelHeight = 366;

        private bool approximation = false;
        private List<PointF> constructedCurve = new List<PointF>();



        private List<PointF> adjustedCurve = new List<PointF>();


        public MainForm()
        {
            InitializeComponent();

            // Штука, отвечающая за двойную буферизацию
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panel1, new object[] { true });

            panel1.MouseDown += MainForm_MouseDown;
            panel1.MouseMove += MainForm_MouseMove;
            panel1.MouseUp += MainForm_MouseUp;
            panel1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);

            selectedGradient.Add(Color.Empty);
            selectedGradient.Add(Color.Empty);

            prevPanelWidth = panel1.Width;
            prevPanelHeight = panel1.Height;

            SaveCurveBtn.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (smileys.Count != 0)
            {
                ColorGraphicBtn.Enabled = false;
                SaveFileBtn.Enabled = false;
            }
            else
            {
                ColorGraphicBtn.Enabled = true;
                SaveFileBtn.Enabled = true;
            }

            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (selectedGradient[0] != Color.Empty && selectedGradient[1] != Color.Empty)
            {
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(panel1.Width, panel1.Height),
                    selectedGradient[0],
                    selectedGradient[1]);

                graph.FillRectangle(gradientBrush, panel1.ClientRectangle);

                gradientBrush.Dispose();
            }

            if (selectedGrid == 1)
            {
                DrawSquareGrid(graph, -panel1.Width / 2 - offset.X, panel1.Width / 2 - offset.X,
                    -panel1.Height / 2 - offset.Y, panel1.Height / 2 - offset.Y);
            }
            else if (selectedGrid == 2)
            {
                DrawCircularGrid(graph);
            }


            smileys.Clear();
            

            switch (selectedTheme)
            {
                case 1: // Романтическая тема

                    DrawPanelBorder(graph, Color.Red);
                    AddSmiley("smiling-face-with-hearts_1f970.png", 60, 60, 100, 100); // Эмодзи с кнопки
                    AddSmiley("red-heart_2764-fe0f.png", 25, 275, 30, 30); // Маленькое сердце
                    AddSmiley("red-heart_2764-fe0f.png", 70, 295, 55, 55); // Среднее сердце
                    AddSmiley("red-heart_2764-fe0f.png", 120, 250, 80, 80); // Огромныш
                    break;

                case 2: // Тема "Дописал вторую лабу"

                    DrawPanelBorder(graph, Color.DarkGray);
                    AddSmiley("hot-face_1f975.png", 60, 60, 100, 100); // Эмодзи с кнопки
                    AddSmiley("exploding-head_1f92f.png", 1325, 60, 100, 100);
                    break;

                case 3: // Новогодняя тема

                    DrawPanelBorder(graph, Color.LightSkyBlue);
                    AddSmiley("snowman-without-snow_26c4.png", 60, 60, 100, 100); // Эмодзи с кнопки
                    AddSmiley("wrapped-gift_1f381.png", 1350, 755, 50, 50); // Маленький гифт
                    AddSmiley("wrapped-gift_1f381.png", 1280, 745, 75, 75); // Гифт побольше
                    AddSmiley("christmas-tree_1f384.png", 55, 732, 100, 100); // Большая ёлка
                    break;

                case 4: // Тема "Сдал вторую лабу"

                    DrawPanelBorder(graph, Color.MediumSeaGreen);
                    AddSmiley("face-exhaling_1f62e-200d-1f4a8.png", 60, 60, 100, 100); // Эмодзи с кнопки
                    AddSmiley("bank_1f3e6.png", 60, 732, 100, 100); // Банк
                    AddSmiley("person-surfing-medium-light-skin-tone_1f3c4-1f3fc.png", 140, 740, 50, 50); // Буквально я 
                    AddSmiley("chart-increasing_1f4c8.png", 1335, 50, 75, 75); // График с ростом
                    AddSmiley("man-in-lotus-position-medium-light-skin-tone_1f9d8-1f3fc-200d-2642-fe0f (1).png", 1265, 50, 75, 75); // Буквально я следующим утром
                    AddSmiley("dollar-banknote_1f4b5.png", 1195, 50, 50, 50); // Кэш на моём счету
                    AddSmiley("person-in-suit-levitating_1f574-fe0f.png", 1355, 730, 100, 100); // Буквально я спустя пару минут
                    break;

                default:
                    break;
            }


            foreach (var smiley in smileys)
            {
                e.Graphics.DrawImage(smiley.Image, smiley.X - smiley.Length / 2, smiley.Y - smiley.Width / 2, smiley.Length, smiley.Width);
            }

            // Прорисовка графика                       
            DrawAxes(graph, customPen);
            DrawCircle(graph, customPen);

            if (randomFunction != null)
                DrawFunction(graph, randomFunction, -100 - offset.X / UnitSegment, 100 - offset.X / UnitSegment, customPen);
            

            // Отрисовка поставленных точек
            foreach (var point in points)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 4 + offset.X, point.Y - 4 + offset.Y, 8, 8);
            }

            // Рисую аппроксимированную кривую
            if (approximation)
            {
                adjustedCurve = GetApproximatedCurve(constructedCurve);
                if (adjustedCurve.Count != 0)
                    e.Graphics.DrawCurve(customPen, adjustedCurve.ToArray());
            }
        }

        // Отрисовка координатных осей
        private void DrawAxes(Graphics graph, Pen pen)
        {
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;

            

            // Рисуем бесконечные линии в разные стороны
            int infiniteLineLength = 1000 + Math.Abs(offset.X) + Math.Abs(offset.Y); // Длина бесконечных линий
            graph.DrawLine(pen, panelWidth / 2 + offset.X, panelHeight / 2 + offset.Y, panelWidth / 2 + offset.X, -infiniteLineLength + offset.Y); // Вверх
            graph.DrawLine(pen, panelWidth / 2 + offset.X, panelHeight / 2 + offset.Y, -infiniteLineLength + offset.X, panelHeight / 2 + offset.Y); // Влево
            graph.DrawLine(pen, panelWidth / 2 + offset.X, panelHeight / 2 + offset.Y, panelWidth + infiniteLineLength + offset.X, panelHeight / 2 + offset.Y); // Вправо
            graph.DrawLine(pen, panelWidth / 2 + offset.X, panelHeight / 2 + offset.Y, panelWidth / 2 + offset.X, panelHeight + infiniteLineLength + offset.Y); // Вниз



            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            Font font = new Font("Arial", 10, FontStyle.Bold);

            Brush brush = new SolidBrush(pen.Color);
            graph.DrawString("X", font, brush, panelWidth - 15, panelHeight / 2 + 15 + offset.Y, stringFormat);
            graph.DrawString("Y", font, brush, panelWidth / 2 - 15 + offset.X, 15, stringFormat);

            DrawArrow(graph, (panelWidth / 2 + offset.X, -2), (panelWidth / 2 - 7 + offset.X, 15), (panelWidth / 2 + 7 + offset.X, 15), customPen.Color);
            DrawArrow(graph, (panelWidth + 2, panelHeight / 2 + offset.Y),
                (panelWidth - 15, panelHeight / 2 - 7 + offset.Y), (panelWidth - 15, panelHeight / 2 + 7 + offset.Y), customPen.Color);

        }

        // Единичная окружность
        private void DrawCircle(Graphics graph, Pen pen)
        {
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;
            Pen newPen = new Pen(pen.Color, 2);
            newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // Учитываем смещение
            int circleX = panelWidth / 2 - UnitSegment + offset.X + offsetRight.X;
            int circleY = panelHeight / 2 - UnitSegment + offset.Y + offsetRight.Y;

            if (offsetRight.X >= panelWidth / 2)
            {
                offset.X -= 1;
            }
            if (offsetRight.X <= -panelWidth / 2)
            {
                offset.X += 1;
            }

            if (offsetRight.Y >= panelHeight / 2)
            {
                offset.Y -= 1;
            }

            if (offsetRight.Y <= -panelHeight / 2)
            {
                offset.Y += 1;
            }

            RectangleF rect = new RectangleF(circleX, circleY, UnitSegment * 2, UnitSegment * 2);
            graph.DrawEllipse(newPen, rect);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Перерисовка в случае изменения размера окна
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // Красные точки перемещаются на дельту размеров окна (float точнее)
            for (int i = 0; i < points.Count; i++)
            {
                float newX = points[i].X + (float)(panel1.Width - prevPanelWidth) / 2.0f;
                float newY = points[i].Y + (float)(panel1.Height - prevPanelHeight) / 2.0f;

                points[i] = new PointF(newX, newY);
            }

            // Аппроксимированная кривая смещается при изменении размеров окна
            for (int i = 0; i < constructedCurve.Count; i++)
            {
                float newX = constructedCurve[i].X + (float)(panel1.Width - prevPanelWidth) / 2.0f;
                float newY = constructedCurve[i].Y + (float)(panel1.Height - prevPanelHeight) / 2.0f;

                constructedCurve[i] = new PointF(newX, newY);
            }

            prevPanelWidth = panel1.Width;
            prevPanelHeight = panel1.Height;

            panel1.Invalidate();
        }

        // Отрисовка стрелочки
        private void DrawArrow (Graphics graph, (int X, int Y) pointArrow1, (int X, int Y) pointArrow2, (int X, int Y) pointArrow3, Color customColor)
        {
            Point[] arrowPoints = new Point[3];
            arrowPoints[0] = new Point(pointArrow1.X, pointArrow1.Y);
            arrowPoints[1] = new Point(pointArrow2.X, pointArrow2.Y);
            arrowPoints[2] = new Point(pointArrow3.X, pointArrow3.Y);


            Brush brush = new SolidBrush(customColor);
            graph.FillPolygon(brush, arrowPoints);
        }

        

        private void BackChangeBtn_Click(object sender, EventArgs e)
        {
            BackgroundThemeForm backgroundThemeForm = new BackgroundThemeForm();
            backgroundThemeForm.ShowDialog();

            selectedGrid = backgroundThemeForm.gridIndex;

            selectedGradient[0] = backgroundThemeForm.colors[0];
            selectedGradient[1] = backgroundThemeForm.colors[1];

            selectedTheme = backgroundThemeForm.themeIndex;

            panel1.Invalidate();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                int deltaX = e.X - previosLocationMouse.X;
                int deltaY = e.Y - previosLocationMouse.Y;

                offset.X += deltaX;
                offset.Y += deltaY;

                panel1.Invalidate();

                previosLocationMouse = e.Location;
            }

            if(circleMove)
            {
                int deltaX = e.X - previosLocationMouse.X;
                int deltaY = e.Y - previosLocationMouse.Y;

                if (offsetRight.X <= panel1.Width / 2 - deltaX - offset.X)
                    offsetRight.X += deltaX;

                if (offsetRight.X <= -panel1.Width / 2 - offset.X + deltaX)
                    offsetRight.X -= deltaX;



                if (offsetRight.Y <= panel1.Height / 2 - offset.Y + deltaY) 
                    offsetRight.Y += deltaY;

                if (offsetRight.Y <= -panel1.Height / 2 + deltaY - offset.Y)
                    offsetRight.Y -= deltaY;

                //offsetRight.Y += deltaY;

                panel1.Invalidate();

                previosLocationMouse = e.Location;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                moving = true;
                previosLocationMouse = e.Location;
            }

            if(e.Button == MouseButtons.Right)
            {
                circleMove = true;
                previosLocationMouse = e.Location;
            }

            if(e.Button == MouseButtons.Middle)
            {
                points.Add(new PointF(e.Location.X - offset.X, e.Location.Y - offset.Y));
                panel1.Invalidate();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            circleMove = false;
        }

        private void DrawFunction(Graphics graph, IFunction function, float minX, float maxX, Pen pen)
        {
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;

            float offCenterX = panelWidth / 2 + offset.X;
            float offCenterY = panelHeight / 2 + offset.Y;

            float prevX = offCenterX;
            float prevY = offCenterY;

            float step = 0.01f;

            bool firstPoint = true;

            for (float x = minX; x <= maxX; x += step)
            {
                float y = -function.Calc(x) * UnitSegment + offCenterY;

                if (firstPoint)
                {
                    prevX = x * UnitSegment + offCenterX;
                    prevY = y;
                    firstPoint = false;
                }

                if(Math.Abs(y - prevY) > 2000)
                {
                    graph.DrawLine(pen, prevX, prevY, prevX, prevY - offCenterY);
                    graph.DrawLine(pen, x * UnitSegment + offCenterX, y, x * UnitSegment + offCenterX, y - offCenterY);
                }
                else
                    graph.DrawLine(pen, prevX, prevY, x * UnitSegment + offCenterX, y);

                prevX = x * UnitSegment  + offCenterX;
                prevY = y;
            }

        }

        private void DrawSquareGrid(Graphics graph, float minX, float maxX, float minY, float maxY) 
        {
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;
            Pen pen = new Pen(Color.LightGray, 2);

            float offCenterX = panelWidth / 2 + offset.X;
            float offCenterY = panelHeight / 2 + offset.Y;

            float step = UnitSegment;
            
            // Рисую в правую (+) сторону
            for (float x = UnitSegment; x <= maxX;  x += step)
            {
                graph.DrawLine(pen, x + offCenterX, 0, x + offCenterX, panelHeight);
            }

            // Рисую в левую (-) сторону
            for (float x = -UnitSegment; x >= minX; x -= step)
            {
                graph.DrawLine(pen, x + offCenterX, 0, x + offCenterX, panelHeight);
            }

            // Рисую в нижнюю (+) сторону
            for (float y = UnitSegment; y <= maxY; y += step)
            {
                graph.DrawLine(pen, 0, y + offCenterY, panelWidth, y + offCenterY);
            }

            // Рисую в верхнюю (-) сторону
            for (float y = UnitSegment;y >= minY; y -= step)
            {
                graph.DrawLine(pen, 0, y + offCenterY, panelWidth, y + offCenterY);
            }
        }

        private void DrawCircularGrid(Graphics graph)
        {
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;
            Pen pen = new Pen(Color.LightGray, 2);

            float offCenterX = panelWidth / 2 + offset.X;
            float offCenterY = panelHeight / 2 + offset.Y;

            float step = UnitSegment;

            // Рисование кругов

            // Радиус = максимальное измерение окна + максимальное смещение
            for (float radius = UnitSegment; radius <= Math.Sqrt(Math.Pow(panelHeight, 2) + Math.Pow(panelWidth, 2)) +
                Math.Max(Math.Abs(offCenterX), Math.Abs(offCenterY)); radius += step)
            {
                float circleX = offCenterX - radius;
                float circleY = offCenterY - radius;
                float circleWidth = radius * 2;
                float circleHeight = radius * 2;
                graph.DrawEllipse(pen, circleX, circleY, circleWidth, circleHeight);
            }
        }
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {

            prevScale = scale;

            if (e.Delta > 0 && scale <= 10) 
            {
                scale = Math.Round(scale + 0.2, 1);
            }
            else if (scale > 0.2)
            {
                scale = Math.Round(scale - 0.2, 1);
            }
            UnitSegment = (int)Math.Round(UnitSegment * scale / prevScale);

            // Применяю масштабирование к красным точкам
            UpdatePointsCoordinates();

            // Применяю масштабирование к аппроксимированной кривой
            constructedCurve = UpdateCurveCoordinates(constructedCurve);
            panel1.Invalidate();

            // Показываю масштаб
            if (scale == 1)
            {
                ScaleLabel.Visible = false;
            }
            else
            {
                ScaleLabel.Visible = true;
                ScaleLabel.Text = $"{scale * 100}%";
            }

            if (scale >= 0.2 && scale <= 10)
            {
                panel1.Invalidate();
            }
        }

        public void AddSmiley(string imagePath, int x, int y, int length, int width)
        {
            Image image = Image.FromFile(imagePath);

            Smiley smiley = new Smiley
            {
                Image = image,
                X = x,
                Y = y,
                Length = length,
                Width = width
            };

            smileys.Add(smiley);

            panel1.Invalidate();
        }

        private void DrawPanelBorder(Graphics graph, Color color)
        {
            int borderWidth = 10; // Вы можете настроить толщину рамки по вашему усмотрению
            Pen borderPen = new Pen(color, borderWidth);
            borderPen.DashStyle = DashStyle.DashDot;

            graph.DrawRectangle(borderPen, panel1.Left + 5, panel1.Top + 5, panel1.Width - borderWidth, panel1.Height - borderWidth);
        }

        ///todo: Разобраться с сохранением эмодзи
        private void SaveFileBtn_Click(object sender, EventArgs e)
        {

            Bitmap bitmapPanel = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bitmapPanel, new Rectangle(0, 0, panel1.Width, panel1.Height));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "Самые красивые графики во всей аудитории";
            saveFileDialog.Filter = "Изображения (*.jpeg)|*.jpeg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmapPanel.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                MessageBox.Show("Изображение сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ColorGraphicBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result;

            result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                customPen.Color = colorDialog.Color;
                panel1.Invalidate();
                MessageBox.Show("Цвет графика изменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (smileys.Count == 0)
            {
                ColorGraphicBtn.Enabled = true;
                SaveFileBtn.Enabled = true;
            }
        }

        private void RandomFuncBtn_Click(object sender, EventArgs e)
        {
            points.Clear();
            approximation = false;

            offset.X = 0;
            offset.Y = 0;

            randomFunction = GetRandomFunction();



            // Перерисовка с учетом новой функции
            panel1.Invalidate();
        }

        private IFunction GetRandomFunction()
        {
            Random random = new Random();
            int functionIndex = random.Next(1, 7);

            switch (functionIndex)
            {
                case 1:
                    return new SinFunc();
                case 2:
                    return new SquareFunc();
                case 3:
                    return new TgFunc();
                case 4:
                    return new CubicFunc();
                case 5:
                    return new LinearFunc();
                default:
                    approximation = true;
                    return null;
            }
        }

        private void UpdatePointsCoordinates()
        {
            for (int i = 0; i < points.Count; i++)
            {
                float newX = (points[i].X - panel1.Width / 2) * (float)(scale / prevScale) + panel1.Width / 2;
                float newY = (points[i].Y - panel1.Height / 2) * (float)(scale / prevScale) + panel1.Height / 2;

                points[i] = new PointF(newX, newY);
            }
        }

        private List<PointF> Approximate(List<PointF> inputPoints)
        {
            List<PointF> interpolatedPoints = new List<PointF>();

            foreach (PointF point in inputPoints)
            {
                float weightedSumY = 0;
                float sumWeights = 0;

                foreach (PointF otherPoint in inputPoints)
                {
                    if (point != otherPoint)
                    {
                        float distance = CalculateDistance(point, otherPoint);
                        float weight = 1.0f / (float)(distance * distance);

                        weightedSumY += otherPoint.Y * weight;
                        sumWeights += weight;
                    }
                }

                float interpolatedY = weightedSumY / sumWeights;
                interpolatedPoints.Add(new PointF(point.X, interpolatedY));
            }

            return interpolatedPoints;
        }
        private float CalculateDistance(PointF point1, PointF point2)
        {
            return (float)Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        // Кнопка аппроксимации
        private void DrawCurveBtn_Click(object sender, EventArgs e)
        {
            if (points.Count > 1)
            {
                constructedCurve = Approximate(points);
                approximation = true;
                panel1.Invalidate();
            }
            
        }

        private List<PointF> UpdateCurveCoordinates(List<PointF> curve)
        {
            List<PointF> updatedCurve = new List<PointF>();

            foreach (var point in curve)
            {
                float updatedX = (point.X - panel1.Width / 2) * (float)(scale / prevScale) + panel1.Width / 2;
                float updatedY = (point.Y - panel1.Height / 2) * (float)(scale / prevScale) + panel1.Height / 2;

                updatedCurve.Add(new PointF(updatedX, updatedY));
            }

            return updatedCurve;
        }

        private void SaveCurveBtn_Click(object sender, EventArgs e)
        {
            //savedCurve = new List<PointF>(constructedCurve);
        }

        private List<PointF> GetApproximatedCurve(List<PointF> constructedCurve)
        {
            if (constructedCurve == null)
            {
                return new List<PointF>();
            }

            List<PointF> adjustedCurve = new List<PointF>();
            foreach (var point in constructedCurve)
            {
                adjustedCurve.Add(new PointF(point.X + offset.X, point.Y + offset.Y));
            }

            // Сортирую список точек по иксам
            adjustedCurve = adjustedCurve.OrderBy(point => point.X).ToList();
            return adjustedCurve;
        }
    } 
}
