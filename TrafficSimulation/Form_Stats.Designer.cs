namespace TrafficSimulation
{
    partial class Form_Stats
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
            this.lblCarsSpawned = new System.Windows.Forms.Label();
            this.tbCarsSpawned = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCarsSpawned
            // 
            this.lblCarsSpawned.AutoSize = true;
            this.lblCarsSpawned.Location = new System.Drawing.Point(36, 39);
            this.lblCarsSpawned.Name = "lblCarsSpawned";
            this.lblCarsSpawned.Size = new System.Drawing.Size(79, 13);
            this.lblCarsSpawned.TabIndex = 0;
            this.lblCarsSpawned.Text = "Cars Spawned:";
            // 
            // tbCarsSpawned
            // 
            this.tbCarsSpawned.Location = new System.Drawing.Point(121, 36);
            this.tbCarsSpawned.Name = "tbCarsSpawned";
            this.tbCarsSpawned.ReadOnly = true;
            this.tbCarsSpawned.Size = new System.Drawing.Size(52, 20);
            this.tbCarsSpawned.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 502);
            this.Controls.Add(this.tbCarsSpawned);
            this.Controls.Add(this.lblCarsSpawned);
            this.Name = "Form1";
            this.Text = "Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarsSpawned;
        private System.Windows.Forms.TextBox tbCarsSpawned;
    }
}

