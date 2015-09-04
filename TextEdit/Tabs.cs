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
        public int amountOfForms = 0;
        public TabPage[] tabsOpen = new TabPage[255];
        public void openTab()
        {
            Form1 frm1 = new Form1();

            OpenFileDialog fd = new OpenFileDialog();
            DialogResult userClickedOK = fd.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                RichTextBox tmp = new RichTextBox();
                tmp.Lines = File.ReadAllLines(fd.FileName, Encoding.Default);
                tmp.Dock = DockStyle.Fill;
                tmp.BackColor = SystemColors.ControlDarkDark;
                tmp.ForeColor = Color.White;
                tmp.WordWrap = false;
                tmp.Font = new Font("Arial", 10);

                TabPage tb = new TabPage(fd.FileName);
                tabsOpen[amountOfForms] = tb;

                //frm1.tabControl1.TabPages.Add(this.tabsOpen[amountOfForms]);
                tabsOpen[amountOfForms].Controls.Add(tmp);

                //frm1.tabControl1.SelectedTab = this.tabsOpen[amountOfForms];
            }
        }
    }
}
