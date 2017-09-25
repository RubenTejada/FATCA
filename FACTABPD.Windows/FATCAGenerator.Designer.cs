namespace FATCABPD.Windows
{
    partial class FATCAGenerator
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
            this.lblInputInfo = new System.Windows.Forms.Label();
            this.lblOutputInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listapplicationLog = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInputInfo
            // 
            this.lblInputInfo.AutoSize = true;
            this.lblInputInfo.Location = new System.Drawing.Point(37, 108);
            this.lblInputInfo.Name = "lblInputInfo";
            this.lblInputInfo.Size = new System.Drawing.Size(265, 13);
            this.lblInputInfo.TabIndex = 0;
            this.lblInputInfo.Text = "Coloque los archivos CSV de entrada en la carpeta {0}";
            // 
            // lblOutputInfo
            // 
            this.lblOutputInfo.AutoSize = true;
            this.lblOutputInfo.Location = new System.Drawing.Point(37, 135);
            this.lblOutputInfo.Name = "lblOutputInfo";
            this.lblOutputInfo.Size = new System.Drawing.Size(236, 13);
            this.lblOutputInfo.TabIndex = 1;
            this.lblOutputInfo.Text = "Los Archivos Serán Generados en la carpeta {0}";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listapplicationLog
            // 
            this.listapplicationLog.FormattingEnabled = true;
            this.listapplicationLog.HorizontalScrollbar = true;
            this.listapplicationLog.Location = new System.Drawing.Point(12, 225);
            this.listapplicationLog.Name = "listapplicationLog";
            this.listapplicationLog.ScrollAlwaysVisible = true;
            this.listapplicationLog.Size = new System.Drawing.Size(490, 225);
            this.listapplicationLog.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BPD.FATCA.Windows.Properties.Resources.Popular;
            this.pictureBox1.Location = new System.Drawing.Point(1, -54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 129);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Generador de Archivo FATCA";
            // 
            // FATCAGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listapplicationLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOutputInfo);
            this.Controls.Add(this.lblInputInfo);
            this.Name = "FATCAGenerator";
            this.Text = "Generador FATCA BPD";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputInfo;
        private System.Windows.Forms.Label lblOutputInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listapplicationLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

