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
        private Action action;

        bool mouseMidbutton = false;
        bool mouseLbutton = false;
        bool shiftButton = false;
        bool ctrlButton = false;
        bool altButton = false;

        enum Tool
        {
            view,
            move,
            select
        }
        enum Action
        {
            moving,
            selecting,
            connecting,
            viewchanging
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
            if (e.Button == MouseButtons.Middle) mouseMidbutton = true;
            if (shiftButton)
            {
                tool = Tool.select;
                return;
            }
            if (ctrlButton)
            {
                action = Action.connecting;
                return;
            }
                
        }
        private void MainPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
            if (mouseMidbutton)
            {
                mainScene.Camera_HorizontalAngle += (e.X - startPos.X);
                mainScene.Camera_VerticalAngle += (e.Y - startPos.Y);
                startPos.X = e.X;
                startPos.Y = e.Y;
                UpdatePicBox(true);
                return;
            }
            if(tool == Tool.move && mouseLbutton && mainScene.SelectedPoints.Count > 0)
            {
                mainScene.MovePoints(e.X - startPos.X, e.Y - startPos.Y, 0, true);
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
            if (action == Action.connecting && mouseLbutton)
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

            if (e.Button == MouseButtons.Middle) mouseMidbutton = false;

            if (tool == Tool.select && e.Button == MouseButtons.Left)
            {
                mouseLbutton = false;
                mainScene.SelectPoints(startPos.X, startPos.Y, endPos.X, endPos.Y);

            }
            if (e.Button == MouseButtons.Right)
            {
                mainPicBox_ContextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            if (action == Action.connecting && e.Button == MouseButtons.Left)
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
            GR_Point p = new GR_Point(endPos.X, endPos.Y, 0f, rnd.Next(10, 30), rnd.Next(1, 2), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            mainScene.AddPoint(p);

            UpdatePicBox();
        }

        private void GR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) { shiftButton = true; label1.Text = "1"; }
            if (e.KeyCode == Keys.ControlKey) ctrlButton = true;
            if (tool == Tool.move)
            {
                if (e.KeyCode == Keys.Up) mainScene.MovePoints(0, -1, 0, true);
                if (e.KeyCode == Keys.Down) mainScene.MovePoints(0, 1, 0, true);
                if (e.KeyCode == Keys.Right) mainScene.MovePoints(1, 0, 0, true);
                if (e.KeyCode == Keys.Left) mainScene.MovePoints(-1, 0, 0, true);
                UpdatePicBox();
            }
            


        }

        private void GR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) { shiftButton = false; label1.Text = "0"; }
            if (e.KeyCode == Keys.ControlKey) ctrlButton = false;
        }
        private void setButtonsDefaultColors()
        {
            foreach(Button b in panel1.Controls)
            {
                b.BackColor = Color.WhiteSmoke;
            }
        }
        private void buttonToolView_Click(object sender, EventArgs e)
        {
            setButtonsDefaultColors();
            buttonToolView.BackColor = Color.FromArgb(100, Color.Teal);
            tool = Tool.view;
        }

        private void buttonToolMove_Click(object sender, EventArgs e)
        {
            setButtonsDefaultColors();
            buttonToolMove.BackColor = Color.FromArgb(100, Color.Teal);
            tool = Tool.move;
        }

        private void buttonToolSelect_Click(object sender, EventArgs e)
        {
            setButtonsDefaultColors();
            buttonToolStyle.BackColor = Color.FromArgb(100, Color.Teal);
            tool = Tool.select;
        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainScene.DeletePoints(true);
            UpdatePicBox();
        }
        //MatrixOperation(new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, -1, 0, 1 } }, true);
    }
}
