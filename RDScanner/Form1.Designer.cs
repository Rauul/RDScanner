namespace RDScanner
{
    partial class Form1
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
            this.carsButton = new System.Windows.Forms.Button();
            this.tracksButton = new System.Windows.Forms.Button();
            this.skinsButton = new System.Windows.Forms.Button();
            this.miscButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.carsLabel = new System.Windows.Forms.Label();
            this.miscLabel = new System.Windows.Forms.Label();
            this.skinsLabel = new System.Windows.Forms.Label();
            this.tracksLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // carsButton
            // 
            this.carsButton.Location = new System.Drawing.Point(13, 13);
            this.carsButton.Name = "carsButton";
            this.carsButton.Size = new System.Drawing.Size(75, 23);
            this.carsButton.TabIndex = 0;
            this.carsButton.Text = "Cars";
            this.carsButton.UseVisualStyleBackColor = true;
            this.carsButton.Click += new System.EventHandler(this.carsButton_Click);
            // 
            // tracksButton
            // 
            this.tracksButton.Location = new System.Drawing.Point(95, 13);
            this.tracksButton.Name = "tracksButton";
            this.tracksButton.Size = new System.Drawing.Size(75, 23);
            this.tracksButton.TabIndex = 1;
            this.tracksButton.Text = "Tracks";
            this.tracksButton.UseVisualStyleBackColor = true;
            this.tracksButton.Click += new System.EventHandler(this.tracksButton_Click);
            // 
            // skinsButton
            // 
            this.skinsButton.Location = new System.Drawing.Point(177, 13);
            this.skinsButton.Name = "skinsButton";
            this.skinsButton.Size = new System.Drawing.Size(75, 23);
            this.skinsButton.TabIndex = 2;
            this.skinsButton.Text = "Skins";
            this.skinsButton.UseVisualStyleBackColor = true;
            this.skinsButton.Click += new System.EventHandler(this.skinsButton_Click);
            // 
            // miscButton
            // 
            this.miscButton.Location = new System.Drawing.Point(259, 13);
            this.miscButton.Name = "miscButton";
            this.miscButton.Size = new System.Drawing.Size(75, 23);
            this.miscButton.TabIndex = 3;
            this.miscButton.Text = "Misc";
            this.miscButton.UseVisualStyleBackColor = true;
            this.miscButton.Click += new System.EventHandler(this.miscButton_Click);
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(13, 71);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(321, 67);
            this.allButton.TabIndex = 4;
            this.allButton.Text = "ALL";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // carsLabel
            // 
            this.carsLabel.AutoSize = true;
            this.carsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carsLabel.Location = new System.Drawing.Point(43, 39);
            this.carsLabel.Name = "carsLabel";
            this.carsLabel.Size = new System.Drawing.Size(17, 17);
            this.carsLabel.TabIndex = 5;
            this.carsLabel.Text = "0";
            // 
            // miscLabel
            // 
            this.miscLabel.AutoSize = true;
            this.miscLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miscLabel.Location = new System.Drawing.Point(286, 39);
            this.miscLabel.Name = "miscLabel";
            this.miscLabel.Size = new System.Drawing.Size(17, 17);
            this.miscLabel.TabIndex = 8;
            this.miscLabel.Text = "0";
            // 
            // skinsLabel
            // 
            this.skinsLabel.AutoSize = true;
            this.skinsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinsLabel.Location = new System.Drawing.Point(207, 39);
            this.skinsLabel.Name = "skinsLabel";
            this.skinsLabel.Size = new System.Drawing.Size(17, 17);
            this.skinsLabel.TabIndex = 9;
            this.skinsLabel.Text = "0";
            // 
            // tracksLabel
            // 
            this.tracksLabel.AutoSize = true;
            this.tracksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tracksLabel.Location = new System.Drawing.Point(126, 39);
            this.tracksLabel.Name = "tracksLabel";
            this.tracksLabel.Size = new System.Drawing.Size(17, 17);
            this.tracksLabel.TabIndex = 10;
            this.tracksLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 150);
            this.Controls.Add(this.tracksLabel);
            this.Controls.Add(this.skinsLabel);
            this.Controls.Add(this.miscLabel);
            this.Controls.Add(this.carsLabel);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.miscButton);
            this.Controls.Add(this.skinsButton);
            this.Controls.Add(this.tracksButton);
            this.Controls.Add(this.carsButton);
            this.Name = "Form1";
            this.Text = "RDScanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button carsButton;
        private System.Windows.Forms.Button tracksButton;
        private System.Windows.Forms.Button skinsButton;
        private System.Windows.Forms.Button miscButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.Label carsLabel;
        private System.Windows.Forms.Label miscLabel;
        private System.Windows.Forms.Label skinsLabel;
        private System.Windows.Forms.Label tracksLabel;
    }
}

