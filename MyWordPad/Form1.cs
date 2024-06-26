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

namespace MyWordPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void alignToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt K");
        }
        private void XuLyLuuFile(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "My WordPad|*.rtf|*.txt|C# Code|*.cs";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(sfd.FileName);
                var extension = Path.GetExtension(sfd.FileName).ToLower();
                if(extension == ".txt"|| extension ==".cs")
                {
                    File.WriteAllText(sfd.FileName, RtbDoc.Text);
                }
                else if(extension == ".rtf")
                {
                    RtbDoc.SaveFile(sfd.FileName);
                }
            }
        }
        private void XuLyMoFile(object sender, EventArgs e)
        {
            var sfd = new OpenFileDialog();
            sfd.Filter = "My WordPad|*.rtf|*.txt|C# Code|*.cs|All file|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(sfd.FileName);
                var extension = Path.GetExtension(sfd.FileName).ToLower();
                if (extension == ".txt" || extension == ".cs")
                {
                    RtbDoc.Text = File.ReadAllText(sfd.FileName);
                }
                else if (extension == ".rtf")
                {
                    RtbDoc.LoadFile(sfd.FileName);
                }
            }
        }

        private void selectFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog();
            fd.ShowApply = true;
            fd.Apply += new EventHandler(XuLyApply);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                RtbDoc.SelectionFont = fd.Font;
            }
        }

        private void XuLyApply(object sender, EventArgs e)
        {
            RtbDoc.SelectionFont = (sender as FontDialog).Font;
            RtbDoc.SelectionColor = (sender as FontDialog).Color;
        }
    }
}
