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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tabs = new Tabs();
            tabs.openTab();
            tabControl1.TabPages.Add(tabs.tabsOpen[tabs.amountOfTabs]);
            tabControl1.SelectedTab = tabs.tabsOpen[tabs.amountOfTabs];
            tabs.amountOfTabs += 1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tabs = new Tabs();
            var files = new Files();
            //RichTextBox rtb = Application.OpenForms["Form1"].Controls[tabControl1.SelectedTab.Text] as RichTextBox;
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Tag;
            files.saveFile(tabControl1.SelectedTab.Text, rtb.Lines);
        }
    }
}
