﻿namespace RayTracerGUI
{
    partial class OwnSceneWindow
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sceneWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sceneHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lightSamples = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.superSamples = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.recursionDepth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.indirectLightSamples = new System.Windows.Forms.TextBox();
            this.sceneOutputBT = new System.Windows.Forms.Button();
            this.imageOutputBT = new System.Windows.Forms.Button();
            this.saveRandomSceneBT = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(613, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // sceneOutput
            // 
            this.sceneOutput.Location = new System.Drawing.Point(237, 50);
            this.sceneOutput.Name = "sceneOutput";
            this.sceneOutput.Size = new System.Drawing.Size(185, 22);
            this.sceneOutput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scene output file name/path: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image output file name/path:";
            // 
            // imageOutput
            // 
            this.imageOutput.Location = new System.Drawing.Point(237, 81);
            this.imageOutput.Name = "imageOutput";
            this.imageOutput.Size = new System.Drawing.Size(185, 22);
            this.imageOutput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scene width (1-3840): ";
            // 
            // sceneWidth
            // 
            this.sceneWidth.Location = new System.Drawing.Point(237, 115);
            this.sceneWidth.Name = "sceneWidth";
            this.sceneWidth.Size = new System.Drawing.Size(100, 22);
            this.sceneWidth.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scene height (1-3840): ";
            // 
            // sceneHeight
            // 
            this.sceneHeight.Location = new System.Drawing.Point(237, 150);
            this.sceneHeight.Name = "sceneHeight";
            this.sceneHeight.Size = new System.Drawing.Size(100, 22);
            this.sceneHeight.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Light samples (1-128): ";
            // 
            // lightSamples
            // 
            this.lightSamples.Location = new System.Drawing.Point(237, 218);
            this.lightSamples.Name = "lightSamples";
            this.lightSamples.Size = new System.Drawing.Size(100, 22);
            this.lightSamples.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Super samples (1-8): ";
            // 
            // superSamples
            // 
            this.superSamples.Location = new System.Drawing.Point(237, 185);
            this.superSamples.Name = "superSamples";
            this.superSamples.Size = new System.Drawing.Size(100, 22);
            this.superSamples.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Max recursion depth (0-10): ";
            // 
            // recursionDepth
            // 
            this.recursionDepth.Location = new System.Drawing.Point(237, 288);
            this.recursionDepth.Name = "recursionDepth";
            this.recursionDepth.Size = new System.Drawing.Size(100, 22);
            this.recursionDepth.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Indirect light samples (1-128): ";
            // 
            // indirectLightSamples
            // 
            this.indirectLightSamples.Location = new System.Drawing.Point(237, 253);
            this.indirectLightSamples.Name = "indirectLightSamples";
            this.indirectLightSamples.Size = new System.Drawing.Size(100, 22);
            this.indirectLightSamples.TabIndex = 17;
            // 
            // sceneOutputBT
            // 
            this.sceneOutputBT.Location = new System.Drawing.Point(453, 49);
            this.sceneOutputBT.Name = "sceneOutputBT";
            this.sceneOutputBT.Size = new System.Drawing.Size(75, 23);
            this.sceneOutputBT.TabIndex = 21;
            this.sceneOutputBT.Text = "load";
            this.sceneOutputBT.UseVisualStyleBackColor = true;
            this.sceneOutputBT.Click += new System.EventHandler(this.sceneOutputBT_Click);
            // 
            // imageOutputBT
            // 
            this.imageOutputBT.Location = new System.Drawing.Point(453, 80);
            this.imageOutputBT.Name = "imageOutputBT";
            this.imageOutputBT.Size = new System.Drawing.Size(75, 23);
            this.imageOutputBT.TabIndex = 22;
            this.imageOutputBT.Text = "load";
            this.imageOutputBT.UseVisualStyleBackColor = true;
            // 
            // saveRandomSceneBT
            // 
            this.saveRandomSceneBT.Location = new System.Drawing.Point(511, 348);
            this.saveRandomSceneBT.Name = "saveRandomSceneBT";
            this.saveRandomSceneBT.Size = new System.Drawing.Size(75, 23);
            this.saveRandomSceneBT.TabIndex = 23;
            this.saveRandomSceneBT.Text = "Save";
            this.saveRandomSceneBT.UseVisualStyleBackColor = true;
            this.saveRandomSceneBT.Click += new System.EventHandler(this.SaveOwnSceneBT_Click);
            // 
            // OwnSceneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 394);
            this.Controls.Add(this.saveRandomSceneBT);
            this.Controls.Add(this.imageOutputBT);
            this.Controls.Add(this.sceneOutputBT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.recursionDepth);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.indirectLightSamples);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lightSamples);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.superSamples);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sceneHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sceneWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sceneOutput);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "OwnSceneWindow";
            this.RightToLeftLayout = true;
            this.Text = "Own scene window";
            this.Load += new System.EventHandler(this.SceneWindow_Load);
            this.Click += new System.EventHandler(this.imgOutputBT_Click);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox sceneOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imageOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sceneWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sceneHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lightSamples;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox superSamples;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox recursionDepth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox indirectLightSamples;
        private System.Windows.Forms.Button sceneOutputBT;
        private System.Windows.Forms.Button imageOutputBT;
        private System.Windows.Forms.Button saveRandomSceneBT;
    }
}