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


        enum Tool
        {
            move,
            rotate,
            resize
        }
        enum Action
        {
            noAction,
            transformX,
            transformY,
            transformZ,
            selecting,
            connecting,
            viewchanging
        }

        public MainWindow()
        {

            InitializeComponent();

            mainScene = new GR_Scene();

            UpdatePicBoxParams();

        }

        private void UpdatePicBoxParams()
        {
            mainScene.HorizontalOffset = MainPicBox.Width / 2;
            mainScene.VerticalOffset = MainPicBox.Height / 2;
            MainPicBox.Image = new Bitmap(MainPicBox.Width > 0 ? MainPicBox.Width : 1, MainPicBox.Height > 0 ? MainPicBox.Height : 1);
            main_graphics = Graphics.FromImage(MainPicBox.Image); 
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            UpdatePicBox();
        }

        private void MainPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;

            if (e.Button == MouseButtons.Left) mouseLbutton = true;
            if (e.Button == MouseButtons.Middle) mouseMidbutton = true;

            
            if (mainScene.HitXarrow(startPos.X, startPos.Y))
            {
                action = Action.transformX;
                return;
            }
            if (mainScene.HitYarrow(startPos.X, startPos.Y))
            {
                action = Action.transformY;
                return;
            }
            if (mainScene.HitZarrow(startPos.X, startPos.Y))
            {
                action = Action.transformZ;
                return;
            }


            if (shiftButton)
            {
                action = Action.selecting;
                return;
            }
            if (ctrlButton && mouseLbutton)
            {
                action = Action.connecting;
                return;
            }
                
        }
        private void MainPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            endPos = e.Location;
            if (mouseLbutton && action != Action.noAction)
            {
                if (action == Action.connecting)
                {
                    UpdatePicBox(false);
                    main_graphics.DrawLine(new Pen(Color.Black, 2.0F), startPos, endPos);
                    MainPicBox.Refresh();
                    return;
                }
                else if (action == Action.selecting)
                {
                    UpdatePicBox(false);
                    DrawSelectRect(Color.FromArgb(25, Color.Teal), Color.FromArgb(75, Color.Teal), startPos.X, startPos.Y, e.X, e.Y);
                    MainPicBox.Refresh();
                    return;
                }
                else if (action == Action.transformX)
                {
                    if (tool == Tool.move)
                        mainScene.MovePoints(e.X - startPos.X, 0, 0, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Xtransform += e.X - startPos.X;
                }
                else if (action == Action.transformY)
                {
                    if (tool == Tool.move)
                        mainScene.MovePoints(0, e.X - startPos.X, 0, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Ytransform += e.X - startPos.X;
                }
                else if (action == Action.transformZ) 
                {
                    if (tool == Tool.move)
                        mainScene.MovePoints(0, 0, e.X - startPos.X, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Ztransform += e.X - startPos.X;
                }
                UpdatePicBox(true);
                startPos.X = e.X;
                startPos.Y = e.Y; 
                return;
            }

            if (mouseMidbutton && shiftButton)
            {
                mainScene.Camera_HorizontalOffset += (e.X - startPos.X);
                mainScene.Camera_VerticalOffset += (e.Y - startPos.Y);
                startPos.X = e.X;
                startPos.Y = e.Y;
                UpdatePicBox(true);
                return;
            }
            if (mouseMidbutton)
            {
                mainScene.Camera_HorizontalAngle += e.X - startPos.X;
                mainScene.Camera_VerticalAngle += e.Y - startPos.Y;
                startPos.X = e.X;
                startPos.Y = e.Y;
                UpdatePicBox(true);
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

            if (action == Action.transformX || action == Action.transformY || action == Action.transformZ)
            {
                mainScene.ApplyTransformation();
                mainScene.ResetTemp();
                action = Action.noAction;
                return;
            }
            mainScene.ResetTemp();

            if (action == Action.selecting && e.Button == MouseButtons.Left)
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
                mainScene.ConnectPoints(startPos.X, startPos.Y, endPos.X,endPos.Y, 4, Color.FromArgb(255,rnd.Next(0,255), rnd.Next(0, 255), rnd.Next(0, 255)));
            }

            UpdatePicBox();

            if (e.Button == MouseButtons.Middle) mouseMidbutton = false;

            if (e.Button == MouseButtons.Left) mouseLbutton = false;
            action = Action.noAction;
        }

        private void UpdatePicBox(bool refresh = true)
        {
            main_graphics.Clear(Color.White);
            mainScene.Draw(main_graphics, compLinesCheckBox.Checked);
            
            if (mainScene.points.Count > 0)
            {
                label2.Text = mainScene.points[0].X.ToString();
                label3.Text = mainScene.points[0].Y.ToString();
            }
            
            if (refresh) MainPicBox.Refresh();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GR_Point p = new GR_Point(endPos.X, -endPos.Y, 0f,
                rnd.Next(8, 8), rnd.Next(2, 2),
                rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255),
                rnd.Next(0, 255), rnd.Next(0,255), rnd.Next(0,255));
            mainScene.AddPoint(p);

            UpdatePicBox();
        }

        private void GR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)  shiftButton = true;
            if (e.KeyCode == Keys.ControlKey) ctrlButton = true;
            if (e.KeyCode == Keys.V)
            {
                UpdatePicBox(false);
                CreateTree(5, new Pen(Color.Brown, 1), main_graphics, MainPicBox.Width / 2, MainPicBox.Height / 2, 0,20, 30,90);
                MainPicBox.Refresh();
            }
                
            
        }

        private void GR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) shiftButton = false;
            if (e.KeyCode == Keys.ControlKey) ctrlButton = false;
        }
        private void setToolPanelButtonsDefaultColors()
        {
            moveModeButton.BackColor = Color.WhiteSmoke;
            rotationModeButton.BackColor = Color.WhiteSmoke;
            resizeModeButton.BackColor = Color.WhiteSmoke;

        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainScene.DeletePoints(true);
            UpdatePicBox();
        }

        private void MainPicBox_SizeChanged(object sender, EventArgs e)
        {
            UpdatePicBoxParams();
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainScene.MatrixOperation(
                             new double[,]
                             {
                                {-1,0,0,0},
                                {0,1,0,0},
                                {0,0,1,0},
                                {0,0,0,1}
                             }, 
                                true
                             );
            UpdatePicBox();
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainScene.MatrixOperation(
                             new double[,]
                             {
                                {1,0,0,0},
                                {0,-1,0,0},
                                {0,0,1,0},
                                {0,0,0,1}
                             },
                                true
                             );
            UpdatePicBox();
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainScene.MatrixOperation(
                             new double[,]
                             {
                                {1,0,0,0},
                                {0,1,0,0},
                                {0,0,-1,0},
                                {0,0,0,1}
                             },
                                true
                             );
            UpdatePicBox();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            mainScene.ResetCamera();
            UpdatePicBox();
        }
        public void CreateTree(int n, Pen pen, Graphics gr, float x, float y, double angle, double angle2, int length, int newLineChance)
        {
            if (n == 0) return;
            gr.DrawLine(pen, x, y,
                (float)((x) * Math.Cos(angle / 180 * Math.PI) - (y - length) * Math.Sin(angle / 180 * Math.PI) - x * Math.Cos(angle / 180 * Math.PI) + y * Math.Sin(angle / 180 * Math.PI) + x),
                (float)((x) * Math.Sin(angle / 180 * Math.PI) + (y - length) * Math.Cos(angle / 180 * Math.PI) - x * Math.Sin(angle / 180 * Math.PI) - y * Math.Cos(angle / 180 * Math.PI) + y));


            pen.Color = Color.FromArgb(255, (pen.Color.R * n) % 255, (pen.Color.G / n) % 255, (pen.Color.B * n) % 255);
            if (rnd.Next(0,100) <= newLineChance)
                CreateTree(n - 1, pen, gr,
                (float)((x) * Math.Cos(angle / 180 * Math.PI) - (y - length) * Math.Sin(angle / 180 * Math.PI) - x * Math.Cos(angle / 180 * Math.PI) + y * Math.Sin(angle / 180 * Math.PI) + x),
                (float)((x) * Math.Sin(angle / 180 * Math.PI) + (y - length) * Math.Cos(angle / 180 * Math.PI) - x * Math.Sin(angle / 180 * Math.PI) - y * Math.Cos(angle / 180 * Math.PI) + y),
                angle + rnd.Next(-5, 5), angle2, length-2 - rnd.Next(0, 2), newLineChance - 10);
            if (rnd.Next(0, 100) <= newLineChance)
                CreateTree(n - 1, pen, gr,
                (float)((x) * Math.Cos(angle / 180 * Math.PI) - (y - length) * Math.Sin(angle / 180 * Math.PI) - x * Math.Cos(angle / 180 * Math.PI) + y * Math.Sin(angle / 180 * Math.PI) + x),
                (float)((x) * Math.Sin(angle / 180 * Math.PI) + (y - length) * Math.Cos(angle / 180 * Math.PI) - x * Math.Sin(angle / 180 * Math.PI) - y * Math.Cos(angle / 180 * Math.PI) + y),
                angle - angle2 + rnd.Next(-5, 5), angle2, length - 2 - rnd.Next(0, 2), newLineChance - 10);
            if (rnd.Next(0, 100) <= newLineChance)
                CreateTree(n - 1, pen, gr,
                (float)((x) * Math.Cos(angle / 180 * Math.PI) - (y - length) * Math.Sin(angle / 180 * Math.PI) - x * Math.Cos(angle / 180 * Math.PI) + y * Math.Sin(angle / 180 * Math.PI) + x),
                (float)((x) * Math.Sin(angle / 180 * Math.PI) + (y - length) * Math.Cos(angle / 180 * Math.PI) - x * Math.Sin(angle / 180 * Math.PI) - y * Math.Cos(angle / 180 * Math.PI) + y),
                angle + angle2 + rnd.Next(-5,5), angle2, length - 2 - rnd.Next(0, 2), newLineChance - 10);
        }

        private void moveModeButton_Click(object sender, EventArgs e)
        {
            setToolPanelButtonsDefaultColors();
            moveModeButton.BackColor = Color.FromArgb(100, Color.Teal);
            tool = Tool.move;
        }

        private void rotationModeButton_Click(object sender, EventArgs e)
        {
            setToolPanelButtonsDefaultColors();
            rotationModeButton.BackColor = Color.FromArgb(120, Color.Teal);
            tool = Tool.rotate;
        }
        private void resizeModeButton_Click(object sender, EventArgs e)
        {
            setToolPanelButtonsDefaultColors();
            resizeModeButton.BackColor = Color.FromArgb(100, Color.Teal);
            tool = Tool.resize;
        }

        private void compLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePicBox();
        }

        //MatrixOperation(new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, -1, 0, 1 } }, true);
    }
}
