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

namespace GraphicReactor
{
    public partial class MainWindow : Form
    {
        private Graphics main_graphics;
        private GR_Scene mainScene;
        Random rnd = new Random();
        Point startPos;
        Point endPos;
        bool mouseRbutton = false;
        bool mouseLbutton = false;
        bool shiftButton = false;
        bool ctrlButton = false;
        bool altButton = false;



        public MainWindow()
        {
            InitializeComponent();
            MainPicBox.Image = new Bitmap(MainPicBox.Width, MainPicBox.Height);
            MainPicBox.BackColor = Color.Gray;
            main_graphics = Graphics.FromImage(MainPicBox.Image);
            mainScene = new GR_Scene();
            this.DoubleBuffered = true;
            main_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void MainPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
            if (e.Button == MouseButtons.Left) mouseLbutton = true;

        }
        private void MainPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
            if (mouseLbutton)
            {
                UpdatePicBox(false);
                DrawSelectRect(Color.FromArgb(75, Color.Aqua), Color.FromArgb(75, Color.Violet), startPos.X, startPos.Y, e.X - startPos.X, e.Y - startPos.Y);
                MainPicBox.Refresh();
            }
        }
        private void DrawSelectRect(Color fillColor, Color outColor, float x, float y, float width, float height)
        {

            if (width < 0)
            {
                width = -width;
                x -= width;
            }
            if (height < 0)
            {
                height = -height;
                y -= height;
            }
            Pen select_pen = new Pen(outColor, 2.0F);
            Brush select_brush = new LinearGradientBrush(startPos, endPos, outColor, fillColor);
            main_graphics.FillRectangle(select_brush, x, y, width, height);
            main_graphics.DrawRectangle(select_pen, x, y, width, height);

            select_brush.Dispose();
            select_pen.Dispose();
        }

        private void MainPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
            if (e.Button == MouseButtons.Left) mouseLbutton = false;
            if (e.Button == MouseButtons.Right)
            {
                mainPicBox_ContextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                return;
            }
            UpdatePicBox();
        }
        private void UpdatePicBox(bool refresh = true)
        {
            main_graphics.Clear(Color.White);
            mainScene.Draw(main_graphics);
            if (refresh) MainPicBox.Refresh();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GR_Point p = new GR_Point(endPos.X - 50, endPos.Y - 50, 0, 100, 1, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            mainScene.AddPoint(p);

            UpdatePicBox();
        }
    }
}
