using System.Windows.Forms;

namespace GraphicReactor
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainPicBox_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPicBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolCustomButton9 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton3 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton10 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton4 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.resetButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.resizeModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton7 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.rotationModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton8 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.moveModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton5 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton6 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton1 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.toolCustomButton2 = new GraphicReactor.CustomForms.ToolCustomButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPicBox_ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicBox_ContextMenu
            // 
            this.mainPicBox_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.splineToolStripMenuItem});
            this.mainPicBox_ContextMenu.Name = "contextMenuStrip1";
            this.mainPicBox_ContextMenu.Size = new System.Drawing.Size(184, 92);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aToolStripMenuItem.Text = "Добавить точку";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem2.Text = "Трансформировать";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem1,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem});
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xToolStripMenuItem.Text = "Отразить";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.xToolStripMenuItem1.Text = "по X";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yToolStripMenuItem.Text = "по Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zToolStripMenuItem.Text = "по Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // splineToolStripMenuItem
            // 
            this.splineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectPointsToolStripMenuItem,
            this.createSplineToolStripMenuItem});
            this.splineToolStripMenuItem.Name = "splineToolStripMenuItem";
            this.splineToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.splineToolStripMenuItem.Text = "Сплайн";
            // 
            // selectPointsToolStripMenuItem
            // 
            this.selectPointsToolStripMenuItem.Name = "selectPointsToolStripMenuItem";
            this.selectPointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectPointsToolStripMenuItem.Text = "Выделить точки";
            this.selectPointsToolStripMenuItem.Click += new System.EventHandler(this.selectPointsToolStripMenuItem_Click);
            // 
            // createSplineToolStripMenuItem
            // 
            this.createSplineToolStripMenuItem.Name = "createSplineToolStripMenuItem";
            this.createSplineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createSplineToolStripMenuItem.Text = "Сделать сплайн";
            this.createSplineToolStripMenuItem.Click += new System.EventHandler(this.createSplineToolStripMenuItem_Click);
            // 
            // MainPicBox
            // 
            this.MainPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainPicBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainPicBox.Location = new System.Drawing.Point(2, 1);
            this.MainPicBox.Name = "MainPicBox";
            this.MainPicBox.Size = new System.Drawing.Size(531, 365);
            this.MainPicBox.TabIndex = 1;
            this.MainPicBox.TabStop = false;
            this.MainPicBox.SizeChanged += new System.EventHandler(this.MainPicBox_SizeChanged);
            this.MainPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseDown);
            this.MainPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseMove);
            this.MainPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseUp);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(548, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Размер сетки";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(550, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "label5";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(664, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Z";
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.AutoSize = true;
            this.label77.ForeColor = System.Drawing.Color.Red;
            this.label77.Location = new System.Drawing.Point(558, 19);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(14, 13);
            this.label77.TabIndex = 25;
            this.label77.Text = "X";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(612, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Y";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(658, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(550, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(604, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(548, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Режим";
            // 
            // toolCustomButton9
            // 
            this.toolCustomButton9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton9.Location = new System.Drawing.Point(547, 161);
            this.toolCustomButton9.Name = "toolCustomButton9";
            this.toolCustomButton9.Size = new System.Drawing.Size(156, 23);
            this.toolCustomButton9.TabIndex = 30;
            this.toolCustomButton9.Text = "-";
            this.toolCustomButton9.UseVisualStyleBackColor = true;
            this.toolCustomButton9.Click += new System.EventHandler(this.toolCustomButton9_Click);
            // 
            // toolCustomButton3
            // 
            this.toolCustomButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton3.Location = new System.Drawing.Point(547, 200);
            this.toolCustomButton3.Name = "toolCustomButton3";
            this.toolCustomButton3.Size = new System.Drawing.Size(78, 23);
            this.toolCustomButton3.TabIndex = 22;
            this.toolCustomButton3.Text = "Сохранить";
            this.toolCustomButton3.UseVisualStyleBackColor = true;
            this.toolCustomButton3.Click += new System.EventHandler(this.toolCustomButton3_Click);
            // 
            // toolCustomButton10
            // 
            this.toolCustomButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton10.Location = new System.Drawing.Point(547, 119);
            this.toolCustomButton10.Name = "toolCustomButton10";
            this.toolCustomButton10.Size = new System.Drawing.Size(156, 23);
            this.toolCustomButton10.TabIndex = 29;
            this.toolCustomButton10.Text = "+";
            this.toolCustomButton10.UseVisualStyleBackColor = true;
            this.toolCustomButton10.Click += new System.EventHandler(this.toolCustomButton10_Click);
            // 
            // toolCustomButton4
            // 
            this.toolCustomButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton4.Location = new System.Drawing.Point(625, 200);
            this.toolCustomButton4.Name = "toolCustomButton4";
            this.toolCustomButton4.Size = new System.Drawing.Size(78, 23);
            this.toolCustomButton4.TabIndex = 21;
            this.toolCustomButton4.Text = "Загрузить";
            this.toolCustomButton4.UseVisualStyleBackColor = true;
            this.toolCustomButton4.Click += new System.EventHandler(this.toolCustomButton4_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.Location = new System.Drawing.Point(547, 343);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(156, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Сбросить вращение";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // resizeModeButton
            // 
            this.resizeModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resizeModeButton.BackColor = System.Drawing.Color.Transparent;
            this.resizeModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.resizeModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.resizeModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.resizeModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resizeModeButton.Location = new System.Drawing.Point(547, 312);
            this.resizeModeButton.Name = "resizeModeButton";
            this.resizeModeButton.Size = new System.Drawing.Size(156, 23);
            this.resizeModeButton.TabIndex = 11;
            this.resizeModeButton.Text = "Масштабирование";
            this.resizeModeButton.UseVisualStyleBackColor = false;
            this.resizeModeButton.Click += new System.EventHandler(this.resizeModeButton_Click);
            // 
            // toolCustomButton7
            // 
            this.toolCustomButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton7.Location = new System.Drawing.Point(655, 77);
            this.toolCustomButton7.Name = "toolCustomButton7";
            this.toolCustomButton7.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton7.TabIndex = 24;
            this.toolCustomButton7.Text = "-";
            this.toolCustomButton7.UseVisualStyleBackColor = true;
            this.toolCustomButton7.Click += new System.EventHandler(this.toolCustomButton7_Click);
            // 
            // rotationModeButton
            // 
            this.rotationModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationModeButton.BackColor = System.Drawing.Color.Transparent;
            this.rotationModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rotationModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.rotationModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.rotationModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotationModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotationModeButton.Location = new System.Drawing.Point(547, 283);
            this.rotationModeButton.Name = "rotationModeButton";
            this.rotationModeButton.Size = new System.Drawing.Size(156, 23);
            this.rotationModeButton.TabIndex = 9;
            this.rotationModeButton.Text = "Вращение";
            this.rotationModeButton.UseVisualStyleBackColor = false;
            this.rotationModeButton.Click += new System.EventHandler(this.rotationModeButton_Click);
            // 
            // toolCustomButton8
            // 
            this.toolCustomButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton8.Location = new System.Drawing.Point(655, 35);
            this.toolCustomButton8.Name = "toolCustomButton8";
            this.toolCustomButton8.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton8.TabIndex = 23;
            this.toolCustomButton8.Text = "+";
            this.toolCustomButton8.UseVisualStyleBackColor = true;
            this.toolCustomButton8.Click += new System.EventHandler(this.toolCustomButton8_Click);
            // 
            // moveModeButton
            // 
            this.moveModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveModeButton.BackColor = System.Drawing.SystemColors.Control;
            this.moveModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.moveModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.moveModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.moveModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moveModeButton.Location = new System.Drawing.Point(547, 254);
            this.moveModeButton.Name = "moveModeButton";
            this.moveModeButton.Size = new System.Drawing.Size(156, 23);
            this.moveModeButton.TabIndex = 10;
            this.moveModeButton.Text = "Перемещение";
            this.moveModeButton.UseVisualStyleBackColor = false;
            this.moveModeButton.Click += new System.EventHandler(this.moveModeButton_Click);
            // 
            // toolCustomButton5
            // 
            this.toolCustomButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton5.Location = new System.Drawing.Point(601, 77);
            this.toolCustomButton5.Name = "toolCustomButton5";
            this.toolCustomButton5.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton5.TabIndex = 22;
            this.toolCustomButton5.Text = "-";
            this.toolCustomButton5.UseVisualStyleBackColor = true;
            this.toolCustomButton5.Click += new System.EventHandler(this.toolCustomButton5_Click);
            // 
            // toolCustomButton6
            // 
            this.toolCustomButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton6.Location = new System.Drawing.Point(601, 35);
            this.toolCustomButton6.Name = "toolCustomButton6";
            this.toolCustomButton6.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton6.TabIndex = 21;
            this.toolCustomButton6.Text = "+";
            this.toolCustomButton6.UseVisualStyleBackColor = true;
            this.toolCustomButton6.Click += new System.EventHandler(this.toolCustomButton6_Click);
            // 
            // toolCustomButton1
            // 
            this.toolCustomButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton1.Location = new System.Drawing.Point(547, 77);
            this.toolCustomButton1.Name = "toolCustomButton1";
            this.toolCustomButton1.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton1.TabIndex = 20;
            this.toolCustomButton1.Text = "-";
            this.toolCustomButton1.UseVisualStyleBackColor = true;
            this.toolCustomButton1.Click += new System.EventHandler(this.toolCustomButton1_Click_1);
            // 
            // toolCustomButton2
            // 
            this.toolCustomButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolCustomButton2.Location = new System.Drawing.Point(547, 35);
            this.toolCustomButton2.Name = "toolCustomButton2";
            this.toolCustomButton2.Size = new System.Drawing.Size(48, 23);
            this.toolCustomButton2.TabIndex = 19;
            this.toolCustomButton2.Text = "+";
            this.toolCustomButton2.UseVisualStyleBackColor = true;
            this.toolCustomButton2.Click += new System.EventHandler(this.toolCustomButton2_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(2, 423);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(701, 45);
            this.trackBar1.TabIndex = 33;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.trackBar1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(2, 372);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(702, 45);
            this.trackBar2.TabIndex = 34;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.trackBar2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.aToolStripMenuItem1.Text = "Удалить";
            this.aToolStripMenuItem1.Click += new System.EventHandler(this.aToolStripMenuItem1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 458);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolCustomButton9);
            this.Controls.Add(this.toolCustomButton3);
            this.Controls.Add(this.toolCustomButton10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolCustomButton4);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.resizeModeButton);
            this.Controls.Add(this.toolCustomButton7);
            this.Controls.Add(this.rotationModeButton);
            this.Controls.Add(this.toolCustomButton8);
            this.Controls.Add(this.moveModeButton);
            this.Controls.Add(this.toolCustomButton5);
            this.Controls.Add(this.MainPicBox);
            this.Controls.Add(this.toolCustomButton6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolCustomButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolCustomButton2);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(524, 313);
            this.Name = "MainWindow";
            this.Text = "Reactor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            this.mainPicBox_ContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip mainPicBox_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.PictureBox MainPicBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private CustomForms.ToolCustomButton resetButton;
        private CustomForms.ToolCustomButton resizeModeButton;
        private CustomForms.ToolCustomButton rotationModeButton;
        private CustomForms.ToolCustomButton moveModeButton;
        private ToolStripMenuItem splineToolStripMenuItem;
        private ToolStripMenuItem selectPointsToolStripMenuItem;
        private ToolStripMenuItem createSplineToolStripMenuItem;
        private CustomForms.ToolCustomButton toolCustomButton3;
        private CustomForms.ToolCustomButton toolCustomButton4;
        private Label label1;
        private Label label77;
        private Label label8;
        private CustomForms.ToolCustomButton toolCustomButton7;
        private CustomForms.ToolCustomButton toolCustomButton8;
        private CustomForms.ToolCustomButton toolCustomButton5;
        private CustomForms.ToolCustomButton toolCustomButton6;
        private CustomForms.ToolCustomButton toolCustomButton1;
        private CustomForms.ToolCustomButton toolCustomButton2;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label6;
        private CustomForms.ToolCustomButton toolCustomButton9;
        private CustomForms.ToolCustomButton toolCustomButton10;
        private Label label5;
        private Label label7;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private ToolStripMenuItem aToolStripMenuItem1;
    }
}

