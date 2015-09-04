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
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            this.tabControl1.MouseClick += tabControl1_MouseClick;
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
            saveFile();
        }

        void saveFile()
        {
            var files = new Files();
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Tag;
            files.saveFile(tabControl1.SelectedTab.Text, rtb.Lines);
        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveFile();
            }
        }

        void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }
    }
}
