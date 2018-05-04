namespace RayTracerGUI
{
    partial class InitWindow
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
            this.LoadScene = new System.Windows.Forms.Button();
            this.CreateRandomScene = new System.Windows.Forms.Button();
            this.CreateOwnScene = new System.Windows.Forms.Button();
            this.cuboidBT = new System.Windows.Forms.Button();
            this.sphareBT = new System.Windows.Forms.Button();
            this.planeBT = new System.Windows.Forms.Button();
            this.stopRanderBT = new System.Windows.Forms.Button();
            this.startRanderBT = new System.Windows.Forms.Button();
            this.d2BT = new System.Windows.Forms.Button();
            this.imageView = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRandomSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOwnSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuboidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sphareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRanderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRanderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightBT = new System.Windows.Forms.Button();
            this.addLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadScene
            // 
            this.LoadScene.Location = new System.Drawing.Point(722, 34);
            this.LoadScene.Name = "LoadScene";
            this.LoadScene.Size = new System.Drawing.Size(162, 35);
            this.LoadScene.TabIndex = 0;
            this.LoadScene.Text = "Load scene";
            this.LoadScene.UseVisualStyleBackColor = true;
            this.LoadScene.Click += new System.EventHandler(this.SelectSceneButton_Click);
            // 
            // CreateRandomScene
            // 
            this.CreateRandomScene.Location = new System.Drawing.Point(386, 34);
            this.CreateRandomScene.Name = "CreateRandomScene";
            this.CreateRandomScene.Size = new System.Drawing.Size(162, 35);
            this.CreateRandomScene.TabIndex = 1;
            this.CreateRandomScene.Text = "Create random scene";
            this.CreateRandomScene.UseVisualStyleBackColor = true;
            this.CreateRandomScene.Click += new System.EventHandler(this.ShowRandomSceneWindow);
            // 
            // CreateOwnScene
            // 
            this.CreateOwnScene.Location = new System.Drawing.Point(554, 35);
            this.CreateOwnScene.Name = "CreateOwnScene";
            this.CreateOwnScene.Size = new System.Drawing.Size(162, 34);
            this.CreateOwnScene.TabIndex = 4;
            this.CreateOwnScene.Text = "Create own scene";
            this.CreateOwnScene.UseVisualStyleBackColor = true;
            // 
            // cuboidBT
            // 
            this.cuboidBT.Location = new System.Drawing.Point(26, 106);
            this.cuboidBT.Name = "cuboidBT";
            this.cuboidBT.Size = new System.Drawing.Size(162, 39);
            this.cuboidBT.TabIndex = 5;
            this.cuboidBT.Text = "Add Cuboid";
            this.cuboidBT.UseVisualStyleBackColor = true;
            // 
            // sphareBT
            // 
            this.sphareBT.Location = new System.Drawing.Point(26, 151);
            this.sphareBT.Name = "sphareBT";
            this.sphareBT.Size = new System.Drawing.Size(162, 39);
            this.sphareBT.TabIndex = 6;
            this.sphareBT.Text = "Add Sphare";
            this.sphareBT.UseVisualStyleBackColor = true;
            // 
            // planeBT
            // 
            this.planeBT.Location = new System.Drawing.Point(26, 196);
            this.planeBT.Name = "planeBT";
            this.planeBT.Size = new System.Drawing.Size(162, 39);
            this.planeBT.TabIndex = 7;
            this.planeBT.Text = "Add Plane";
            this.planeBT.UseVisualStyleBackColor = true;
            // 
            // stopRanderBT
            // 
            this.stopRanderBT.Location = new System.Drawing.Point(1061, 196);
            this.stopRanderBT.Name = "stopRanderBT";
            this.stopRanderBT.Size = new System.Drawing.Size(162, 39);
            this.stopRanderBT.TabIndex = 10;
            this.stopRanderBT.Text = "Stop randering";
            this.stopRanderBT.UseVisualStyleBackColor = true;
            this.stopRanderBT.Click += new System.EventHandler(this.button1_Click);
            // 
            // startRanderBT
            // 
            this.startRanderBT.Location = new System.Drawing.Point(1061, 151);
            this.startRanderBT.Name = "startRanderBT";
            this.startRanderBT.Size = new System.Drawing.Size(162, 39);
            this.startRanderBT.TabIndex = 9;
            this.startRanderBT.Text = "Start randering";
            this.startRanderBT.UseVisualStyleBackColor = true;
            this.startRanderBT.Click += new System.EventHandler(this.button2_Click);
            // 
            // d2BT
            // 
            this.d2BT.Location = new System.Drawing.Point(1061, 106);
            this.d2BT.Name = "d2BT";
            this.d2BT.Size = new System.Drawing.Size(162, 39);
            this.d2BT.TabIndex = 8;
            this.d2BT.Text = "2D";
            this.d2BT.UseVisualStyleBackColor = true;
            this.d2BT.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageView
            // 
            this.imageView.Location = new System.Drawing.Point(276, 95);
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(739, 454);
            this.imageView.TabIndex = 11;
            this.imageView.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.objectsToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1253, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRandomSceneToolStripMenuItem,
            this.createOwnSceneToolStripMenuItem,
            this.loadSceneToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createRandomSceneToolStripMenuItem
            // 
            this.createRandomSceneToolStripMenuItem.Name = "createRandomSceneToolStripMenuItem";
            this.createRandomSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createRandomSceneToolStripMenuItem.Text = "Create random scene";
            // 
            // createOwnSceneToolStripMenuItem
            // 
            this.createOwnSceneToolStripMenuItem.Name = "createOwnSceneToolStripMenuItem";
            this.createOwnSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createOwnSceneToolStripMenuItem.Text = "Create own scene";
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadSceneToolStripMenuItem.Text = "Load scene";
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuboidToolStripMenuItem,
            this.sphareToolStripMenuItem,
            this.planeToolStripMenuItem,
            this.addLightToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.objectsToolStripMenuItem.Text = "Objects";
            // 
            // cuboidToolStripMenuItem
            // 
            this.cuboidToolStripMenuItem.Name = "cuboidToolStripMenuItem";
            this.cuboidToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cuboidToolStripMenuItem.Text = "Add Cuboid";
            // 
            // sphareToolStripMenuItem
            // 
            this.sphareToolStripMenuItem.Name = "sphareToolStripMenuItem";
            this.sphareToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sphareToolStripMenuItem.Text = "Add Sphare";
            this.sphareToolStripMenuItem.Click += new System.EventHandler(this.sphareToolStripMenuItem_Click);
            // 
            // planeToolStripMenuItem
            // 
            this.planeToolStripMenuItem.Name = "planeToolStripMenuItem";
            this.planeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.planeToolStripMenuItem.Text = "Add Plane";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dViewToolStripMenuItem,
            this.startRanderingToolStripMenuItem,
            this.stopRanderingToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // dViewToolStripMenuItem
            // 
            this.dViewToolStripMenuItem.Name = "dViewToolStripMenuItem";
            this.dViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.dViewToolStripMenuItem.Text = "2D View";
            // 
            // startRanderingToolStripMenuItem
            // 
            this.startRanderingToolStripMenuItem.Name = "startRanderingToolStripMenuItem";
            this.startRanderingToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.startRanderingToolStripMenuItem.Text = "Start randering";
            // 
            // stopRanderingToolStripMenuItem
            // 
            this.stopRanderingToolStripMenuItem.Name = "stopRanderingToolStripMenuItem";
            this.stopRanderingToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.stopRanderingToolStripMenuItem.Text = "Stop randering";
            // 
            // lightBT
            // 
            this.lightBT.Location = new System.Drawing.Point(26, 241);
            this.lightBT.Name = "lightBT";
            this.lightBT.Size = new System.Drawing.Size(162, 39);
            this.lightBT.TabIndex = 13;
            this.lightBT.Text = "Add Light";
            this.lightBT.UseVisualStyleBackColor = true;
            // 
            // addLightToolStripMenuItem
            // 
            this.addLightToolStripMenuItem.Name = "addLightToolStripMenuItem";
            this.addLightToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addLightToolStripMenuItem.Text = "Add Light";
            // 
            // InitWindow
            // 
            this.ClientSize = new System.Drawing.Size(1253, 672);
            this.Controls.Add(this.lightBT);
            this.Controls.Add(this.imageView);
            this.Controls.Add(this.stopRanderBT);
            this.Controls.Add(this.startRanderBT);
            this.Controls.Add(this.d2BT);
            this.Controls.Add(this.planeBT);
            this.Controls.Add(this.sphareBT);
            this.Controls.Add(this.cuboidBT);
            this.Controls.Add(this.CreateOwnScene);
            this.Controls.Add(this.CreateRandomScene);
            this.Controls.Add(this.LoadScene);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InitWindow";
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button LoadScene;
        private System.Windows.Forms.Button CreateRandomScene;
        private System.Windows.Forms.Button CreateOwnScene;
        private System.Windows.Forms.Button cuboidBT;
        private System.Windows.Forms.Button sphareBT;
        private System.Windows.Forms.Button planeBT;
        private System.Windows.Forms.Button stopRanderBT;
        private System.Windows.Forms.Button startRanderBT;
        private System.Windows.Forms.Button d2BT;
        private System.Windows.Forms.PictureBox imageView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRandomSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOwnSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuboidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sphareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRanderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRanderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLightToolStripMenuItem;
        private System.Windows.Forms.Button lightBT;
    }
}

