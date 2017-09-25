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
            this.SuspendLayout();
            // 
            // lblInputInfo
            // 
            this.lblInputInfo.AutoSize = true;
            this.lblInputInfo.Location = new System.Drawing.Point(37, 24);
            this.lblInputInfo.Name = "lblInputInfo";
            this.lblInputInfo.Size = new System.Drawing.Size(265, 13);
            this.lblInputInfo.TabIndex = 0;
            this.lblInputInfo.Text = "Coloque los archivos CSV de entrada en la carpeta {0}";
            // 
            // lblOutputInfo
            // 
            this.lblOutputInfo.AutoSize = true;
            this.lblOutputInfo.Location = new System.Drawing.Point(37, 54);
            this.lblOutputInfo.Name = "lblOutputInfo";
            this.lblOutputInfo.Size = new System.Drawing.Size(236, 13);
            this.lblOutputInfo.TabIndex = 1;
            this.lblOutputInfo.Text = "Los Archivos Serán Generados en la carpeta {0}";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 96);
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
            this.listapplicationLog.Location = new System.Drawing.Point(12, 139);
            this.listapplicationLog.Name = "listapplicationLog";
            this.listapplicationLog.ScrollAlwaysVisible = true;
            this.listapplicationLog.Size = new System.Drawing.Size(490, 225);
            this.listapplicationLog.TabIndex = 3;
            // 
            // FATCAGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 376);
            this.Controls.Add(this.listapplicationLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOutputInfo);
            this.Controls.Add(this.lblInputInfo);
            this.Name = "FATCAGenerator";
            this.Text = "Generador FATCA";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputInfo;
        private System.Windows.Forms.Label lblOutputInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listapplicationLog;
    }
}

