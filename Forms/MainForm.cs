using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TextProcessor
{
    public partial class MainForm : Form
    {
        private string filePath;

        public MainForm()
        {
            InitializeComponent(); // Vérifie que ce fichier existe bien
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                txtOriginal.Text = File.ReadAllText(filePath);
            }
        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Veuillez d'abord charger un fichier TXT.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string processedText = TextProcessor.ProcessText(txtOriginal.Text);
            txtProcessed.Text = processedText;

            // Obtenir les statistiques du texte
            var stats = TextStats.AnalyzeText(processedText);

            // Afficher les statistiques dans lblStats
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
    }
}
