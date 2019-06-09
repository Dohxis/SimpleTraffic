﻿namespace TrafficSimulation
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
            this.tbCarsQuit = new System.Windows.Forms.TextBox();
            this.lblCarsQuit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_timeran = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCarsSpawned
            // 
            this.lblCarsSpawned.AutoSize = true;
            this.lblCarsSpawned.Location = new System.Drawing.Point(94, 39);
            this.lblCarsSpawned.Name = "lblCarsSpawned";
            this.lblCarsSpawned.Size = new System.Drawing.Size(79, 13);
            this.lblCarsSpawned.TabIndex = 0;
            this.lblCarsSpawned.Text = "Cars Spawned:";
            // 
            // tbCarsSpawned
            // 
            this.tbCarsSpawned.Location = new System.Drawing.Point(177, 36);
            this.tbCarsSpawned.Name = "tbCarsSpawned";
            this.tbCarsSpawned.ReadOnly = true;
            this.tbCarsSpawned.Size = new System.Drawing.Size(52, 20);
            this.tbCarsSpawned.TabIndex = 1;
            // 
            // tbCarsQuit
            // 
            this.tbCarsQuit.Location = new System.Drawing.Point(177, 70);
            this.tbCarsQuit.Margin = new System.Windows.Forms.Padding(2);
            this.tbCarsQuit.Name = "tbCarsQuit";
            this.tbCarsQuit.ReadOnly = true;
            this.tbCarsQuit.Size = new System.Drawing.Size(52, 20);
            this.tbCarsQuit.TabIndex = 10;
            // 
            // lblCarsQuit
            // 
            this.lblCarsQuit.AutoSize = true;
            this.lblCarsQuit.Location = new System.Drawing.Point(38, 73);
            this.lblCarsQuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsQuit.Name = "lblCarsQuit";
            this.lblCarsQuit.Size = new System.Drawing.Size(135, 13);
            this.lblCarsQuit.TabIndex = 9;
            this.lblCarsQuit.Text = "Cars Arrived at Destination:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Simulation ran for:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_timeran
            // 
            this.tb_timeran.Location = new System.Drawing.Point(177, 102);
            this.tb_timeran.Margin = new System.Windows.Forms.Padding(2);
            this.tb_timeran.Name = "tb_timeran";
            this.tb_timeran.ReadOnly = true;
            this.tb_timeran.Size = new System.Drawing.Size(52, 20);
            this.tb_timeran.TabIndex = 12;
            // 
            // Form_Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 502);
            this.Controls.Add(this.tb_timeran);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCarsQuit);
            this.Controls.Add(this.lblCarsQuit);
            this.Controls.Add(this.tbCarsSpawned);
            this.Controls.Add(this.lblCarsSpawned);
            this.Name = "Form_Stats";
            this.Text = "Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarsSpawned;
        private System.Windows.Forms.TextBox tbCarsSpawned;
        private System.Windows.Forms.TextBox tbCarsQuit;
        private System.Windows.Forms.Label lblCarsQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_timeran;
    }
}

