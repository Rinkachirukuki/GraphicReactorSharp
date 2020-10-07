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
            this.MainPicBox = new System.Windows.Forms.PictureBox();
            this.mainPicBox_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToolSelect = new GraphicReactor.CustomForms.ToolCustomButton();
            this.buttonToolMove = new GraphicReactor.CustomForms.ToolCustomButton();
            this.buttonToolView = new GraphicReactor.CustomForms.ToolCustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).BeginInit();
            this.mainPicBox_ContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPicBox
            // 
            this.MainPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainPicBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainPicBox.Location = new System.Drawing.Point(59, 1);
            this.MainPicBox.Name = "MainPicBox";
            this.MainPicBox.Size = new System.Drawing.Size(656, 439);
            this.MainPicBox.TabIndex = 1;
            this.MainPicBox.TabStop = false;
            this.MainPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseDown);
            this.MainPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseMove);
            this.MainPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPicBox_MouseUp);
            // 
            // mainPicBox_ContextMenu
            // 
            this.mainPicBox_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.createGroupToolStripMenuItem});
            this.mainPicBox_ContextMenu.Name = "contextMenuStrip1";
            this.mainPicBox_ContextMenu.Size = new System.Drawing.Size(145, 70);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.aToolStripMenuItem.Text = "Add";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.aToolStripMenuItem1.Text = "Delete";
            // 
            // createGroupToolStripMenuItem
            // 
            this.createGroupToolStripMenuItem.Name = "createGroupToolStripMenuItem";
            this.createGroupToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.createGroupToolStripMenuItem.Text = "Create Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonToolSelect);
            this.panel1.Controls.Add(this.buttonToolMove);
            this.panel1.Controls.Add(this.buttonToolView);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 439);
            this.panel1.TabIndex = 4;
            // 
            // buttonToolSelect
            // 
            this.buttonToolSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToolSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToolSelect.Location = new System.Drawing.Point(4, 63);
            this.buttonToolSelect.Name = "buttonToolSelect";
            this.buttonToolSelect.Size = new System.Drawing.Size(49, 23);
            this.buttonToolSelect.TabIndex = 8;
            this.buttonToolSelect.Text = "Select";
            this.buttonToolSelect.UseVisualStyleBackColor = true;
            this.buttonToolSelect.Click += new System.EventHandler(this.buttonToolSelect_Click);
            // 
            // buttonToolMove
            // 
            this.buttonToolMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToolMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToolMove.Location = new System.Drawing.Point(4, 33);
            this.buttonToolMove.Name = "buttonToolMove";
            this.buttonToolMove.Size = new System.Drawing.Size(49, 23);
            this.buttonToolMove.TabIndex = 7;
            this.buttonToolMove.Text = "Move";
            this.buttonToolMove.UseVisualStyleBackColor = true;
            this.buttonToolMove.Click += new System.EventHandler(this.buttonToolMove_Click);
            // 
            // buttonToolView
            // 
            this.buttonToolView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToolView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToolView.Location = new System.Drawing.Point(4, 3);
            this.buttonToolView.Name = "buttonToolView";
            this.buttonToolView.Size = new System.Drawing.Size(49, 23);
            this.buttonToolView.TabIndex = 6;
            this.buttonToolView.Text = "View";
            this.buttonToolView.UseVisualStyleBackColor = true;
            this.buttonToolView.Click += new System.EventHandler(this.buttonToolView_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainPicBox);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GR_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GR_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).EndInit();
            this.mainPicBox_ContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicBox;
        private System.Windows.Forms.ContextMenuStrip mainPicBox_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createGroupToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CustomForms.ToolCustomButton buttonToolView;
        private CustomForms.ToolCustomButton buttonToolSelect;
        private CustomForms.ToolCustomButton buttonToolMove;
    }
}

