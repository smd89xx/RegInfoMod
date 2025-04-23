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
        enum msgIndices : byte
        {
            generic = 0xFF,
            reqPerms = 0x00,
            ovrReg,
            ovrFields,
            completeAction,
            overloadedString,
        }
        public maindlg()
        {
            InitializeComponent();
        }
        private void getInfo()
        {
            usrName = regKey.GetValue(regUsrNode);
            regUsrBox.Text = usrName.ToString();
            try
            {
                orgName = regKey.GetValue(regOrgNode);
                regOrgBox.Text = orgName.ToString();
            }
            catch (NullReferenceException)
            {
                return;
            }
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
                statusMsg(msgIndices.reqPerms);
                regKey = regKey.OpenSubKey(key);
                regUsrBox.Enabled = false;
                regOrgBox.Enabled = false;
                getInfoCmd.Enabled = false;
                updCmd.Enabled = false;
                getInfo();
                return;
            }
            getInfo();
        }

        private void getInfoCmd_Click(object sender, EventArgs e)
        {
            DialogResult result = statusMsg(msgIndices.ovrFields);
            if (result == DialogResult.Yes)
            {
                getInfo();
                statusMsg(msgIndices.completeAction);
            }
        }

        private void updCmd_Click(object sender, EventArgs e)
        {
            DialogResult mainResult = statusMsg(msgIndices.ovrReg);
            if (mainResult == DialogResult.Yes)
            {
                DialogResult charResult;
                if (regOrgBox.Text.Length >= 52 || regUsrBox.Text.Length >= 52)
                {
                    charResult = statusMsg(msgIndices.overloadedString);
                    if (charResult == DialogResult.No)
                    {
                        return;
                    }
                }
                regKey.SetValue(regUsrNode, regUsrBox.Text);
                regKey.SetValue(regOrgNode, regOrgBox.Text);
                statusMsg(msgIndices.completeAction);
            }
        }
        private static DialogResult statusMsg(msgIndices index = msgIndices.generic)
        {
            string text, caption;
            MessageBoxButtons buttons;
            MessageBoxIcon icon;
            switch (index)
            {
                case msgIndices.completeAction:
                    {
                        text    = "The requested action was completed successfully.";
                        caption = "Data Updated";
                        buttons =  MessageBoxButtons.OK;
                        icon    =  MessageBoxIcon.Asterisk;
                        break;
                    }
                case msgIndices.reqPerms:
                    {
                        text    = "This program can only open in read-only mode, as the Registry keys it wants to modify require Administrator privileges.";
                        caption = "Insufficient Permissions";
                        buttons =  MessageBoxButtons.OK;
                        icon    =  MessageBoxIcon.Hand;
                        break;
                    }
                case msgIndices.ovrReg:
                    {
                        text = "This will replace the current registered owner and organization strings in the Registry with those entered in the respective fields.\nAre you sure you would like to continue?";
                        caption = "Confirm Action";
                        buttons = MessageBoxButtons.YesNo;
                        icon = MessageBoxIcon.Warning;
                        break;
                    }
                case msgIndices.ovrFields:
                    {
                        text = "This will replace the strings in the data fields with the corresponding Registry values.\nAre you sure you would like to continue?";
                        caption = "Confirm Action";
                        buttons = MessageBoxButtons.YesNo;
                        icon = MessageBoxIcon.Warning;
                        break;
                    }
                case msgIndices.overloadedString:
                    {
                        text = "One or more of the fields contains more than 52 characters. \"Winver.exe\" can only display the first 52 characters of your chosen string(s).\nAre you sure you would like to keep them as-is?";
                        caption = "Confirm Action";
                        buttons = MessageBoxButtons.YesNo;
                        icon = MessageBoxIcon.Warning;
                        break;
                    }
                default:
                    {
                        text    = "You shouldn't see this. If you are, one of us fucked up somewhere.";
                        caption = "Generic Error";
                        buttons =  MessageBoxButtons.OK;
                        icon    =  MessageBoxIcon.Hand;
                        break;
                    }
            }
            DialogResult result = MessageBox.Show(text, caption, buttons, icon);
            return result;
        }
    }
}
