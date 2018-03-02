using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationFileEditor.Dto;

namespace TranslationFileEditor
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> TranslationsData = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, TextBox> TextBoxes = new Dictionary<string, TextBox>();
        private List<TranslationKeyDto> TranslationKeys;
        private string OpenedFolder = null;
        string MainFile = null;

        bool HasUnsavedChanges = false;

        public Form1()
        {
            InitializeComponent();

            lblStatus.Text = string.Empty;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string directory = folderBrowserDialog1.SelectedPath;

                OpenedFolder = directory;
                btnSaveChanges.Enabled = true;

                IEnumerable<string> files = Directory.EnumerateFiles(directory, "*.json").Select(x => Path.GetFileName(x));

                cbMainLanguageSelector.DataSource = files.ToList();
                cbMainLanguageSelector.Enabled = true;

                foreach (string file in files)
                {
                    JObject obj = JObject.Parse(File.ReadAllText(directory + "/" + file));
                    Dictionary<string, string> translations = new Dictionary<string, string>();

                    foreach (KeyValuePair<string, JToken> item in obj)
                    {
                        translations.Add(item.Key, item.Value.ToString());
                    }

                    TranslationsData.Add(file, translations);
                }

                MainFile = files.First();

                TranslationKeys = TranslationsData[MainFile].Keys.OrderBy(x => x).Select(x => new TranslationKeyDto
                {
                    Key = x,
                    IsMissingTranslation = IsKeyMissingTranslation(x),
                    IsVisible = true
                }).ToList();

                lbKeys.DataSource = TranslationKeys;
                lbKeys.Enabled = true;

                tbxKeyFilter.Enabled = true;

                InitTextBoxes();
                UpdateTextBoxValues((lbKeys.SelectedValue as TranslationKeyDto).Key);
            }
        }

        private bool IsKeyMissingTranslation(string key)
        {
            return TranslationsData.Any(file => !file.Value.ContainsKey(key) || string.IsNullOrWhiteSpace(file.Value[key]));
        }

        private void InitTextBoxes()
        {
            tlpTranslations.RowCount = TranslationsData.Count;

            int rowIndex = 0;
            foreach (string file in TranslationsData.Keys.OrderByDescending(x => x == MainFile))
            {
                GroupBox group = new GroupBox()
                {
                    Text = file,
                    Dock = DockStyle.Fill,
                    MaximumSize = new Size(0, 100)
                };

                TextBox textbox = new TextBox()
                {
                    Top = 20,
                    Left = 20,
                    Width = 200,
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    Name = Guid.NewGuid().ToString()
                };

                textbox.TextChanged += Textbox_TextChanged;

                group.Controls.Add(textbox);
                TextBoxes[file] = textbox;

                tlpTranslations.Controls.Add(group, 0, rowIndex);
                rowIndex++;
            }
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string file = TextBoxes.First(x => x.Value.Name == textbox.Name).Key;

            TranslationKeyDto selectedKeyDto = lbKeys.SelectedValue as TranslationKeyDto;
            bool keyExists = TranslationsData[file].ContainsKey(selectedKeyDto.Key);

            string oldValue = keyExists ? TranslationsData[file][selectedKeyDto.Key] : string.Empty;

            if (oldValue != textbox.Text)
            {
                if (keyExists)
                {
                    TranslationsData[file][selectedKeyDto.Key] = textbox.Text;
                }
                else
                {
                    TranslationsData[file].Add(selectedKeyDto.Key, textbox.Text);
                }

                HasUnsavedChanges = true;
                lblStatus.Text = "You have unsaved changes";
                selectedKeyDto.IsMissingTranslation = IsKeyMissingTranslation(selectedKeyDto.Key);
            }
        }

        private void lbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            TranslationKeyDto selectedKeyDto = lbKeys.SelectedValue as TranslationKeyDto;
            UpdateTextBoxValues(selectedKeyDto.Key);
        }

        private void UpdateTextBoxValues(string key)
        {
            foreach (KeyValuePair<string, TextBox> pair in TextBoxes)
            {
                if (TranslationsData[pair.Key].ContainsKey(key))
                {
                    pair.Value.Text = TranslationsData[pair.Key][key];
                }
                else
                {
                    pair.Value.Text = string.Empty;
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Saving...";

            foreach (KeyValuePair<string, Dictionary<string, string>> file in TranslationsData)
            {
                File.WriteAllText($"{OpenedFolder}/{file.Key}", JsonConvert.SerializeObject(file.Value, Formatting.Indented));
            }

            lblStatus.Text = "Saved";
            HasUnsavedChanges = false;
        }

        private void btnGithubProject_Click(object sender, EventArgs e)
        {
            const string githubProjectUrl = "https://github.com/Trendays/TranslationFileEditor";
            System.Diagnostics.Process.Start(githubProjectUrl);
        }

        private void lbKeys_DrawItem(object sender, DrawItemEventArgs e)
        {
            TranslationKeyDto keyDto = lbKeys.Items[e.Index] as TranslationKeyDto;

            e.DrawBackground();
            Graphics g = e.Graphics;

            if (keyDto.IsMissingTranslation)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 220, 95)), e.Bounds);
            }

            g.DrawString(keyDto.Key, e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void btnNextMissing_Click(object sender, EventArgs e)
        {
            List<TranslationKeyDto> visibleKeys = TranslationKeys.Where(x => x.IsVisible).ToList();
            int selectedIndex = lbKeys.SelectedIndex;
            int nextIndex = visibleKeys.FindIndex(selectedIndex + 1, x => (x as TranslationKeyDto).IsMissingTranslation);

            if(nextIndex == -1)
            {
                nextIndex = visibleKeys.FindIndex(0, selectedIndex, x => (x as TranslationKeyDto).IsMissingTranslation);
            }

            if(nextIndex == -1)
            {
                nextIndex = selectedIndex;
            }

            lbKeys.SelectedIndex = nextIndex;
        }

        private void tbxKeyFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = tbxKeyFilter.Text;

            TranslationKeys.ForEach(key => key.IsVisible = string.IsNullOrWhiteSpace(filter) || key.Key.ToLowerInvariant().Contains(filter.ToLowerInvariant()));

            lbKeys.DataSource = TranslationKeys.Where(x => x.IsVisible).ToList();
        }
    }
}
