using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinMobileNetCFExt;

namespace LimAppManager
{
    public partial class InstalledForm : Form
    {
        public InstalledForm()
        {
            InitializeComponent();
        }

        private void PropMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(InstalledBox.Text))
            {
                AboutAppBox NewAboutAppBox = new AboutAppBox(InstalledBox.Text);
                NewAboutAppBox.ShowDialog();
            }
            else
            {
                MessageBox.Show("Приложение не выбрано", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            bool IsUninstalled = false;

            if (!String.IsNullOrEmpty(InstalledBox.Text))
            {
                Cursor.Current = Cursors.WaitCursor;
                IsUninstalled = SystemHelper.AppUninstall(InstalledBox.Text);
                Cursor.Current = Cursors.Default;

                if (!IsUninstalled)
                {
                    MessageBox.Show("Удаление не удалось");
                }
            }
            else
            {
                MessageBox.Show("Приложение не выбрано", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            GetAppsList();
        }

        private void GetAppsList()
        {
            InstalledBox.DataSource = null;
            InstalledBox.Items.Clear();

            try
            {
                List<string> InstalledList = new List<string>();
                InstalledList = SystemHelper.GetInstalledApps();

                foreach (string app in InstalledList)
                {
                    InstalledBox.Items.Add(app);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void InstalledForm_Load(object sender, EventArgs e)
        {
            GetAppsList();

            try
            {
                MemLabel.Text = "Free memory amount: " + Parameters.BytesToMegs(IO.GetStorageSpace(Parameters.InstallPath)).ToString("0.##") + " MB";
            }
            catch (ArgumentNullException)
            {
                MemLabel.Text = "Free memory amount: 0 MB";
            }
        }

        private void InstalledForm_Closing(object sender, CancelEventArgs e)
        {
            if (Parameters.OSVersion == 4 && Parameters.IsUninstalling)
            {
                e.Cancel = true;
                Parameters.IsUninstalling = false;
            }
        }

        private void BackMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}