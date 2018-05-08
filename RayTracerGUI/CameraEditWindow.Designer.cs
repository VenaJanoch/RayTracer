namespace RayTracerGUI
{
    partial class CameraEditWindow
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
            this.AngleTB = new System.Windows.Forms.TextBox();
            this.WidthLB = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SaveBTEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CuboudEditLB
            // 
            this.CuboudEditLB.AutoSize = true;
            this.CuboudEditLB.Location = new System.Drawing.Point(167, 21);
            this.CuboudEditLB.Name = "CuboudEditLB";
            this.CuboudEditLB.Size = new System.Drawing.Size(116, 17);
            this.CuboudEditLB.TabIndex = 0;
            this.CuboudEditLB.Text = "Camera Editation";
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
            // AngleTB
            // 
            this.AngleTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AngleTB.Location = new System.Drawing.Point(109, 183);
            this.AngleTB.Name = "AngleTB";
            this.AngleTB.Size = new System.Drawing.Size(222, 22);
            this.AngleTB.TabIndex = 10;
            // 
            // WidthLB
            // 
            this.WidthLB.AutoSize = true;
            this.WidthLB.Location = new System.Drawing.Point(40, 188);
            this.WidthLB.Name = "WidthLB";
            this.WidthLB.Size = new System.Drawing.Size(48, 17);
            this.WidthLB.TabIndex = 7;
            this.WidthLB.Text = "Angle:";
            // 
            // SaveBTEdit
            // 
            this.SaveBTEdit.Location = new System.Drawing.Point(350, 235);
            this.SaveBTEdit.Name = "SaveBTEdit";
            this.SaveBTEdit.Size = new System.Drawing.Size(102, 38);
            this.SaveBTEdit.TabIndex = 14;
            this.SaveBTEdit.Text = "Save";
            this.SaveBTEdit.UseVisualStyleBackColor = true;
            this.SaveBTEdit.Click += new System.EventHandler(this.SaveBTEdit_Click);
            // 
            // CameraEditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 325);
            this.Controls.Add(this.SaveBTEdit);
            this.Controls.Add(this.AngleTB);
            this.Controls.Add(this.WidthLB);
            this.Controls.Add(this.CoordZTB);
            this.Controls.Add(this.CoordYTB);
            this.Controls.Add(this.CoordXTB);
            this.Controls.Add(this.CoordZ);
            this.Controls.Add(this.CoordY);
            this.Controls.Add(this.CoordX);
            this.Controls.Add(this.CuboudEditLB);
            this.Name = "CameraEditWindow";
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
        private System.Windows.Forms.TextBox AngleTB;
        private System.Windows.Forms.Label WidthLB;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button SaveBTEdit;
    }
}