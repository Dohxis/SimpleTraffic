namespace TrafficSimulation
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.rbPlusIntersection = new System.Windows.Forms.RadioButton();
            this.rbTUp = new System.Windows.Forms.RadioButton();
            this.rbTDown = new System.Windows.Forms.RadioButton();
            this.rbTLeft = new System.Windows.Forms.RadioButton();
            this.rbTRight = new System.Windows.Forms.RadioButton();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpawnedCars = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCorner4 = new System.Windows.Forms.RadioButton();
            this.rbCorner3 = new System.Windows.Forms.RadioButton();
            this.rbCorner2 = new System.Windows.Forms.RadioButton();
            this.rbCorner1 = new System.Windows.Forms.RadioButton();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // rbPlusIntersection
            // 
            this.rbPlusIntersection.AutoSize = true;
            this.rbPlusIntersection.Location = new System.Drawing.Point(179, 41);
            this.rbPlusIntersection.Name = "rbPlusIntersection";
            this.rbPlusIntersection.Size = new System.Drawing.Size(14, 13);
            this.rbPlusIntersection.TabIndex = 0;
            this.rbPlusIntersection.UseVisualStyleBackColor = true;
            // 
            // rbTUp
            // 
            this.rbTUp.AutoSize = true;
            this.rbTUp.Location = new System.Drawing.Point(7, 41);
            this.rbTUp.Name = "rbTUp";
            this.rbTUp.Size = new System.Drawing.Size(14, 13);
            this.rbTUp.TabIndex = 1;
            this.rbTUp.UseVisualStyleBackColor = true;
            // 
            // rbTDown
            // 
            this.rbTDown.AutoSize = true;
            this.rbTDown.Location = new System.Drawing.Point(92, 41);
            this.rbTDown.Name = "rbTDown";
            this.rbTDown.Size = new System.Drawing.Size(14, 13);
            this.rbTDown.TabIndex = 2;
            this.rbTDown.UseVisualStyleBackColor = true;
            // 
            // rbTLeft
            // 
            this.rbTLeft.AutoSize = true;
            this.rbTLeft.Location = new System.Drawing.Point(7, 113);
            this.rbTLeft.Name = "rbTLeft";
            this.rbTLeft.Size = new System.Drawing.Size(14, 13);
            this.rbTLeft.TabIndex = 3;
            this.rbTLeft.UseVisualStyleBackColor = true;
            // 
            // rbTRight
            // 
            this.rbTRight.AutoSize = true;
            this.rbTRight.Location = new System.Drawing.Point(92, 111);
            this.rbTRight.Name = "rbTRight";
            this.rbTRight.Size = new System.Drawing.Size(14, 13);
            this.rbTRight.TabIndex = 4;
            this.rbTRight.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(1032, 380);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(56, 19);
            this.btnLaunch.TabIndex = 5;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1105, 380);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 19);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1032, 432);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cars Spawned:";
            // 
            // tbSpawnedCars
            // 
            this.tbSpawnedCars.Location = new System.Drawing.Point(1115, 432);
            this.tbSpawnedCars.Margin = new System.Windows.Forms.Padding(2);
            this.tbSpawnedCars.Name = "tbSpawnedCars";
            this.tbSpawnedCars.ReadOnly = true;
            this.tbSpawnedCars.Size = new System.Drawing.Size(34, 20);
            this.tbSpawnedCars.TabIndex = 8;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(1059, 352);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "Clear Grid";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "plus_intersection.PNG";
            this.pictureBox1.Location = new System.Drawing.Point(199, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImageLocation = "TUp.PNG";
            this.pictureBox2.Location = new System.Drawing.Point(27, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.ImageLocation = "TDown.PNG";
            this.pictureBox3.Location = new System.Drawing.Point(112, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.ImageLocation = "TLeft.PNG";
            this.pictureBox4.Location = new System.Drawing.Point(27, 88);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(59, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.ImageLocation = "TRight.PNG";
            this.pictureBox5.Location = new System.Drawing.Point(112, 88);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(59, 60);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCorner4);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.rbCorner3);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.rbCorner2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rbCorner1);
            this.groupBox1.Controls.Add(this.rbTUp);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.rbTDown);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.rbTLeft);
            this.groupBox1.Controls.Add(this.rbPlusIntersection);
            this.groupBox1.Controls.Add(this.rbTRight);
            this.groupBox1.Location = new System.Drawing.Point(1011, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 293);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intersections";
            // 
            // rbCorner4
            // 
            this.rbCorner4.AutoSize = true;
            this.rbCorner4.Location = new System.Drawing.Point(95, 240);
            this.rbCorner4.Name = "rbCorner4";
            this.rbCorner4.Size = new System.Drawing.Size(14, 13);
            this.rbCorner4.TabIndex = 22;
            this.rbCorner4.TabStop = true;
            this.rbCorner4.UseVisualStyleBackColor = true;
            // 
            // rbCorner3
            // 
            this.rbCorner3.AutoSize = true;
            this.rbCorner3.Location = new System.Drawing.Point(6, 240);
            this.rbCorner3.Name = "rbCorner3";
            this.rbCorner3.Size = new System.Drawing.Size(14, 13);
            this.rbCorner3.TabIndex = 21;
            this.rbCorner3.TabStop = true;
            this.rbCorner3.UseVisualStyleBackColor = true;
            // 
            // rbCorner2
            // 
            this.rbCorner2.AutoSize = true;
            this.rbCorner2.Location = new System.Drawing.Point(95, 175);
            this.rbCorner2.Name = "rbCorner2";
            this.rbCorner2.Size = new System.Drawing.Size(14, 13);
            this.rbCorner2.TabIndex = 20;
            this.rbCorner2.TabStop = true;
            this.rbCorner2.UseVisualStyleBackColor = true;
            // 
            // rbCorner1
            // 
            this.rbCorner1.AutoSize = true;
            this.rbCorner1.Location = new System.Drawing.Point(7, 175);
            this.rbCorner1.Name = "rbCorner1";
            this.rbCorner1.Size = new System.Drawing.Size(14, 13);
            this.rbCorner1.TabIndex = 19;
            this.rbCorner1.TabStop = true;
            this.rbCorner1.UseVisualStyleBackColor = true;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.ImageLocation = "Corner4.PNG";
            this.pictureBox9.Location = new System.Drawing.Point(112, 220);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(59, 60);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 18;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.ImageLocation = "Corner3.PNG";
            this.pictureBox8.Location = new System.Drawing.Point(27, 220);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(59, 60);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 17;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.ImageLocation = "Corner2.PNG";
            this.pictureBox7.Location = new System.Drawing.Point(112, 154);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(59, 60);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 16;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.ImageLocation = "Corner1.PNG";
            this.pictureBox6.Location = new System.Drawing.Point(27, 154);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(59, 60);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 15;
            this.pictureBox6.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 845);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.tbSpawnedCars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLaunch);
            this.Name = "Form2";
            this.Text = "Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPlusIntersection;
        private System.Windows.Forms.RadioButton rbTUp;
        private System.Windows.Forms.RadioButton rbTDown;
        private System.Windows.Forms.RadioButton rbTLeft;
        private System.Windows.Forms.RadioButton rbTRight;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSpawnedCars;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCorner4;
        private System.Windows.Forms.RadioButton rbCorner3;
        private System.Windows.Forms.RadioButton rbCorner2;
        private System.Windows.Forms.RadioButton rbCorner1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}