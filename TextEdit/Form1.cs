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
            load_file_lines();
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Tag;
            rtb.VScroll += new EventHandler(load_file_lines1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void load_file_lines1(object sender, EventArgs e)
        {
            load_file_lines();
        }

        void load_file_lines()
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Tag;
            //MessageBox.Show("test");
            this.Invalidate();
            this.Refresh();
            //System.Threading.Thread.Sleep(1000);
            int topIndex = rtb.GetCharIndexFromPosition(new Point(1, 1));
            int bottomIndex = rtb.GetCharIndexFromPosition(new Point(rtb.ClientSize.Width, rtb.ClientSize.Height - 1));

            int topLine = rtb.GetLineFromCharIndex(topIndex);
            int bottomLine = rtb.GetLineFromCharIndex(bottomIndex) + 1;

            //MessageBox.Show(((bottomLine - topLine)).ToString());
            int linesShowing = bottomLine - topLine;
            //MessageBox.Show(linesShowing.ToString());

            int line = topLine + 1;
            int height = 25;
            //MessageBox.Show(topLine.ToString());
            for (int i = 1; i <= linesShowing; i++)
            {
                System.Drawing.Graphics testGraphics = this.CreateGraphics();
                string drawString = line.ToString();
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 9);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                float X = tabControl1.Location.X - 40;
                float Y = tabControl1.Location.Y + height;
                testGraphics.DrawString(drawString, drawFont, drawBrush, X, Y);
                drawFont.Dispose();
                drawBrush.Dispose();
                testGraphics.Dispose();
                line += 1;
                height = height + 16;
            }
        }
    }
}
