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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Points");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Groups");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainPicBox_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.MainPicBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PropetiesPanel = new System.Windows.Forms.Panel();
            this.CheckBoxRelCenter = new GraphicReactor.CustomForms.ToolCustomCheckBox();
            this.Zc_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Zc_DecreaseButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.Zc_IncreaseButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.label6 = new System.Windows.Forms.Label();
            this.compLinesCheckBox = new GraphicReactor.CustomForms.ToolCustomCheckBox();
            this.resizeModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.rotationModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.moveModeButton = new GraphicReactor.CustomForms.ToolCustomButton();
            this.propetiesTabControl = new GraphicReactor.CustomForms.ToolCustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupsTreeView = new GraphicReactor.CustomForms.ToolCustomTreeView();
            this.mainPicBox_ContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).BeginInit();
            this.PropetiesPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.propetiesTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPicBox_ContextMenu
            // 
            this.mainPicBox_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.createGroupToolStripMenuItem,
            this.toolStripMenuItem2});
            this.mainPicBox_ContextMenu.Name = "contextMenuStrip1";
            this.mainPicBox_ContextMenu.Size = new System.Drawing.Size(175, 92);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aToolStripMenuItem.Text = "Add";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.aToolStripMenuItem1.Text = "Delete";
            this.aToolStripMenuItem1.Click += new System.EventHandler(this.aToolStripMenuItem1_Click);
            // 
            // createGroupToolStripMenuItem
            // 
            this.createGroupToolStripMenuItem.Name = "createGroupToolStripMenuItem";
            this.createGroupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createGroupToolStripMenuItem.Text = "Create Group";
            this.createGroupToolStripMenuItem.Click += new System.EventHandler(this.createGroupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItem2.Text = "Transform selected";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem1,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem});
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.xToolStripMenuItem.Text = "Reflect";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(81, 22);
            this.xToolStripMenuItem1.Text = "X";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.zToolStripMenuItem.Text = "Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.resetButton);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 455);
            this.panel1.TabIndex = 4;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetButton.Location = new System.Drawing.Point(3, 429);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(49, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // MainPicBox
            // 
            this.MainPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainPicBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainPicBox.Location = new System.Drawing.Point(59, 1);
            this.MainPicBox.Name = "MainPicBox";
            this.MainPicBox.Size = new System.Drawing.Size(474, 454);
            this.MainPicBox.TabIndex = 1;
            this.MainPicBox.TabStop = false;
            this.MainPicBox.SizeChanged += new System.EventHandler(this.MainPicBox_SizeChanged);
            this.MainPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseDown);
            this.MainPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseMove);
            this.MainPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(7, 36);
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
            this.label3.Location = new System.Drawing.Point(60, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // PropetiesPanel
            // 
            this.PropetiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PropetiesPanel.Controls.Add(this.CheckBoxRelCenter);
            this.PropetiesPanel.Location = new System.Drawing.Point(3, 61);
            this.PropetiesPanel.Name = "PropetiesPanel";
            this.PropetiesPanel.Size = new System.Drawing.Size(166, 128);
            this.PropetiesPanel.TabIndex = 8;
            // 
            // CheckBoxRelCenter
            // 
            this.CheckBoxRelCenter.AutoSize = true;
            this.CheckBoxRelCenter.Checked = true;
            this.CheckBoxRelCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxRelCenter.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxRelCenter.Name = "CheckBoxRelCenter";
            this.CheckBoxRelCenter.Size = new System.Drawing.Size(128, 17);
            this.CheckBoxRelCenter.TabIndex = 7;
            this.CheckBoxRelCenter.Text = "Relative to the center";
            this.CheckBoxRelCenter.UseVisualStyleBackColor = true;
            // 
            // Zc_label
            // 
            this.Zc_label.AutoSize = true;
            this.Zc_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zc_label.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Zc_label.Location = new System.Drawing.Point(5, 24);
            this.Zc_label.Name = "Zc_label";
            this.Zc_label.Size = new System.Drawing.Size(51, 20);
            this.Zc_label.TabIndex = 15;
            this.Zc_label.Text = "label4";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(112, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Vanishing point";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Zc_label);
            this.panel2.Controls.Add(this.Zc_DecreaseButton);
            this.panel2.Controls.Add(this.Zc_IncreaseButton);
            this.panel2.Location = new System.Drawing.Point(3, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 77);
            this.panel2.TabIndex = 17;
            // 
            // Zc_DecreaseButton
            // 
            this.Zc_DecreaseButton.Location = new System.Drawing.Point(4, 51);
            this.Zc_DecreaseButton.Name = "Zc_DecreaseButton";
            this.Zc_DecreaseButton.Size = new System.Drawing.Size(78, 23);
            this.Zc_DecreaseButton.TabIndex = 14;
            this.Zc_DecreaseButton.Text = "-100";
            this.Zc_DecreaseButton.UseVisualStyleBackColor = true;
            this.Zc_DecreaseButton.Click += new System.EventHandler(this.Zc_DecreaseButton_Click);
            // 
            // Zc_IncreaseButton
            // 
            this.Zc_IncreaseButton.Location = new System.Drawing.Point(84, 51);
            this.Zc_IncreaseButton.Name = "Zc_IncreaseButton";
            this.Zc_IncreaseButton.Size = new System.Drawing.Size(78, 23);
            this.Zc_IncreaseButton.TabIndex = 13;
            this.Zc_IncreaseButton.Text = "+100";
            this.Zc_IncreaseButton.UseVisualStyleBackColor = true;
            this.Zc_IncreaseButton.Click += new System.EventHandler(this.Zc_IncreaseButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Selected Points";
            // 
            // compLinesCheckBox
            // 
            this.compLinesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compLinesCheckBox.AutoSize = true;
            this.compLinesCheckBox.Location = new System.Drawing.Point(5, 408);
            this.compLinesCheckBox.Name = "compLinesCheckBox";
            this.compLinesCheckBox.Size = new System.Drawing.Size(112, 17);
            this.compLinesCheckBox.TabIndex = 8;
            this.compLinesCheckBox.Text = "Complicated Lines";
            this.compLinesCheckBox.UseVisualStyleBackColor = true;
            this.compLinesCheckBox.CheckedChanged += new System.EventHandler(this.compLinesCheckBox_CheckedChanged);
            // 
            // resizeModeButton
            // 
            this.resizeModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resizeModeButton.BackColor = System.Drawing.Color.Transparent;
            this.resizeModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSeaGreen;
            this.resizeModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.resizeModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.resizeModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resizeModeButton.Location = new System.Drawing.Point(482, 6);
            this.resizeModeButton.Name = "resizeModeButton";
            this.resizeModeButton.Size = new System.Drawing.Size(44, 23);
            this.resizeModeButton.TabIndex = 11;
            this.resizeModeButton.Text = "Resize";
            this.resizeModeButton.UseVisualStyleBackColor = false;
            this.resizeModeButton.Click += new System.EventHandler(this.resizeModeButton_Click);
            // 
            // rotationModeButton
            // 
            this.rotationModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationModeButton.BackColor = System.Drawing.Color.Transparent;
            this.rotationModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSeaGreen;
            this.rotationModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.rotationModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.rotationModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotationModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotationModeButton.Location = new System.Drawing.Point(435, 6);
            this.rotationModeButton.Name = "rotationModeButton";
            this.rotationModeButton.Size = new System.Drawing.Size(44, 23);
            this.rotationModeButton.TabIndex = 9;
            this.rotationModeButton.Text = "Rotate";
            this.rotationModeButton.UseVisualStyleBackColor = false;
            this.rotationModeButton.Click += new System.EventHandler(this.rotationModeButton_Click);
            // 
            // moveModeButton
            // 
            this.moveModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveModeButton.BackColor = System.Drawing.SystemColors.Control;
            this.moveModeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSeaGreen;
            this.moveModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.moveModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.moveModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moveModeButton.Location = new System.Drawing.Point(388, 6);
            this.moveModeButton.Name = "moveModeButton";
            this.moveModeButton.Size = new System.Drawing.Size(44, 23);
            this.moveModeButton.TabIndex = 10;
            this.moveModeButton.Text = "Move";
            this.moveModeButton.UseVisualStyleBackColor = false;
            this.moveModeButton.Click += new System.EventHandler(this.moveModeButton_Click);
            // 
            // propetiesTabControl
            // 
            this.propetiesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propetiesTabControl.Controls.Add(this.tabPage1);
            this.propetiesTabControl.Controls.Add(this.tabPage2);
            this.propetiesTabControl.Location = new System.Drawing.Point(535, 1);
            this.propetiesTabControl.Name = "propetiesTabControl";
            this.propetiesTabControl.SelectedIndex = 0;
            this.propetiesTabControl.Size = new System.Drawing.Size(180, 455);
            this.propetiesTabControl.TabIndex = 19;
            this.propetiesTabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.propetiesTabControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.compLinesCheckBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.PropetiesPanel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(172, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupsTreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(172, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupsTreeView
            // 
            this.groupsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupsTreeView.CheckBoxes = true;
            this.groupsTreeView.Location = new System.Drawing.Point(0, 0);
            this.groupsTreeView.Name = "groupsTreeView";
            treeNode1.BackColor = System.Drawing.Color.Transparent;
            treeNode1.ForeColor = System.Drawing.Color.DarkSlateGray;
            treeNode1.Name = "Points";
            treeNode1.Text = "Points";
            treeNode2.Name = "Groups";
            treeNode2.Text = "Groups";
            this.groupsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.groupsTreeView.Size = new System.Drawing.Size(172, 297);
            this.groupsTreeView.TabIndex = 1;
            this.groupsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.groupsTreeView_AfterCheck);
            this.groupsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupsTreeView_AfterSelect);
            this.groupsTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.groupsTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 458);
            this.Controls.Add(this.propetiesTabControl);
            this.Controls.Add(this.resizeModeButton);
            this.Controls.Add(this.rotationModeButton);
            this.Controls.Add(this.moveModeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainPicBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(524, 313);
            this.Name = "MainWindow";
            this.Text = "Reactor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            this.mainPicBox_ContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).EndInit();
            this.PropetiesPanel.ResumeLayout(false);
            this.PropetiesPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.propetiesTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip mainPicBox_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createGroupToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox MainPicBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomForms.ToolCustomButton resetButton;
        private CustomForms.ToolCustomCheckBox CheckBoxRelCenter;
        private Panel PropetiesPanel;
        private CustomForms.ToolCustomButton resizeModeButton;
        private CustomForms.ToolCustomButton rotationModeButton;
        private CustomForms.ToolCustomButton moveModeButton;
        private CustomForms.ToolCustomCheckBox compLinesCheckBox;
        private Label Zc_label;
        private CustomForms.ToolCustomButton Zc_DecreaseButton;
        private CustomForms.ToolCustomButton Zc_IncreaseButton;
        private Label label4;
        private Label label5;
        private Panel panel2;
        private Label label6;
        private CustomForms.ToolCustomTabControl propetiesTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CustomForms.ToolCustomTreeView groupsTreeView;
    }
}

