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
            this.components = new System.ComponentModel.Container();
            this.LoadSceneBT = new System.Windows.Forms.Button();
            this.CreateRandomSceneBT = new System.Windows.Forms.Button();
            this.SaveSceneBT = new System.Windows.Forms.Button();
            this.cuboidBT = new System.Windows.Forms.Button();
            this.sphareBT = new System.Windows.Forms.Button();
            this.stopRanderBT = new System.Windows.Forms.Button();
            this.startRanderBT = new System.Windows.Forms.Button();
            this.d2ViewBT = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRandomSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOwnSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startRanderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRanderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuboidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sphareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightBT = new System.Windows.Forms.Button();
            this.d3ViewBT = new System.Windows.Forms.Button();
            this.CreateOwnSceneBT = new System.Windows.Forms.Button();
            this.canvas2D1 = new RayTracerGUI.Canvas2D();
            this.sceneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inputFormControlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageControlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EditSceneBT = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sceneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFormControlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageControlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadSceneBT
            // 
            this.LoadSceneBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadSceneBT.Location = new System.Drawing.Point(883, 46);
            this.LoadSceneBT.Name = "LoadSceneBT";
            this.LoadSceneBT.Size = new System.Drawing.Size(162, 35);
            this.LoadSceneBT.TabIndex = 0;
            this.LoadSceneBT.Text = "Load Scene";
            this.LoadSceneBT.UseVisualStyleBackColor = true;
            this.LoadSceneBT.Click += new System.EventHandler(this.LoadSceneButton_Click);
            // 
            // CreateRandomSceneBT
            // 
            this.CreateRandomSceneBT.Location = new System.Drawing.Point(231, 46);
            this.CreateRandomSceneBT.Name = "CreateRandomSceneBT";
            this.CreateRandomSceneBT.Size = new System.Drawing.Size(162, 35);
            this.CreateRandomSceneBT.TabIndex = 1;
            this.CreateRandomSceneBT.Text = "Create Random Scene";
            this.CreateRandomSceneBT.UseVisualStyleBackColor = true;
            this.CreateRandomSceneBT.Click += new System.EventHandler(this.ShowRandomSceneWindow);
            // 
            // SaveSceneBT
            // 
            this.SaveSceneBT.Location = new System.Drawing.Point(715, 46);
            this.SaveSceneBT.Name = "SaveSceneBT";
            this.SaveSceneBT.Size = new System.Drawing.Size(162, 34);
            this.SaveSceneBT.TabIndex = 4;
            this.SaveSceneBT.Text = "Save Scene";
            this.SaveSceneBT.UseVisualStyleBackColor = true;
            this.SaveSceneBT.Click += new System.EventHandler(this.SaveSceneBT_Click);
            // 
            // cuboidBT
            // 
            this.cuboidBT.Location = new System.Drawing.Point(26, 106);
            this.cuboidBT.Name = "cuboidBT";
            this.cuboidBT.Size = new System.Drawing.Size(162, 39);
            this.cuboidBT.TabIndex = 5;
            this.cuboidBT.Text = "Add Cuboid";
            this.cuboidBT.UseVisualStyleBackColor = true;
            this.cuboidBT.Click += new System.EventHandler(this.AddCuboidBT_Click);
            // 
            // sphareBT
            // 
            this.sphareBT.Location = new System.Drawing.Point(26, 151);
            this.sphareBT.Name = "sphareBT";
            this.sphareBT.Size = new System.Drawing.Size(162, 39);
            this.sphareBT.TabIndex = 6;
            this.sphareBT.Text = "Add Sphare";
            this.sphareBT.UseVisualStyleBackColor = true;
            this.sphareBT.Click += new System.EventHandler(this.AddSphareBT_Click);
            // 
            // stopRanderBT
            // 
            this.stopRanderBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopRanderBT.Location = new System.Drawing.Point(1061, 308);
            this.stopRanderBT.Name = "stopRanderBT";
            this.stopRanderBT.Size = new System.Drawing.Size(162, 39);
            this.stopRanderBT.TabIndex = 10;
            this.stopRanderBT.Text = "Stop randering";
            this.stopRanderBT.UseVisualStyleBackColor = true;
            this.stopRanderBT.Click += new System.EventHandler(this.StopRenderingBT_Click);
            // 
            // startRanderBT
            // 
            this.startRanderBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startRanderBT.Location = new System.Drawing.Point(1061, 263);
            this.startRanderBT.Name = "startRanderBT";
            this.startRanderBT.Size = new System.Drawing.Size(162, 39);
            this.startRanderBT.TabIndex = 9;
            this.startRanderBT.Text = "Start randering";
            this.startRanderBT.UseVisualStyleBackColor = true;
            this.startRanderBT.Click += new System.EventHandler(this.StartRenderingBT_Click);
            // 
            // d2ViewBT
            // 
            this.d2ViewBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d2ViewBT.Location = new System.Drawing.Point(1061, 106);
            this.d2ViewBT.Name = "d2ViewBT";
            this.d2ViewBT.Size = new System.Drawing.Size(162, 39);
            this.d2ViewBT.TabIndex = 8;
            this.d2ViewBT.Text = "2D View";
            this.d2ViewBT.UseVisualStyleBackColor = true;
            this.d2ViewBT.Click += new System.EventHandler(this.Show2DSceneClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.objectsToolStripMenuItem});
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
            this.editSceneToolStripMenuItem,
            this.loadSceneToolStripMenuItem,
            this.saveSceneToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createRandomSceneToolStripMenuItem
            // 
            this.createRandomSceneToolStripMenuItem.Name = "createRandomSceneToolStripMenuItem";
            this.createRandomSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createRandomSceneToolStripMenuItem.Text = "Create random scene";
            this.createRandomSceneToolStripMenuItem.Click += new System.EventHandler(this.CreateRandomSceneToolStripMenuItem_Click);
            // 
            // createOwnSceneToolStripMenuItem
            // 
            this.createOwnSceneToolStripMenuItem.Name = "createOwnSceneToolStripMenuItem";
            this.createOwnSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createOwnSceneToolStripMenuItem.Text = "Create own scene";
            this.createOwnSceneToolStripMenuItem.Click += new System.EventHandler(this.CreateOwnSceneToolStripMenuItem_Click);
            // 
            // editSceneToolStripMenuItem
            // 
            this.editSceneToolStripMenuItem.Name = "editSceneToolStripMenuItem";
            this.editSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.editSceneToolStripMenuItem.Text = "Edit scene";
            this.editSceneToolStripMenuItem.Click += new System.EventHandler(this.EditSceneToolStripMenuItem_Click);
            // 
            // loadSceneToolStripMenuItem
            // 
            this.loadSceneToolStripMenuItem.Name = "loadSceneToolStripMenuItem";
            this.loadSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadSceneToolStripMenuItem.Text = "Load scene";
            this.loadSceneToolStripMenuItem.Click += new System.EventHandler(this.LoadSceneToolStripMenuItem_Click);
            // 
            // saveSceneToolStripMenuItem
            // 
            this.saveSceneToolStripMenuItem.Name = "saveSceneToolStripMenuItem";
            this.saveSceneToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveSceneToolStripMenuItem.Text = "Save scene";
            this.saveSceneToolStripMenuItem.Click += new System.EventHandler(this.SaveSceneToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dViewToolStripMenuItem,
            this.dViewToolStripMenuItem1,
            this.startRanderingToolStripMenuItem,
            this.stopRanderingToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // dViewToolStripMenuItem
            // 
            this.dViewToolStripMenuItem.Name = "dViewToolStripMenuItem";
            this.dViewToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.dViewToolStripMenuItem.Text = "2D View";
            this.dViewToolStripMenuItem.Click += new System.EventHandler(this.Show2DSceneClick);
            // 
            // dViewToolStripMenuItem1
            // 
            this.dViewToolStripMenuItem1.Name = "dViewToolStripMenuItem1";
            this.dViewToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.dViewToolStripMenuItem1.Text = "3D View";
            this.dViewToolStripMenuItem1.Click += new System.EventHandler(this.D3ViewBT_Click);
            // 
            // startRanderingToolStripMenuItem
            // 
            this.startRanderingToolStripMenuItem.Name = "startRanderingToolStripMenuItem";
            this.startRanderingToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.startRanderingToolStripMenuItem.Text = "Start randering";
            this.startRanderingToolStripMenuItem.Click += new System.EventHandler(this.StartRenderingBT_Click);
            // 
            // stopRanderingToolStripMenuItem
            // 
            this.stopRanderingToolStripMenuItem.Name = "stopRanderingToolStripMenuItem";
            this.stopRanderingToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.stopRanderingToolStripMenuItem.Text = "Stop randering";
            this.stopRanderingToolStripMenuItem.Click += new System.EventHandler(this.StopRenderingBT_Click);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuboidToolStripMenuItem,
            this.sphareToolStripMenuItem,
            this.addLightToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.objectsToolStripMenuItem.Text = "Objects";
            // 
            // cuboidToolStripMenuItem
            // 
            this.cuboidToolStripMenuItem.Name = "cuboidToolStripMenuItem";
            this.cuboidToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.cuboidToolStripMenuItem.Text = "Add Cuboid";
            this.cuboidToolStripMenuItem.Click += new System.EventHandler(this.AddCuboidBT_Click);
            // 
            // sphareToolStripMenuItem
            // 
            this.sphareToolStripMenuItem.Name = "sphareToolStripMenuItem";
            this.sphareToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.sphareToolStripMenuItem.Text = "Add Sphare";
            this.sphareToolStripMenuItem.Click += new System.EventHandler(this.AddSphareBT_Click);
            // 
            // addLightToolStripMenuItem
            // 
            this.addLightToolStripMenuItem.Name = "addLightToolStripMenuItem";
            this.addLightToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.addLightToolStripMenuItem.Text = "Add Light";
            this.addLightToolStripMenuItem.Click += new System.EventHandler(this.AddLightBT_Click);
            // 
            // lightBT
            // 
            this.lightBT.Location = new System.Drawing.Point(26, 196);
            this.lightBT.Name = "lightBT";
            this.lightBT.Size = new System.Drawing.Size(162, 39);
            this.lightBT.TabIndex = 13;
            this.lightBT.Text = "Add Light";
            this.lightBT.UseVisualStyleBackColor = true;
            this.lightBT.Click += new System.EventHandler(this.AddLightBT_Click);
            // 
            // d3ViewBT
            // 
            this.d3ViewBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d3ViewBT.Location = new System.Drawing.Point(1061, 151);
            this.d3ViewBT.Name = "d3ViewBT";
            this.d3ViewBT.Size = new System.Drawing.Size(162, 39);
            this.d3ViewBT.TabIndex = 14;
            this.d3ViewBT.Text = "3D View";
            this.d3ViewBT.UseVisualStyleBackColor = true;
            this.d3ViewBT.Click += new System.EventHandler(this.D3ViewBT_Click);
            // 
            // CreateOwnSceneBT
            // 
            this.CreateOwnSceneBT.Location = new System.Drawing.Point(399, 46);
            this.CreateOwnSceneBT.Name = "CreateOwnSceneBT";
            this.CreateOwnSceneBT.Size = new System.Drawing.Size(162, 35);
            this.CreateOwnSceneBT.TabIndex = 16;
            this.CreateOwnSceneBT.Text = "Create Own Scene";
            this.CreateOwnSceneBT.UseVisualStyleBackColor = true;
            this.CreateOwnSceneBT.Click += new System.EventHandler(this.CreateOwnSceneBT_Click);
            // 
            // canvas2D1
            // 
            this.canvas2D1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas2D1.BackColor = System.Drawing.Color.AliceBlue;
            this.canvas2D1.Camera = null;
            this.canvas2D1.ChooseShape = null;
            this.canvas2D1.ImageControler = null;
            this.canvas2D1.InputFormControler = null;
            this.canvas2D1.Location = new System.Drawing.Point(231, 87);
            this.canvas2D1.Name = "canvas2D1";
            this.canvas2D1.Size = new System.Drawing.Size(814, 573);
            this.canvas2D1.TabIndex = 15;
            this.canvas2D1.Text = "canvas2D";
            // 
            // sceneBindingSource
            // 
            this.sceneBindingSource.DataSource = typeof(RayTracer.Scene);
            // 
            // inputFormControlerBindingSource
            // 
            this.inputFormControlerBindingSource.DataSource = typeof(RayTracerGUI.Controlers.InputFormControler);
            // 
            // imageControlerBindingSource
            // 
            this.imageControlerBindingSource.DataSource = typeof(RayTracerGUI.Controlers.ImageControler);
            // 
            // EditSceneBT
            // 
            this.EditSceneBT.Location = new System.Drawing.Point(567, 46);
            this.EditSceneBT.Name = "EditSceneBT";
            this.EditSceneBT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EditSceneBT.Size = new System.Drawing.Size(102, 35);
            this.EditSceneBT.TabIndex = 17;
            this.EditSceneBT.Text = "Edit scene";
            this.EditSceneBT.UseVisualStyleBackColor = true;
            this.EditSceneBT.Click += new System.EventHandler(this.EditScene_Click);
            // 
            // InitWindow
            // 
            this.ClientSize = new System.Drawing.Size(1253, 672);
            this.Controls.Add(this.EditSceneBT);
            this.Controls.Add(this.CreateOwnSceneBT);
            this.Controls.Add(this.canvas2D1);
            this.Controls.Add(this.d3ViewBT);
            this.Controls.Add(this.lightBT);
            this.Controls.Add(this.stopRanderBT);
            this.Controls.Add(this.startRanderBT);
            this.Controls.Add(this.d2ViewBT);
            this.Controls.Add(this.sphareBT);
            this.Controls.Add(this.cuboidBT);
            this.Controls.Add(this.SaveSceneBT);
            this.Controls.Add(this.CreateRandomSceneBT);
            this.Controls.Add(this.LoadSceneBT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InitWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sceneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFormControlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageControlerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button LoadSceneBT;
        private System.Windows.Forms.Button CreateRandomSceneBT;
        private System.Windows.Forms.Button SaveSceneBT;
        private System.Windows.Forms.Button cuboidBT;
        private System.Windows.Forms.Button sphareBT;
        private System.Windows.Forms.Button stopRanderBT;
        private System.Windows.Forms.Button startRanderBT;
        private System.Windows.Forms.Button d2ViewBT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRandomSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOwnSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuboidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sphareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRanderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRanderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLightToolStripMenuItem;
        private System.Windows.Forms.Button lightBT;
        private System.Windows.Forms.Button d3ViewBT;
        private Canvas2D canvas2D1;
        private System.Windows.Forms.Button CreateOwnSceneBT;
        private System.Windows.Forms.BindingSource sceneBindingSource;
        private System.Windows.Forms.BindingSource imageControlerBindingSource;
        private System.Windows.Forms.BindingSource inputFormControlerBindingSource;
        private System.Windows.Forms.Button EditSceneBT;
        private System.Windows.Forms.ToolStripMenuItem editSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem1;
    }
}

