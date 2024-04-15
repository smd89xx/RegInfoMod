using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegInfoMod
{
    public partial class maindlg : Form
    {
        const string regUsrNode = "RegisteredOwner";
        const string regOrgNode = "RegisteredOrganization";
        object usrName = "string.user.name";
        object orgName = "string.org.name";
        RegistryKey regKey = Registry.LocalMachine;
        public maindlg()
        {
            InitializeComponent();
        }
        private void getInfo()
        {
            usrName = regKey.GetValue(regUsrNode);
            orgName = regKey.GetValue(regOrgNode);
            regUsrBox.Text = usrName.ToString();
            regOrgBox.Text = orgName.ToString();
        }
        private void maindlg_Load(object sender, EventArgs e)
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\";
            try
            {
                regKey = regKey.CreateSubKey(key);
            }
            catch (UnauthorizedAccessException)
            {
                string text = "This program can only open in read-only mode, as it directly modifies the Windows Registry.\nRun this program as Administrator to write values.";
                string title = "Insufficient Permissions";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(text, title, button, icon);
                regKey = regKey.OpenSubKey(key);
                regUsrBox.Enabled = false;
                regOrgBox.Enabled = false;
                getInfoCmd.Enabled = false;
                updCmd.Enabled = false;
                getInfo();
                return;
                throw;
            }
            getInfo();
        }

        private void getInfoCmd_Click(object sender, EventArgs e)
        {
            string text = "This will replace text currently entered.\nAre you sure you would like to continue?";
            string title = "Confirm Reversion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Exclamation;
            DialogResult result = MessageBox.Show(text, title, buttons, icon);
            if (result == DialogResult.Yes)
            {
                getInfo();
            }
        }

        private void updCmd_Click(object sender, EventArgs e)
        {
            string text = "This will replace the current values with the one input here.\nAre you sure you would like to continue?\nAlso note that this program only takes visual effect after a reboot.";
            string title = "Confirm Update";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Exclamation;
            DialogResult result = MessageBox.Show(text, title, buttons, icon);
            if (result == DialogResult.Yes)
            {
                regKey.SetValue(regUsrNode, regUsrBox.Text);
                regKey.SetValue(regOrgNode, regOrgBox.Text);
            }
        }
    }
}
