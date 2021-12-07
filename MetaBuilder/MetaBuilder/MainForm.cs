using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetaBuilderLib;

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
                    NameBox.Text = PackageDir.Split('\\').Last();
                    OsBox.Text = PackageDir.Split('\\')[PackageDir.Split('\\').Length - 2];
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
                Parameters.Package Package = new Parameters.Package();
                string Json;

                Package.System = OsBox.Text;
                Package.Name = NameBox.Text;
                Package.PackageName = FileSystem.GetPackageName(PackageDir, "cab");
                Package.Description = DescriptionBox.Text;
                Package.IsCompressed = FileSystem.CheckCompression(PackageDir);
                Package.Hash = "";
                Package.IconName = FileSystem.GetIconName(PackageDir);
                Package.ShotName = FileSystem.GetShotName(PackageDir);
                Package.Size = FileSystem.GetPackageSize(PackageDir, "cab");
                Package.Maintainer = MaintainerBox.Text;
                Package.Origin = OriginBox.Text;
                Package.Version = VersionBox.Text;

                Json = MetaInfo.GenerateMetaFile(Package);

                FileSystem.WriteMetaFile(PackageDir, Json);
            }
            else
            {
                MessageBox.Show("Package directory not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
