﻿namespace RayTracerGUI
{
    partial class CuboidEditWindow
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
            this.CuboudEditLB = new System.Windows.Forms.Label();
            this.CoordX = new System.Windows.Forms.Label();
            this.CoordY = new System.Windows.Forms.Label();
            this.CoordZ = new System.Windows.Forms.Label();
            this.CoordXTB = new System.Windows.Forms.TextBox();
            this.CoordYTB = new System.Windows.Forms.TextBox();
            this.CoordZTB = new System.Windows.Forms.TextBox();
            this.DepthTB = new System.Windows.Forms.TextBox();
            this.HeightTB = new System.Windows.Forms.TextBox();
            this.WidthTB = new System.Windows.Forms.TextBox();
            this.DepthLB = new System.Windows.Forms.Label();
            this.HeightLB = new System.Windows.Forms.Label();
            this.WidthLB = new System.Windows.Forms.Label();
            this.MaterialBT = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SaveBTEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CuboudEditLB
            // 
            this.CuboudEditLB.AutoSize = true;
            this.CuboudEditLB.Location = new System.Drawing.Point(167, 21);
            this.CuboudEditLB.Name = "CuboudEditLB";
            this.CuboudEditLB.Size = new System.Drawing.Size(111, 17);
            this.CuboudEditLB.TabIndex = 0;
            this.CuboudEditLB.Text = "Cuboid Editation";
            // 
            // CoordX
            // 
            this.CoordX.AutoSize = true;
            this.CoordX.Location = new System.Drawing.Point(40, 97);
            this.CoordX.Name = "CoordX";
            this.CoordX.Size = new System.Drawing.Size(63, 17);
            this.CoordX.TabIndex = 1;
            this.CoordX.Text = "Coord X:";
            // 
            // CoordY
            // 
            this.CoordY.AutoSize = true;
            this.CoordY.Location = new System.Drawing.Point(40, 128);
            this.CoordY.Name = "CoordY";
            this.CoordY.Size = new System.Drawing.Size(63, 17);
            this.CoordY.TabIndex = 2;
            this.CoordY.Text = "Coord Y:";
            // 
            // CoordZ
            // 
            this.CoordZ.AutoSize = true;
            this.CoordZ.Location = new System.Drawing.Point(40, 159);
            this.CoordZ.Name = "CoordZ";
            this.CoordZ.Size = new System.Drawing.Size(67, 17);
            this.CoordZ.TabIndex = 3;
            this.CoordZ.Text = "Coord Z: ";
            // 
            // CoordXTB
            // 
            this.CoordXTB.Location = new System.Drawing.Point(109, 92);
            this.CoordXTB.Name = "CoordXTB";
            this.CoordXTB.Size = new System.Drawing.Size(222, 22);
            this.CoordXTB.TabIndex = 4;
            // 
            // CoordYTB
            // 
            this.CoordYTB.Location = new System.Drawing.Point(109, 123);
            this.CoordYTB.Name = "CoordYTB";
            this.CoordYTB.Size = new System.Drawing.Size(222, 22);
            this.CoordYTB.TabIndex = 5;
            // 
            // CoordZTB
            // 
            this.CoordZTB.Location = new System.Drawing.Point(108, 154);
            this.CoordZTB.Name = "CoordZTB";
            this.CoordZTB.Size = new System.Drawing.Size(222, 22);
            this.CoordZTB.TabIndex = 6;
            // 
            // DepthTB
            // 
            this.DepthTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DepthTB.Location = new System.Drawing.Point(109, 239);
            this.DepthTB.Name = "DepthTB";
            this.DepthTB.Size = new System.Drawing.Size(222, 22);
            this.DepthTB.TabIndex = 12;
            // 
            // HeightTB
            // 
            this.HeightTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightTB.Location = new System.Drawing.Point(109, 211);
            this.HeightTB.Name = "HeightTB";
            this.HeightTB.Size = new System.Drawing.Size(222, 22);
            this.HeightTB.TabIndex = 11;
            // 
            // WidthTB
            // 
            this.WidthTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthTB.Location = new System.Drawing.Point(109, 183);
            this.WidthTB.Name = "WidthTB";
            this.WidthTB.Size = new System.Drawing.Size(222, 22);
            this.WidthTB.TabIndex = 10;
            // 
            // DepthLB
            // 
            this.DepthLB.AutoSize = true;
            this.DepthLB.Location = new System.Drawing.Point(40, 244);
            this.DepthLB.Name = "DepthLB";
            this.DepthLB.Size = new System.Drawing.Size(54, 17);
            this.DepthLB.TabIndex = 9;
            this.DepthLB.Text = "Depth: ";
            // 
            // HeightLB
            // 
            this.HeightLB.AutoSize = true;
            this.HeightLB.Location = new System.Drawing.Point(40, 216);
            this.HeightLB.Name = "HeightLB";
            this.HeightLB.Size = new System.Drawing.Size(53, 17);
            this.HeightLB.TabIndex = 8;
            this.HeightLB.Text = "Height:";
            // 
            // WidthLB
            // 
            this.WidthLB.AutoSize = true;
            this.WidthLB.Location = new System.Drawing.Point(40, 188);
            this.WidthLB.Name = "WidthLB";
            this.WidthLB.Size = new System.Drawing.Size(48, 17);
            this.WidthLB.TabIndex = 7;
            this.WidthLB.Text = "Width:";
            // 
            // MaterialBT
            // 
            this.MaterialBT.Location = new System.Drawing.Point(43, 297);
            this.MaterialBT.Name = "MaterialBT";
            this.MaterialBT.Size = new System.Drawing.Size(102, 38);
            this.MaterialBT.TabIndex = 13;
            this.MaterialBT.Text = "Material";
            this.MaterialBT.UseVisualStyleBackColor = true;
            this.MaterialBT.Click += new System.EventHandler(this.MaterialBT_Click);
            // 
            // SaveBTEdit
            // 
            this.SaveBTEdit.Location = new System.Drawing.Point(364, 379);
            this.SaveBTEdit.Name = "SaveBTEdit";
            this.SaveBTEdit.Size = new System.Drawing.Size(102, 38);
            this.SaveBTEdit.TabIndex = 14;
            this.SaveBTEdit.Text = "Save";
            this.SaveBTEdit.UseVisualStyleBackColor = true;
            this.SaveBTEdit.Click += new System.EventHandler(this.SaveBTEdit_Click);
            // 
            // CuboidEditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 441);
            this.Controls.Add(this.SaveBTEdit);
            this.Controls.Add(this.MaterialBT);
            this.Controls.Add(this.DepthTB);
            this.Controls.Add(this.HeightTB);
            this.Controls.Add(this.WidthTB);
            this.Controls.Add(this.DepthLB);
            this.Controls.Add(this.HeightLB);
            this.Controls.Add(this.WidthLB);
            this.Controls.Add(this.CoordZTB);
            this.Controls.Add(this.CoordYTB);
            this.Controls.Add(this.CoordXTB);
            this.Controls.Add(this.CoordZ);
            this.Controls.Add(this.CoordY);
            this.Controls.Add(this.CoordX);
            this.Controls.Add(this.CuboudEditLB);
            this.Name = "CuboidEditWindow";
            this.Text = "ObjectEditWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CuboudEditLB;
        private System.Windows.Forms.Label CoordX;
        private System.Windows.Forms.Label CoordY;
        private System.Windows.Forms.Label CoordZ;
        private System.Windows.Forms.TextBox CoordXTB;
        private System.Windows.Forms.TextBox CoordYTB;
        private System.Windows.Forms.TextBox CoordZTB;
        private System.Windows.Forms.TextBox DepthTB;
        private System.Windows.Forms.TextBox HeightTB;
        private System.Windows.Forms.TextBox WidthTB;
        private System.Windows.Forms.Label DepthLB;
        private System.Windows.Forms.Label HeightLB;
        private System.Windows.Forms.Label WidthLB;
        private System.Windows.Forms.Button MaterialBT;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button SaveBTEdit;
    }
}