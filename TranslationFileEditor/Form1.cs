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

namespace TranslationFileEditor
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> TranslationsData = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, TextBox> TextBoxes = new Dictionary<string, TextBox>();
        private string OpenedFolder = null;
        string MainFile = null;

        public Form1()
        {
            InitializeComponent();
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
                lbKeys.DataSource = TranslationsData[MainFile].Keys.OrderBy(x => x).ToList();
                lbKeys.Enabled = true;

                InitTextBoxes();
                UpdateTextBoxValues(lbKeys.SelectedValue.ToString());
            }
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

            TranslationsData[file][lbKeys.SelectedValue.ToString()] = textbox.Text;
        }

        private void lbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxValues(lbKeys.SelectedValue.ToString());
        }

        private void UpdateTextBoxValues(string key)
        {
            foreach (KeyValuePair<string, TextBox> pair in TextBoxes)
            {
                pair.Value.Text = TranslationsData[pair.Key][key];
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> file in TranslationsData)
            {
                File.WriteAllText($"{OpenedFolder}/{file.Key}", JsonConvert.SerializeObject(file.Value, Formatting.Indented));
            }
        }
    }
}
