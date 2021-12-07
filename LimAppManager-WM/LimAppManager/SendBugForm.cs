using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LimAppManager
{
    public partial class SendBugForm : Form
    {
        Parameters.DebugInfo Info;

        public SendBugForm(Parameters.DebugInfo SysInfo)
        {
            InitializeComponent();

            Info = SysInfo;
        }

        private void CancelMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendMenuItem_Click(object sender, EventArgs e)
        {
            NetHelper Net = new NetHelper();
            Uri ServerUri = new Uri("http://limowski.xyz");

            if (Parameters.IsSendDebug) Net.SendErrorInfo(ServerUri, MessageBox.Text, Info);
            else Net.SendErrorInfo(ServerUri, MessageBox.Text);

            Close();
        }
    }
}