using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationFileEditor.Services
{
    public class RecentlyOpenedFolderService
    {
        public List<string> GetFolders()
        {
            List<string> recentlyOpenedFolders = new List<string>();

            string recentlyOpenedFoldersSetting = Properties.Settings.Default.RecentlyOpenedFolders;

            if (!string.IsNullOrEmpty(recentlyOpenedFoldersSetting))
            {
                recentlyOpenedFolders = recentlyOpenedFoldersSetting.Split(';').ToList();
            }

            return recentlyOpenedFolders;
        }

        public string CompressFolderPath(string path)
        {
            List<string> parts = path.Split('\\').ToList();

            if (parts.Count <= 2) return path;

            const int maxLength = 40;

            while (parts.Count > 2 && parts.Sum(p => p.Length) > maxLength)
            {
                parts.RemoveAt(1);
            }

            return parts[0] + "\\...\\" + string.Join("\\", parts.Skip(1));
        }

        public void AddFolder(string path)
        {
            string recentlyOpenedFoldersSetting = Properties.Settings.Default.RecentlyOpenedFolders;

            if (string.IsNullOrEmpty(recentlyOpenedFoldersSetting))
            {
                Properties.Settings.Default.RecentlyOpenedFolders = path;
            }
            else
            {
                List<string> recentlyOpenedFolders = recentlyOpenedFoldersSetting.Split(';').ToList();

                if (!recentlyOpenedFolders.Contains(path))
                {
                    recentlyOpenedFolders.Add(path);

                    Properties.Settings.Default.RecentlyOpenedFolders = string.Join(";", recentlyOpenedFolders);
                }
            }

            Properties.Settings.Default.Save();
        }
    }
}
