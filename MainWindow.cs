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

            Zc_label.Text = mainScene.Zc.ToString();
            moveModeButton.BackColor = Color.FromArgb(100, Color.Teal);

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
                        mainScene.MovePoints( true, false, false, e.X, startPos.X, e.Y, startPos.Y, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Xrotate += e.X - startPos.X;
                    else if(tool == Tool.resize)
                        mainScene.Temp_Xresize += (float)(e.X - startPos.X) / 16;
                }
                else if (action == Action.transformY)
                {
                    if (tool == Tool.move)
                        mainScene.MovePoints(false, true, false, e.X, startPos.X, e.Y, startPos.Y, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Yrotate += e.X - startPos.X;
                    else if (tool == Tool.resize)
                        mainScene.Temp_Yresize += (float)(e.X - startPos.X) / 16;
                }
                else if (action == Action.transformZ) 
                {
                    if (tool == Tool.move)
                        mainScene.MovePoints(false, false, true, e.X, startPos.X, e.Y, startPos.Y, true);
                    else if (tool == Tool.rotate)
                        mainScene.Temp_Zrotate += e.X - startPos.X;
                    else if (tool == Tool.resize)
                        mainScene.Temp_Zresize += (float)(e.X - startPos.X) / 16;
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
                mainScene.Camera_HorizontalAngle += (float)(e.X - startPos.X)/4;
                mainScene.Camera_VerticalAngle += (float)(e.Y - startPos.Y)/4;
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
                treeSelected_CheckedUpdate();

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

            GR_Point p = mainScene.GetPointsCenter(true);

            label2.Text = p.X.ToString();
            label3.Text = p.Y.ToString();
            label4.Text = p.Z.ToString();


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
            UpdateTreeView();
        }

        private void GR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)  shiftButton = true;
            if (e.KeyCode == Keys.ControlKey) ctrlButton = true;
                
            
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
            UpdateTreeView();
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



        private void Zc_DecreaseButton_Click(object sender, EventArgs e)
        {
            mainScene.Zc -= 100;
            UpdatePicBox();
            Zc_label.Text = mainScene.Zc.ToString();
        }

        private void Zc_IncreaseButton_Click(object sender, EventArgs e)
        {
            mainScene.Zc += 100;
            UpdatePicBox();
            Zc_label.Text = mainScene.Zc.ToString();
        }

        private void UpdateTreeView()
        {
            groupsTreeView.Nodes[0].Nodes.Clear();
            foreach (GR_Point p in mainScene.points)
            {
                TreeNode node = new TreeNode();
                node.Text = "Point " + p.Id.ToString();
                node.Name = p.Id.ToString();
                node.Checked = p.Selected;
                groupsTreeView.Nodes[0].Nodes.Add(node);
            }
        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTreeView();
        }


        private void groupsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //mainScene.UnselectPoints();
            //mainScene.SelectPoint(Convert.ToUInt32(e.Node.Name));
            //UpdatePicBox();
        }

        private void groupsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (action == Action.selecting) return;
            if (e.Node == groupsTreeView.Nodes[0])
            {
               foreach(TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
            else
            {
                pointsSelected_CheckedUpdate();
                UpdatePicBox();
            }
            
            
        }
        private void treeSelected_CheckedUpdate()
        {
            foreach (GR_Point p in mainScene.points)
                foreach (TreeNode node in groupsTreeView.Nodes[0].Nodes)
                    if (node.Name == p.Id.ToString())
                        node.Checked = p.Selected;
        }
        private void pointsSelected_CheckedUpdate()
        {
            foreach (GR_Point p in mainScene.points)
                foreach (TreeNode node in groupsTreeView.Nodes[0].Nodes)
                    if (node.Name == p.Id.ToString())
                        p.Selected = node.Checked;
        }
        private bool AllChildsChecked()
        {
            foreach (TreeNode node in groupsTreeView.Nodes[0].Nodes)
            {
                if (!node.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        //MatrixOperation(new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, -1, 0, 1 } }, true);
    }
}