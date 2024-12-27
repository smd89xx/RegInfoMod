using Microsoft.Win32;
using System;
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
                string text = "This program can only open in read-only mode, as the Registry keys it wants to modify require Administrator privileges.";
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
            string text = "This will replace all text currently entered into the fields with the current registered owner and organization in the Registry.\nAre you sure you would like to continue?";
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
            string text = "This will replace the current registered owner and organization in the Registry with the text entered in the fields.\nAre you sure you would like to continue?";
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
