using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TextProcessor
{
    public partial class MainForm : Form
    {
        private string filePath;
        private ListBox lstFiles;
        private List<string> filePaths;
        private bool isDarkMode = false;

        public MainForm()
        {
            InitializeComponent(); // Vérifie que ce fichier existe bien
            InitializeAdditionalComponents();
            this.filePaths = new List<string>();
        }
        private void InitializeAdditionalComponents()
        {
            // lstFiles - Liste des fichiers sélectionnés
            lstFiles = new ListBox();
            lstFiles.Location = new System.Drawing.Point(12, 520);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new System.Drawing.Size(600, 100);
            this.Controls.Add(lstFiles);
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (lstFiles == null)
                {
                    lstFiles = new ListBox();
                    this.Controls.Add(lstFiles);
                }

                filePaths = openFileDialog.FileNames.ToList();
                lstFiles.Items.Clear();
                lstFiles.Items.AddRange(filePaths.ToArray());

                // Charger le contenu des fichiers correctement dans txtOriginal
                txtOriginal.Text = string.Join("\n------\n", filePaths.Select(File.ReadAllText));
            }
        }
        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            if (filePaths.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un ou plusieurs fichiers TXT.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string processedContent = "";

            foreach (var filePath in filePaths)
            {
                string text = File.ReadAllText(filePath);
                string processedText = TextProcessor.ProcessText(text);
                processedContent += processedText + "\n------\n";  // Concaténer tous les textes transformés

                string newFilePath = Path.Combine(Path.GetDirectoryName(filePath),
                                                Path.GetFileNameWithoutExtension(filePath) + "_modifié.txt");
                File.WriteAllText(newFilePath, processedText);
            }

            // Mise à jour txtProcessed avec le texte transformé
            txtProcessed.Text = processedContent.Trim(); 

            // Mise à jour des statistiques après traitement
            UpdateStats();

            MessageBox.Show("Tous les fichiers ont été traités et enregistrés !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateStats()
        {
            if (!chkShowStats.Checked)
            {
                lblStats.Text = "Statistiques du texte :";
                return;
            }

            // Génère les statistiques et les affiche
            var stats = TextStats.AnalyzeText(txtProcessed.Text);
            lblStats.Text = $"Lignes : {stats.lines}\n" +
                            $"Mots : {stats.words}\n" +
                            $"Caractères (avec espaces) : {stats.charsWithSpaces}\n" +
                            $"Caractères (sans espaces) : {stats.charsWithoutSpaces}\n" +
                            $"Mots fréquents : {string.Join(", ", stats.frequentWords.Select(kvp => $"{kvp.Key} ({kvp.Value})"))}";
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProcessed.Text))
            {
                MessageBox.Show("Aucun texte traité à enregistrer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                FileName = "output.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, txtProcessed.Text);
                MessageBox.Show("Fichier enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (filePaths != null) 
            {
                filePaths.Clear();
            }
            
            txtOriginal.Clear();
            txtProcessed.Clear();
            lblStats.Text = "Statistiques du texte :";
            
            lstFiles.Items.Clear();  
            
            txtSearch.Clear();
            txtReplace.Clear();
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Veuillez entrer un mot à rechercher.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtProcessed.Text))
            {
                txtProcessed.Text = txtProcessed.Text.Replace(txtSearch.Text, txtReplace.Text ?? "");
                MessageBox.Show($"Tous les '{txtSearch.Text}' ont été remplacés par '{txtReplace.Text}'.", "Remplacement effectué", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;

            if (isDarkMode)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;

                txtOriginal.BackColor = Color.Gray;
                txtOriginal.ForeColor = Color.White;
                txtProcessed.BackColor = Color.Gray;
                txtProcessed.ForeColor = Color.White;
                lblStats.ForeColor = Color.White;
                lstFiles.BackColor = Color.Gray;
                lstFiles.ForeColor = Color.White;

                // Mettre les boutons en mode sombre
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.DarkGray;
                        btn.ForeColor = Color.Black; // Texte en noir pour rester visible
                    }
                }

                btnDarkMode.Text = "Mode Clair";
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;

                txtOriginal.BackColor = SystemColors.Window;
                txtOriginal.ForeColor = SystemColors.WindowText;
                txtProcessed.BackColor = SystemColors.Window;
                txtProcessed.ForeColor = SystemColors.WindowText;
                lblStats.ForeColor = SystemColors.ControlText;
                lstFiles.BackColor = SystemColors.Window;
                lstFiles.ForeColor = SystemColors.WindowText;

                // Remettre les boutons en mode clair
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = SystemColors.ControlText; // Texte en noir par défaut
                    }
                }

                btnDarkMode.Text = "Mode Sombre";
            }
        }
        private void chkShowStats_CheckedChanged(object sender, EventArgs e)
        {
            lblStats.Visible = chkShowStats.Checked;

            if (chkShowStats.Checked)
            {
                UpdateStats();
            }
        }
        private void btnExportStats_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStats.Text) || lblStats.Text == "Statistiques du texte :")
            {
                MessageBox.Show("Aucune statistique disponible à exporter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv|JSON File (*.json)|*.json",
                FileName = "text_statistics"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string extension = Path.GetExtension(filePath);

                if (extension == ".csv")
                {
                    File.WriteAllText(filePath, ConvertStatsToCSV());
                }
                else if (extension == ".json")
                {
                    File.WriteAllText(filePath, ConvertStatsToJSON());
                }

                MessageBox.Show("Statistiques exportées avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string ConvertStatsToCSV()
        {
            return lblStats.Text.Replace("\n", ",");
        }

        private string ConvertStatsToJSON()
        {
            var stats = new
            {
                Lignes = lblStats.Text.Split('\n')[0].Split(':')[1].Trim(),
                Mots = lblStats.Text.Split('\n')[1].Split(':')[1].Trim(),
                CaractèresAvecEspaces = lblStats.Text.Split('\n')[2].Split(':')[1].Trim(),
                CaractèresSansEspaces = lblStats.Text.Split('\n')[3].Split(':')[1].Trim(),
                MotsFréquents = lblStats.Text.Split('\n')[4].Split(':')[1].Trim()
            };

            return System.Text.Json.JsonSerializer.Serialize(stats, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }
}
