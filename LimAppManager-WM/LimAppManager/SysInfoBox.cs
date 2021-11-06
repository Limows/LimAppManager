using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace LimAppManager
{
    public partial class SysInfoBox : Form
    {
        Parameters.DebugInfo SysInfo;

        public SysInfoBox(Parameters.DebugInfo Info)
        {
            InitializeComponent();

            SysInfo = Info;

            this.Text = String.Format("System info");
            this.labelOSVersion.Text = String.Format("OS version: {0}", SystemVersion);
            this.labelDeviceName.Text = String.Format("Device name: {0}", SystemDeviceName);
            this.labelScreenSize.Text = String.Format("Screen size: {0}", SystemScreenSize);
            this.labelCPU.Text = String.Format("CPU: {0}", SystemCpu);
            this.labelRAM.Text = String.Format("RAM size: {0}", SystemRamSize);
            this.labelDrive.Text = String.Format("Space amount: {0}", SystemDriveSpace);
        }

        public string SystemVersion
        {
            get
            {
                switch (SysInfo.OSVersion)
                {
                    case Parameters.OSVersions.WM2003:
                        return "Windows Mobile 2003";
                    case Parameters.OSVersions.WM5:
                        return "Windows Mobile 5";
                    case Parameters.OSVersions.WM6:
                        return "Windows Mobile 6";
                    case Parameters.OSVersions.CE4:
                        return "Windows CE 4";
                    case Parameters.OSVersions.CE5:
                        return "Windows CE 5";
                    case Parameters.OSVersions.CE6:
                        return "Windows CE6";
                    default:
                        return "Windows CE";
                }
            }
        }

        public string SystemDeviceName
        {
            get
            {
                return SysInfo.DeviceName;
            }
        }

        public string SystemScreenSize
        {
            get
            {
                return SysInfo.ScreenHeight + " x " + Parameters.SysInfo.ScreenWidth;
            }
        }

        public string SystemCpu
        {   
            get
            {
                return SysInfo.Cpu;
            }
        }

        public string SystemRamSize
        {
            get
            {
                return SysInfo.RamSize.ToString("0.##") + " MB";
            }
        }

        public string SystemDriveSpace
        {
            get
            {
                return SysInfo.DriveSpace.ToString("0.##") + " MB";
            }
        }

        private void OKMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}