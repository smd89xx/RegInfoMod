using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegUsrInfo
{
    public partial class maindlg : Form
    {
        public maindlg()
        {
            InitializeComponent();
        }
        RegistryKey regKey = Registry.LocalMachine;
        const string regUsrNode = "RegisteredOwner";
        const string regOrgNode = "RegisteredOrganization";
        object usrName = "string.user.name";
        object orgName = "string.org.name";
        private void maindlg_Load(object sender, EventArgs e)
        {
            string arch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE",EnvironmentVariableTarget.Machine);
            Version osVersion = Environment.OSVersion.Version;
            if (osVersion.Major > 5)
            {
                string text = "This version of the program was designed for Windows XP x86-32 and below.\nDownload the \"-anycpu\" version for Windows Vista and above (all .NET architectures).";
                string title = "Invalid Version";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(text, title, buttons, icon);
                Environment.Exit(0);

            }
            else if (arch != "x86")
            {
                string text = "This version of the program was designed for x86-32 processors only.";
                string title = "Invalid Architecture";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(text, title, buttons, icon);
                Environment.Exit(0);
            }
            regKey = regKey.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\");
            getInfo();
        }
        private void getInfo()
        {
            usrName = regKey.GetValue(regUsrNode);
            orgName = regKey.GetValue(regOrgNode);
            regUsrBox.Text = usrName.ToString();
            regOrgBox.Text = orgName.ToString();
        }

        private void getInfoCmd_Click(object sender, EventArgs e)
        {
            string text = "This action will replace all text currently entered into the fields.\nAre you sure you would like to continue?";
            string title = "Confirm Reversion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result = MessageBox.Show(text, title, buttons, icon);
            if (result == DialogResult.Yes)
            {
                getInfo();
            }
        }

        private void updCmd_Click(object sender, EventArgs e)
        {
            string text = "This action will replace the registered owner and organization registry values with the text currently entered into the fields.\nAre you sure you would like to continue?";
            string title = "Confirm Registry Update";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result = MessageBox.Show(text, title, buttons, icon);
            if (result == DialogResult.Yes)
            {
                regKey.SetValue(regUsrNode, regUsrBox.Text);
                regKey.SetValue(regOrgNode, regOrgBox.Text);
            }
        }
    }
}