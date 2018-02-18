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

                IEnumerable<string> files = Directory.EnumerateFiles(directory, "*.json").Select(x => Path.GetFileName(x));

                cbMainLanguageSelector.DataSource = files.ToList();
                cbMainLanguageSelector.Enabled = true;

                foreach (string file in files)
                {
                    JObject obj = JObject.Parse(File.ReadAllText(directory + "/" + files.First()));
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
            }
        }

        private void lbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpTranslations.RowCount = TranslationsData.Count;

            GroupBox defaultGroup = new GroupBox()
            {
                Text = MainFile,
                Dock = DockStyle.Fill,
                MaximumSize = new Size(0, 100)
            };

            defaultGroup.Controls.Add(new TextBox()
            {
                Text = TranslationsData[MainFile][lbKeys.SelectedValue.ToString()],
                Top = 20,
                Left = 20,
                Width = 200
            });
            
            tlpTranslations.Controls.Add(defaultGroup, 0, 0);

            foreach(string file in TranslationsData.Keys.Where(x => x != MainFile))
            {
                GroupBox group = new GroupBox()
                {
                    Text = file,
                    Dock = DockStyle.Fill,
                    MaximumSize = new Size(0, 100)
                };

                group.Controls.Add(new TextBox()
                {
                    Text = TranslationsData[file][lbKeys.SelectedValue.ToString()],
                    Top = 20,
                    Left = 20,
                    Width = 200
                });

                tlpTranslations.Controls.Add(group, 0, 1);
            }
        }
    }
}
