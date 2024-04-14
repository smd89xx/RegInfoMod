using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegInfoMod
{
    public partial class maindlg : Form
    {
        string usrName = "string.user.name";
        string orgName = "string.org.name";
        const string regKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
        const string regUsrNode = "RegisteredOwner";
        const string regOrgNode = "RegisteredOrganization";
        public maindlg()
        {
            InitializeComponent();
        }
        private void getInfo()
        {
            usrName = Registry.GetValue(regKey, regUsrNode, "string.user.name").ToString();
            orgName = Registry.GetValue(regKey, regOrgNode, "string.org.name").ToString();
            regUsrBox.Text = usrName;
            regOrgBox.Text = orgName;
        }
        private void maindlg_Load(object sender, EventArgs e)
        {
            getInfo();
            try
            {
                Registry.SetValue(regKey, regUsrNode, usrName);
            }
            catch (UnauthorizedAccessException)
            {
                string text = "This program can not provide any real function without running as Administator, as it directly modifies the Windows Registry.";
                string title = "Insufficient Permissions";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(text, title, button, icon);
                regUsrBox.Enabled = false;
                regOrgBox.Enabled = false;
                getInfoCmd.Enabled = false;
                updCmd.Enabled = false;
                return;
                throw;
            }
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
                Registry.SetValue(regKey, regUsrNode, regUsrBox.Text);
                Registry.SetValue(regKey, regOrgNode, regOrgBox.Text);
            }
        }
    }
}
