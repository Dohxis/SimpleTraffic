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
            this.SuspendLayout();
            // 
            // rbPlusIntersection
            // 
            this.rbPlusIntersection.AutoSize = true;
            this.rbPlusIntersection.Location = new System.Drawing.Point(1113, 32);
            this.rbPlusIntersection.Name = "rbPlusIntersection";
            this.rbPlusIntersection.Size = new System.Drawing.Size(103, 17);
            this.rbPlusIntersection.TabIndex = 0;
            this.rbPlusIntersection.TabStop = true;
            this.rbPlusIntersection.Text = "Plus Intersection";
            this.rbPlusIntersection.UseVisualStyleBackColor = true;
            // 
            // rbTUp
            // 
            this.rbTUp.AutoSize = true;
            this.rbTUp.Location = new System.Drawing.Point(1113, 55);
            this.rbTUp.Name = "rbTUp";
            this.rbTUp.Size = new System.Drawing.Size(107, 17);
            this.rbTUp.TabIndex = 1;
            this.rbTUp.TabStop = true;
            this.rbTUp.Text = "T Intersection Up";
            this.rbTUp.UseVisualStyleBackColor = true;
            // 
            // rbTDown
            // 
            this.rbTDown.AutoSize = true;
            this.rbTDown.Location = new System.Drawing.Point(1113, 78);
            this.rbTDown.Name = "rbTDown";
            this.rbTDown.Size = new System.Drawing.Size(121, 17);
            this.rbTDown.TabIndex = 2;
            this.rbTDown.TabStop = true;
            this.rbTDown.Text = "T Intersection Down";
            this.rbTDown.UseVisualStyleBackColor = true;
            // 
            // rbTLeft
            // 
            this.rbTLeft.AutoSize = true;
            this.rbTLeft.Location = new System.Drawing.Point(1113, 101);
            this.rbTLeft.Name = "rbTLeft";
            this.rbTLeft.Size = new System.Drawing.Size(111, 17);
            this.rbTLeft.TabIndex = 3;
            this.rbTLeft.TabStop = true;
            this.rbTLeft.Text = "T Intersection Left";
            this.rbTLeft.UseVisualStyleBackColor = true;
            // 
            // rbTRight
            // 
            this.rbTRight.AutoSize = true;
            this.rbTRight.Location = new System.Drawing.Point(1113, 124);
            this.rbTRight.Name = "rbTRight";
            this.rbTRight.Size = new System.Drawing.Size(118, 17);
            this.rbTRight.TabIndex = 4;
            this.rbTRight.TabStop = true;
            this.rbTRight.Text = "T Intersection Right";
            this.rbTRight.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(1113, 214);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(56, 19);
            this.btnLaunch.TabIndex = 5;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1186, 214);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.label1.Location = new System.Drawing.Point(1113, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cars Spawned:";
            // 
            // tbSpawnedCars
            // 
            this.tbSpawnedCars.Location = new System.Drawing.Point(1196, 266);
            this.tbSpawnedCars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSpawnedCars.Name = "tbSpawnedCars";
            this.tbSpawnedCars.ReadOnly = true;
            this.tbSpawnedCars.Size = new System.Drawing.Size(34, 20);
            this.tbSpawnedCars.TabIndex = 8;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(1141, 147);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "Clear Grid";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 845);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.tbSpawnedCars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.rbTRight);
            this.Controls.Add(this.rbTLeft);
            this.Controls.Add(this.rbTDown);
            this.Controls.Add(this.rbTUp);
            this.Controls.Add(this.rbPlusIntersection);
            this.Name = "Form2";
            this.Text = "Simulation";
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
    }
}