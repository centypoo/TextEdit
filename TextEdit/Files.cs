using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEdit
{
    class Files
    {
        Form1 frm1 = new Form1();
        public void saveFile(string fileName, string[] lines)
        {
            File.WriteAllLines(fileName, lines);
        }
    }
}
