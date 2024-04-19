namespace RegUsrInfo
{
    partial class maindlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maindlg));
            this.regUsrLbl = new System.Windows.Forms.Label();
            this.regUsrBox = new System.Windows.Forms.TextBox();
            this.regOrgLbl = new System.Windows.Forms.Label();
            this.regOrgBox = new System.Windows.Forms.TextBox();
            this.getInfoCmd = new System.Windows.Forms.Button();
            this.updCmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regUsrLbl
            // 
            this.regUsrLbl.AutoSize = true;
            this.regUsrLbl.Location = new System.Drawing.Point(12, 9);
            this.regUsrLbl.Name = "regUsrLbl";
            this.regUsrLbl.Size = new System.Drawing.Size(95, 13);
            this.regUsrLbl.TabIndex = 0;
            this.regUsrLbl.Text = "Registered Owner:";
            // 
            // regUsrBox
            // 
            this.regUsrBox.Location = new System.Drawing.Point(15, 25);
            this.regUsrBox.Name = "regUsrBox";
            this.regUsrBox.Size = new System.Drawing.Size(373, 20);
            this.regUsrBox.TabIndex = 1;
            // 
            // regOrgLbl
            // 
            this.regOrgLbl.AutoSize = true;
            this.regOrgLbl.Location = new System.Drawing.Point(12, 48);
            this.regOrgLbl.Name = "regOrgLbl";
            this.regOrgLbl.Size = new System.Drawing.Size(123, 13);
            this.regOrgLbl.TabIndex = 2;
            this.regOrgLbl.Text = "Registered Organization:";
            // 
            // regOrgBox
            // 
            this.regOrgBox.Location = new System.Drawing.Point(15, 64);
            this.regOrgBox.Name = "regOrgBox";
            this.regOrgBox.Size = new System.Drawing.Size(373, 20);
            this.regOrgBox.TabIndex = 3;
            // 
            // getInfoCmd
            // 
            this.getInfoCmd.Location = new System.Drawing.Point(105, 90);
            this.getInfoCmd.Name = "getInfoCmd";
            this.getInfoCmd.Size = new System.Drawing.Size(92, 23);
            this.getInfoCmd.TabIndex = 4;
            this.getInfoCmd.Text = "Get Current Info";
            this.getInfoCmd.UseVisualStyleBackColor = true;
            this.getInfoCmd.Click += new System.EventHandler(this.getInfoCmd_Click);
            // 
            // updCmd
            // 
            this.updCmd.Location = new System.Drawing.Point(203, 90);
            this.updCmd.Name = "updCmd";
            this.updCmd.Size = new System.Drawing.Size(92, 23);
            this.updCmd.TabIndex = 5;
            this.updCmd.Text = "Update Info";
            this.updCmd.UseVisualStyleBackColor = true;
            this.updCmd.Click += new System.EventHandler(this.updCmd_Click);
            // 
            // maindlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 116);
            this.Controls.Add(this.updCmd);
            this.Controls.Add(this.getInfoCmd);
            this.Controls.Add(this.regOrgBox);
            this.Controls.Add(this.regOrgLbl);
            this.Controls.Add(this.regUsrBox);
            this.Controls.Add(this.regUsrLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "maindlg";
            this.Text = "Windows Registered User Info Modifier";
            this.Load += new System.EventHandler(this.maindlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label regUsrLbl;
        private System.Windows.Forms.TextBox regUsrBox;
        private System.Windows.Forms.Label regOrgLbl;
        private System.Windows.Forms.TextBox regOrgBox;
        private System.Windows.Forms.Button getInfoCmd;
        private System.Windows.Forms.Button updCmd;
    }
}

