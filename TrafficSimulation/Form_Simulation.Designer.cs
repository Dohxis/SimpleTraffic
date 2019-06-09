namespace TrafficSimulation
{
    partial class Form_Simulation
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
            this.rbCorner1 = new System.Windows.Forms.RadioButton();
            this.rbCorner2 = new System.Windows.Forms.RadioButton();
            this.rbCorner3 = new System.Windows.Forms.RadioButton();
            this.rbCorner4 = new System.Windows.Forms.RadioButton();
            this.gbIntersections = new System.Windows.Forms.GroupBox();
            this.rbTrafficPlus = new System.Windows.Forms.RadioButton();
            this.Corner4 = new System.Windows.Forms.PictureBox();
            this.Corner2 = new System.Windows.Forms.PictureBox();
            this.Corner3 = new System.Windows.Forms.PictureBox();
            this.PlusIntersection = new System.Windows.Forms.PictureBox();
            this.TLeft = new System.Windows.Forms.PictureBox();
            this.TUp = new System.Windows.Forms.PictureBox();
            this.TrafficPlusIntersection = new System.Windows.Forms.PictureBox();
            this.TRight = new System.Windows.Forms.PictureBox();
            this.TDown = new System.Windows.Forms.PictureBox();
            this.Corner1 = new System.Windows.Forms.PictureBox();
            this.lblCarsQuit = new System.Windows.Forms.Label();
            this.tbCarsQuit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_redlight = new System.Windows.Forms.TextBox();
            this.tb_greenlight = new System.Windows.Forms.TextBox();
            this.gbIntersections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Corner4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlusIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficPlusIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbPlusIntersection
            // 
            this.rbPlusIntersection.AutoSize = true;
            this.rbPlusIntersection.Location = new System.Drawing.Point(23, 55);
            this.rbPlusIntersection.Name = "rbPlusIntersection";
            this.rbPlusIntersection.Size = new System.Drawing.Size(14, 13);
            this.rbPlusIntersection.TabIndex = 0;
            this.rbPlusIntersection.TabStop = true;
            this.rbPlusIntersection.UseVisualStyleBackColor = true;
            // 
            // rbTUp
            // 
            this.rbTUp.AutoSize = true;
            this.rbTUp.Location = new System.Drawing.Point(23, 135);
            this.rbTUp.Name = "rbTUp";
            this.rbTUp.Size = new System.Drawing.Size(14, 13);
            this.rbTUp.TabIndex = 1;
            this.rbTUp.TabStop = true;
            this.rbTUp.UseVisualStyleBackColor = true;
            // 
            // rbTDown
            // 
            this.rbTDown.AutoSize = true;
            this.rbTDown.Location = new System.Drawing.Point(140, 135);
            this.rbTDown.Name = "rbTDown";
            this.rbTDown.Size = new System.Drawing.Size(14, 13);
            this.rbTDown.TabIndex = 2;
            this.rbTDown.TabStop = true;
            this.rbTDown.UseVisualStyleBackColor = true;
            // 
            // rbTLeft
            // 
            this.rbTLeft.AutoSize = true;
            this.rbTLeft.Location = new System.Drawing.Point(23, 217);
            this.rbTLeft.Name = "rbTLeft";
            this.rbTLeft.Size = new System.Drawing.Size(14, 13);
            this.rbTLeft.TabIndex = 3;
            this.rbTLeft.TabStop = true;
            this.rbTLeft.UseVisualStyleBackColor = true;
            // 
            // rbTRight
            // 
            this.rbTRight.AutoSize = true;
            this.rbTRight.Location = new System.Drawing.Point(140, 217);
            this.rbTRight.Name = "rbTRight";
            this.rbTRight.Size = new System.Drawing.Size(14, 13);
            this.rbTRight.TabIndex = 4;
            this.rbTRight.TabStop = true;
            this.rbTRight.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(1101, 580);
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
            this.btnStop.Location = new System.Drawing.Point(1181, 580);
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
            this.label1.Location = new System.Drawing.Point(1121, 619);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cars Spawned:";
            // 
            // tbSpawnedCars
            // 
            this.tbSpawnedCars.Location = new System.Drawing.Point(1204, 616);
            this.tbSpawnedCars.Margin = new System.Windows.Forms.Padding(2);
            this.tbSpawnedCars.Name = "tbSpawnedCars";
            this.tbSpawnedCars.ReadOnly = true;
            this.tbSpawnedCars.Size = new System.Drawing.Size(34, 20);
            this.tbSpawnedCars.TabIndex = 8;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(104, 437);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "Clear Grid";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // rbCorner1
            // 
            this.rbCorner1.AutoSize = true;
            this.rbCorner1.Location = new System.Drawing.Point(23, 379);
            this.rbCorner1.Name = "rbCorner1";
            this.rbCorner1.Size = new System.Drawing.Size(14, 13);
            this.rbCorner1.TabIndex = 10;
            this.rbCorner1.TabStop = true;
            this.rbCorner1.UseVisualStyleBackColor = true;
            // 
            // rbCorner2
            // 
            this.rbCorner2.AutoSize = true;
            this.rbCorner2.Location = new System.Drawing.Point(140, 299);
            this.rbCorner2.Name = "rbCorner2";
            this.rbCorner2.Size = new System.Drawing.Size(14, 13);
            this.rbCorner2.TabIndex = 11;
            this.rbCorner2.TabStop = true;
            this.rbCorner2.UseVisualStyleBackColor = true;
            // 
            // rbCorner3
            // 
            this.rbCorner3.AutoSize = true;
            this.rbCorner3.Location = new System.Drawing.Point(23, 296);
            this.rbCorner3.Name = "rbCorner3";
            this.rbCorner3.Size = new System.Drawing.Size(14, 13);
            this.rbCorner3.TabIndex = 12;
            this.rbCorner3.TabStop = true;
            this.rbCorner3.UseVisualStyleBackColor = true;
            // 
            // rbCorner4
            // 
            this.rbCorner4.AutoSize = true;
            this.rbCorner4.Location = new System.Drawing.Point(140, 379);
            this.rbCorner4.Name = "rbCorner4";
            this.rbCorner4.Size = new System.Drawing.Size(14, 13);
            this.rbCorner4.TabIndex = 13;
            this.rbCorner4.TabStop = true;
            this.rbCorner4.UseVisualStyleBackColor = true;
            // 
            // gbIntersections
            // 
            this.gbIntersections.Controls.Add(this.rbTrafficPlus);
            this.gbIntersections.Controls.Add(this.btn_Clear);
            this.gbIntersections.Controls.Add(this.Corner4);
            this.gbIntersections.Controls.Add(this.rbCorner4);
            this.gbIntersections.Controls.Add(this.Corner2);
            this.gbIntersections.Controls.Add(this.Corner3);
            this.gbIntersections.Controls.Add(this.rbCorner1);
            this.gbIntersections.Controls.Add(this.PlusIntersection);
            this.gbIntersections.Controls.Add(this.TLeft);
            this.gbIntersections.Controls.Add(this.TUp);
            this.gbIntersections.Controls.Add(this.TrafficPlusIntersection);
            this.gbIntersections.Controls.Add(this.rbCorner3);
            this.gbIntersections.Controls.Add(this.TRight);
            this.gbIntersections.Controls.Add(this.rbCorner2);
            this.gbIntersections.Controls.Add(this.TDown);
            this.gbIntersections.Controls.Add(this.Corner1);
            this.gbIntersections.Controls.Add(this.rbTRight);
            this.gbIntersections.Controls.Add(this.rbPlusIntersection);
            this.gbIntersections.Controls.Add(this.rbTLeft);
            this.gbIntersections.Controls.Add(this.rbTUp);
            this.gbIntersections.Controls.Add(this.rbTDown);
            this.gbIntersections.Location = new System.Drawing.Point(1021, 12);
            this.gbIntersections.Name = "gbIntersections";
            this.gbIntersections.Size = new System.Drawing.Size(257, 469);
            this.gbIntersections.TabIndex = 14;
            this.gbIntersections.TabStop = false;
            this.gbIntersections.Text = "Interections";
            // 
            // rbTrafficPlus
            // 
            this.rbTrafficPlus.AutoSize = true;
            this.rbTrafficPlus.Location = new System.Drawing.Point(142, 55);
            this.rbTrafficPlus.Name = "rbTrafficPlus";
            this.rbTrafficPlus.Size = new System.Drawing.Size(14, 13);
            this.rbTrafficPlus.TabIndex = 14;
            this.rbTrafficPlus.TabStop = true;
            this.rbTrafficPlus.UseVisualStyleBackColor = true;
            // 
            // Corner4
            // 
            this.Corner4.Location = new System.Drawing.Point(160, 347);
            this.Corner4.Name = "Corner4";
            this.Corner4.Size = new System.Drawing.Size(80, 74);
            this.Corner4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner4.TabIndex = 9;
            this.Corner4.TabStop = false;
            // 
            // Corner2
            // 
            this.Corner2.Location = new System.Drawing.Point(160, 264);
            this.Corner2.Name = "Corner2";
            this.Corner2.Size = new System.Drawing.Size(80, 74);
            this.Corner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner2.TabIndex = 8;
            this.Corner2.TabStop = false;
            // 
            // Corner3
            // 
            this.Corner3.Location = new System.Drawing.Point(43, 347);
            this.Corner3.Name = "Corner3";
            this.Corner3.Size = new System.Drawing.Size(80, 74);
            this.Corner3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner3.TabIndex = 0;
            this.Corner3.TabStop = false;
            // 
            // PlusIntersection
            // 
            this.PlusIntersection.Location = new System.Drawing.Point(43, 19);
            this.PlusIntersection.Name = "PlusIntersection";
            this.PlusIntersection.Size = new System.Drawing.Size(80, 74);
            this.PlusIntersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlusIntersection.TabIndex = 4;
            this.PlusIntersection.TabStop = false;
            // 
            // TLeft
            // 
            this.TLeft.Location = new System.Drawing.Point(43, 184);
            this.TLeft.Name = "TLeft";
            this.TLeft.Size = new System.Drawing.Size(80, 74);
            this.TLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TLeft.TabIndex = 2;
            this.TLeft.TabStop = false;
            // 
            // TUp
            // 
            this.TUp.Location = new System.Drawing.Point(43, 101);
            this.TUp.Name = "TUp";
            this.TUp.Size = new System.Drawing.Size(80, 74);
            this.TUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TUp.TabIndex = 3;
            this.TUp.TabStop = false;
            // 
            // TrafficPlusIntersection
            // 
            this.TrafficPlusIntersection.Location = new System.Drawing.Point(160, 19);
            this.TrafficPlusIntersection.Name = "TrafficPlusIntersection";
            this.TrafficPlusIntersection.Size = new System.Drawing.Size(80, 73);
            this.TrafficPlusIntersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrafficPlusIntersection.TabIndex = 5;
            this.TrafficPlusIntersection.TabStop = false;
            // 
            // TRight
            // 
            this.TRight.Location = new System.Drawing.Point(160, 184);
            this.TRight.Name = "TRight";
            this.TRight.Size = new System.Drawing.Size(80, 74);
            this.TRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TRight.TabIndex = 7;
            this.TRight.TabStop = false;
            // 
            // TDown
            // 
            this.TDown.Location = new System.Drawing.Point(160, 101);
            this.TDown.Name = "TDown";
            this.TDown.Size = new System.Drawing.Size(80, 74);
            this.TDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TDown.TabIndex = 6;
            this.TDown.TabStop = false;
            // 
            // Corner1
            // 
            this.Corner1.Location = new System.Drawing.Point(43, 264);
            this.Corner1.Name = "Corner1";
            this.Corner1.Size = new System.Drawing.Size(80, 74);
            this.Corner1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner1.TabIndex = 1;
            this.Corner1.TabStop = false;
            // 
            // lblCarsQuit
            // 
            this.lblCarsQuit.AutoSize = true;
            this.lblCarsQuit.Location = new System.Drawing.Point(1065, 653);
            this.lblCarsQuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsQuit.Name = "lblCarsQuit";
            this.lblCarsQuit.Size = new System.Drawing.Size(135, 13);
            this.lblCarsQuit.TabIndex = 7;
            this.lblCarsQuit.Text = "Cars Arrived at Destination:";
            // 
            // tbCarsQuit
            // 
            this.tbCarsQuit.Location = new System.Drawing.Point(1204, 650);
            this.tbCarsQuit.Margin = new System.Windows.Forms.Padding(2);
            this.tbCarsQuit.Name = "tbCarsQuit";
            this.tbCarsQuit.ReadOnly = true;
            this.tbCarsQuit.Size = new System.Drawing.Size(34, 20);
            this.tbCarsQuit.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1064, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Red light time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1064, 544);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Green light time";
            // 
            // tb_redlight
            // 
            this.tb_redlight.Location = new System.Drawing.Point(1150, 515);
            this.tb_redlight.Name = "tb_redlight";
            this.tb_redlight.Size = new System.Drawing.Size(50, 20);
            this.tb_redlight.TabIndex = 17;
            // 
            // tb_greenlight
            // 
            this.tb_greenlight.Location = new System.Drawing.Point(1150, 541);
            this.tb_greenlight.Name = "tb_greenlight";
            this.tb_greenlight.Size = new System.Drawing.Size(50, 20);
            this.tb_greenlight.TabIndex = 18;
            // 
            // Form_Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 845);
            this.Controls.Add(this.tb_greenlight);
            this.Controls.Add(this.tb_redlight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbIntersections);
            this.Controls.Add(this.tbCarsQuit);
            this.Controls.Add(this.tbSpawnedCars);
            this.Controls.Add(this.lblCarsQuit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLaunch);
            this.Name = "Form_Simulation";
            this.Text = "Simulation";
            this.gbIntersections.ResumeLayout(false);
            this.gbIntersections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Corner4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlusIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficPlusIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner1)).EndInit();
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
        private System.Windows.Forms.RadioButton rbCorner1;
        private System.Windows.Forms.RadioButton rbCorner2;
        private System.Windows.Forms.RadioButton rbCorner3;
        private System.Windows.Forms.RadioButton rbCorner4;
        private System.Windows.Forms.GroupBox gbIntersections;
        private System.Windows.Forms.RadioButton rbTrafficPlus;
        private System.Windows.Forms.PictureBox Corner4;
        private System.Windows.Forms.PictureBox Corner2;
        private System.Windows.Forms.PictureBox TRight;
        private System.Windows.Forms.PictureBox TDown;
        private System.Windows.Forms.PictureBox TrafficPlusIntersection;
        private System.Windows.Forms.PictureBox PlusIntersection;
        private System.Windows.Forms.PictureBox TUp;
        private System.Windows.Forms.PictureBox TLeft;
        private System.Windows.Forms.PictureBox Corner1;
        private System.Windows.Forms.PictureBox Corner3;
        private System.Windows.Forms.Label lblCarsQuit;
        private System.Windows.Forms.TextBox tbCarsQuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_redlight;
        private System.Windows.Forms.TextBox tb_greenlight;
    }
}