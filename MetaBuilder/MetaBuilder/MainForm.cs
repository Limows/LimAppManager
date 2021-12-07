using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaBuilder
{
    public partial class MainForm : Form
    {
        string PackageDir;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var Dialog = new FolderBrowserDialog())
            {
                DialogResult Result = Dialog.ShowDialog();

                if (Result == DialogResult.OK && !string.IsNullOrWhiteSpace(Dialog.SelectedPath))
                {
                    PackageDir = Dialog.SelectedPath;
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();
            About.ShowDialog();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(PackageDir))
            {

            }
            else
            {
                MessageBox.Show("Package directory not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
