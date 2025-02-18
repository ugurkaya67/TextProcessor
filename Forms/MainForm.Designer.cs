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
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnDarkMode;
        private System.Windows.Forms.CheckBox chkShowStats;
        private System.Windows.Forms.Button btnExportStats;

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
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnDarkMode = new System.Windows.Forms.Button();
            
            this.SuspendLayout();
            
            // btnLoadFile
            this.btnLoadFile.Location = new System.Drawing.Point(12, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(130, 30);
            this.btnLoadFile.Text = "Charger un fichier";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);

            // btnProcessFile
            this.btnProcessFile = new System.Windows.Forms.Button();
            this.btnProcessFile.Location = new System.Drawing.Point(160, 12);
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Size = new System.Drawing.Size(120, 30);
            this.btnProcessFile.Text = "Traiter le fichier";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);
            this.Controls.Add(this.btnProcessFile);

            // btnSaveFile
            this.btnSaveFile.Location = new System.Drawing.Point(320, 12);
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

            // btnReset
            btnReset = new Button();
            btnReset.Location = new System.Drawing.Point(480, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(120, 30);
            btnReset.Text = "Réinitialiser";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += new EventHandler(btnReset_Click);


            // Recherche et Remplacement
            lblSearch = new Label();
            lblSearch.Location = new System.Drawing.Point(12, 480);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(100, 25);
            lblSearch.Text = "Rechercher :";


            txtSearch = new TextBox();
            txtSearch.Location = new System.Drawing.Point(120, 480);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(120, 25);


            lblReplace = new Label();
            lblReplace.Location = new System.Drawing.Point(250, 480);
            lblReplace.Name = "lblReplace";
            lblReplace.Size = new System.Drawing.Size(100, 25);
            lblReplace.Text = "Remplacer par :";


            txtReplace = new TextBox();
            txtReplace.Location = new System.Drawing.Point(360, 480);
            txtReplace.Name = "txtReplace";
            txtReplace.Size = new System.Drawing.Size(120, 25);


            btnReplace = new Button();
            btnReplace.Location = new System.Drawing.Point(500, 480);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new System.Drawing.Size(120, 30);
            btnReplace.Text = "Remplacer";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += new EventHandler(btnReplace_Click);


            // lblStats
            this.lblStats = new System.Windows.Forms.Label();
            this.lblStats.Location = new System.Drawing.Point(12, 360);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(400, 60);
            this.lblStats.Text = "Statistiques du texte :";
            this.lblStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStats.Padding = new System.Windows.Forms.Padding(5);

            // ProgressBar
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBar.Location = new System.Drawing.Point(12, 550);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(600, 20);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Visible = false;
            this.Controls.Add(this.progressBar);
            
            // Bouton pour le mode sombre
            
            btnDarkMode.Location = new System.Drawing.Point(640, 12);
            btnDarkMode.Name = "btnDarkMode";
            btnDarkMode.Size = new System.Drawing.Size(120, 30);
            btnDarkMode.Text = "Mode Sombre";
            btnDarkMode.UseVisualStyleBackColor = true;
            btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);
            
            // chkShowStats - Activer/Désactiver les statistiques
            chkShowStats = new System.Windows.Forms.CheckBox();
            chkShowStats.Location = new System.Drawing.Point(12, 430);
            chkShowStats.Name = "chkShowStats";
            chkShowStats.Size = new System.Drawing.Size(200, 25);
            chkShowStats.Text = "Afficher les statistiques";
            chkShowStats.Checked = true; // Statistiques activées par défaut
            chkShowStats.CheckedChanged += new System.EventHandler(this.chkShowStats_CheckedChanged);
            

            // btnExportStats - Exporter les statistiques
            btnExportStats = new System.Windows.Forms.Button();
            btnExportStats.Location = new System.Drawing.Point(220, 430);
            btnExportStats.Name = "btnExportStats";
            btnExportStats.Size = new System.Drawing.Size(150, 40);
            btnExportStats.Text = "Exporter les statistiques";
            btnExportStats.UseVisualStyleBackColor = true;
            btnExportStats.Click += new System.EventHandler(this.btnExportStats_Click);
            

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnProcessFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.txtProcessed);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(btnDarkMode);
            this.Controls.Add(chkShowStats);
            this.Controls.Add(btnExportStats);

            this.Name = "MainForm";
            this.Text = "Text Processor";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
    }
}
