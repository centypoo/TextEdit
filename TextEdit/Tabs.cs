using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TextEdit
{
    class Tabs
    {
        public int amountOfTabs = 0;
        public TabPage[] tabsOpen = new TabPage[255];
        //public RichTextBox[] textBoxes = new RichTextBox[255];

        public void openTab()
        {
            Form1 frm1 = new Form1();
            

            OpenFileDialog fd = new OpenFileDialog();
            DialogResult userClickedOK = fd.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                RichTextBox tmp = new RichTextBox();
                tmp.Name = "test";
                tmp.Lines = File.ReadAllLines(fd.FileName, Encoding.Default);
                tmp.Dock = DockStyle.Fill;
                tmp.BackColor = SystemColors.ControlDarkDark;
                tmp.ForeColor = Color.White;
                tmp.WordWrap = false;
                tmp.Font = new Font("Arial", 10);
                //textBoxes[amountOfTabs] = tmp;

                TabPage tb = new TabPage(fd.FileName);
                //tb.Tag = textBoxes[amountOfTabs];
                tb.Tag = tmp;
                tabsOpen[amountOfTabs] = tb;

                tabsOpen[amountOfTabs].Controls.Add(tmp);
            }
        }
    }
}
