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
        private Tool tool;

        bool mouseRbutton = false;
        bool mouseLbutton = false;
        bool shiftButton = false;
        bool ctrlButton = false;
        bool altButton = false;

        enum Tool
        {
            move,
            select,
            connect,
            scale,
            rotate
        }


        public MainWindow()
        {
            InitializeComponent();
            MainPicBox.Image = new Bitmap(MainPicBox.Width, MainPicBox.Height);
            MainPicBox.BackColor = Color.Gray;
            main_graphics = Graphics.FromImage(MainPicBox.Image);
            mainScene = new GR_Scene();
            this.DoubleBuffered = true;
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;

        }

        private void MainPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
            
            if (e.Button == MouseButtons.Left) mouseLbutton = true;
            if (shiftButton)
            {
                tool = Tool.select;
                return;
            }
            if (ctrlButton)
            {
                tool = Tool.connect;
                return;
            }
                
        }
        private void MainPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
            if(tool == Tool.move && mouseLbutton && mainScene.SelectedPoints.Count > 0)
            {
                int off_x;
                int off_y;
                for (int i = 0; i < mainScene.SelectedPoints.Count; i++)
                {
                    off_x = e.X - startPos.X;
                    off_y = e.Y - startPos.Y;

                    mainScene.SelectedPoints[i].x = mainScene.SelectedPoints[i].x + off_x;
                    mainScene.SelectedPoints[i].y = mainScene.SelectedPoints[i].y + off_y;
                }
                startPos.X = e.X;
                startPos.Y = e.Y;
                UpdatePicBox(true);
                return;
            }
            if (tool == Tool.select && mouseLbutton)
            {
                UpdatePicBox(false);
                DrawSelectRect(Color.FromArgb(25, Color.Teal), Color.FromArgb(75, Color.Teal), startPos.X, startPos.Y, e.X, e.Y);
                MainPicBox.Refresh();
                return;
            }
            if (tool == Tool.connect && mouseLbutton)
            {
                UpdatePicBox(false);
                main_graphics.DrawLine(new Pen(Color.Black, 2.0F), startPos, endPos);
                MainPicBox.Refresh();
                return;
            }
        }
        private void DrawSelectRect(Color fillColor, Color outColor, int x1, int y1, int x2, int y2)
        {
            Brush select_brush;
            Pen select_pen = new Pen(outColor, 2.0F);

            if (x1 == x2 || y1 == y2)
                select_brush = new LinearGradientBrush(new Point(x1, y1), new Point(x2 + 1, y2 + 1), outColor, fillColor);
            else
                select_brush = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y2), outColor, fillColor);

            x2 -= x1; // width and heigt
            y2 -= y1;

            if (x2 < 0)
            {
                x2 = -x2;
                x1 -= x2;
            }
            if (y2 < 0)
            {
                y2 = -y2;
                y1 -= y2;
            }

            main_graphics.FillRectangle(select_brush, x1, y1, x2, y2);
            main_graphics.DrawRectangle(select_pen, x1, y1, x2, y2);

            select_brush.Dispose();
            select_pen.Dispose();
        }
        

        private void MainPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
           
            if (tool == Tool.select && e.Button == MouseButtons.Left)
            {
                mouseLbutton = false;
                mainScene.SelectPoints(startPos.X, startPos.Y, endPos.X, endPos.Y);

            }
            if (e.Button == MouseButtons.Right)
            {
                mainPicBox_ContextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            if (tool == Tool.connect && e.Button == MouseButtons.Left)
            {
                mouseLbutton = false;
                mainScene.ConnectPoints(startPos, endPos);
            }

            UpdatePicBox();
            if (e.Button == MouseButtons.Left) mouseLbutton = false;
            tool = Tool.move;
        }
        private void UpdatePicBox(bool refresh = true)
        {
            main_graphics.Clear(Color.White);
            mainScene.Draw(main_graphics);
            if (refresh) MainPicBox.Refresh();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GR_Point p = new GR_Point(endPos.X, endPos.Y, 0, rnd.Next(40, 100), rnd.Next(1, 10), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            mainScene.AddPoint(p);

            UpdatePicBox();
        }

        private void GR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) { shiftButton = true; label1.Text = "1"; }
            if (e.KeyCode == Keys.ControlKey) ctrlButton = true;
        }

        private void GR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) { shiftButton = false; label1.Text = "0"; }
            if (e.KeyCode == Keys.ControlKey) ctrlButton = false;
        }
    }
}
