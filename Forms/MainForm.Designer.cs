namespace TextProcessor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.TextBox txtOriginal;
        private System.Windows.Forms.TextBox txtProcessed;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnProcessFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.txtProcessed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            // btnLoadFile
            this.btnLoadFile.Location = new System.Drawing.Point(12, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(120, 30);
            this.btnLoadFile.Text = "Charger un fichier";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);

            // btnProcessFile
            this.btnProcessFile.Location = new System.Drawing.Point(138, 12);
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Size = new System.Drawing.Size(120, 30);
            this.btnProcessFile.Text = "Traiter le fichier";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);

            // btnSaveFile
            this.btnSaveFile.Location = new System.Drawing.Point(264, 12);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(120, 30);
            this.btnSaveFile.Text = "Enregistrer";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);

            // txtOriginal
            this.txtOriginal.Location = new System.Drawing.Point(12, 48);
            this.txtOriginal.Multiline = true;
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(372, 150);
            this.txtOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // txtProcessed
            this.txtProcessed.Location = new System.Drawing.Point(12, 204);
            this.txtProcessed.Multiline = true;
            this.txtProcessed.Name = "txtProcessed";
            this.txtProcessed.Size = new System.Drawing.Size(372, 150);
            this.txtProcessed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnProcessFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.txtProcessed);
            this.Name = "MainForm";
            this.Text = "Text Processor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
