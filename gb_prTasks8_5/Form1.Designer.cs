namespace gb_prTasks8_5
{
    partial class MainForm
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
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(98)))), ((int)(((byte)(208)))));
            this.btnLoadCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(98)))), ((int)(((byte)(208)))));
            this.btnLoadCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadCSV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadCSV.Location = new System.Drawing.Point(12, 47);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(160, 49);
            this.btnLoadCSV.TabIndex = 0;
            this.btnLoadCSV.Text = "Load CSV";
            this.btnLoadCSV.UseVisualStyleBackColor = false;
            this.btnLoadCSV.Click += new System.EventHandler(this.btnLoadCSV_Click);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(98)))), ((int)(((byte)(208)))));
            this.btnSaveXML.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(98)))), ((int)(((byte)(208)))));
            this.btnSaveXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveXML.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveXML.Location = new System.Drawing.Point(204, 47);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(160, 49);
            this.btnSaveXML.TabIndex = 0;
            this.btnSaveXML.Text = "To XML";
            this.btnSaveXML.UseVisualStyleBackColor = false;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStatus.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbStatus.Location = new System.Drawing.Point(12, 132);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(352, 82);
            this.tbStatus.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 239);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.btnLoadCSV);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(397, 278);
            this.MinimumSize = new System.Drawing.Size(397, 278);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSVtoXML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadCSV;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.TextBox tbStatus;
    }
}

