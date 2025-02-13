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

        public MainForm()
        {
            InitializeComponent(); // Vérifie que ce fichier existe bien
            this.filePaths = new List<string>();
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
                filePaths = openFileDialog.FileNames.ToList();
                if (lstFiles == null)
                {
                    lstFiles = new ListBox();
                    this.Controls.Add(lstFiles);
                }
                lstFiles.Items.Clear();
                lstFiles.Items.AddRange(filePaths.ToArray());
                txtOriginal.Text = string.Join("\n------\n", filePaths.Select(File.ReadAllText));
            }
        }
        private async void btnProcessFile_Click(object sender, EventArgs e)
        {

            if (filePaths == null || filePaths.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un ou plusieurs fichiers TXT.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string originalText = txtOriginal.Text;
            string[] lines = originalText.Split(new[] { '\n' }, StringSplitOptions.None);

            progressBar.Visible = true;
            progressBar.Value = 0;

            int totalLines = lines.Length;
            int batchSize = 500; // Traiter 500 lignes à la fois
            int processedLines = 0;
            string processedText = "";

            await Task.Run(() =>
            {
                for (int i = 0; i < totalLines; i += batchSize)
                {
                    int remainingLines = Math.Min(batchSize, totalLines - i);
                    string batch = string.Join("\n", lines.Skip(i).Take(remainingLines));

                    processedText += TextProcessor.ProcessText(batch) + "\n";

                    processedLines += remainingLines;
                    this.Invoke(new Action(() =>
                    {
                        progressBar.Value = (processedLines * 100) / totalLines;
                    }));
                }
            });

            txtProcessed.Text = processedText;
            progressBar.Visible = false;
            MessageBox.Show("Traitement terminé !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
