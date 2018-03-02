using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationFileEditor.Dto
{
    public class TranslationKeyDto
    {
        public string Key { get; set; }
        public bool IsVisible { get; set; }
        public bool IsMissingTranslation { get; set; }
    }
}
