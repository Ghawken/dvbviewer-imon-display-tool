﻿namespace DVBViewer_iMonDisplayPlugin
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.timerConnect = new System.Windows.Forms.Timer(this.components);
            this.statusStripMainForm = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelDisplayType_ = new System.Windows.Forms.Label();
            this.timerUpdateData = new System.Windows.Forms.Timer(this.components);
            this.labelActiveChannel_ = new System.Windows.Forms.Label();
            this.labelActiveChannel = new System.Windows.Forms.Label();
            this.labelDisplayType = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxLogActive = new System.Windows.Forms.CheckBox();
            this.pictureBoxDvbvConnected = new System.Windows.Forms.PictureBox();
            this.pictureBoxiMonConnected = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxConnectionState = new System.Windows.Forms.GroupBox();
            this.statusStripMainForm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDvbvConnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxiMonConnected)).BeginInit();
            this.groupBoxConnectionState.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 173);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.ScrollAlwaysVisible = true;
            this.listBoxLog.Size = new System.Drawing.Size(460, 147);
            this.listBoxLog.TabIndex = 1;
            // 
            // timerConnect
            // 
            this.timerConnect.Tick += new System.EventHandler(this.timerConnect_Tick);
            // 
            // statusStripMainForm
            // 
            this.statusStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMainForm.Location = new System.Drawing.Point(0, 323);
            this.statusStripMainForm.Name = "statusStripMainForm";
            this.statusStripMainForm.Size = new System.Drawing.Size(484, 22);
            this.statusStripMainForm.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Init iMon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(93, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Uninit iMon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(397, 144);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 5;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelDisplayType_
            // 
            this.labelDisplayType_.AutoSize = true;
            this.labelDisplayType_.Location = new System.Drawing.Point(9, 149);
            this.labelDisplayType_.Name = "labelDisplayType_";
            this.labelDisplayType_.Size = new System.Drawing.Size(101, 13);
            this.labelDisplayType_.TabIndex = 6;
            this.labelDisplayType_.Text = "iMON Display Type:";
            // 
            // timerUpdateData
            // 
            this.timerUpdateData.Tick += new System.EventHandler(this.timerUpdateData_Tick);
            // 
            // labelActiveChannel_
            // 
            this.labelActiveChannel_.AutoSize = true;
            this.labelActiveChannel_.Location = new System.Drawing.Point(9, 125);
            this.labelActiveChannel_.Name = "labelActiveChannel_";
            this.labelActiveChannel_.Size = new System.Drawing.Size(82, 13);
            this.labelActiveChannel_.TabIndex = 7;
            this.labelActiveChannel_.Text = "Active Channel:";
            // 
            // labelActiveChannel
            // 
            this.labelActiveChannel.AutoSize = true;
            this.labelActiveChannel.Location = new System.Drawing.Point(116, 125);
            this.labelActiveChannel.Name = "labelActiveChannel";
            this.labelActiveChannel.Size = new System.Drawing.Size(51, 13);
            this.labelActiveChannel.TabIndex = 8;
            this.labelActiveChannel.Text = "unknown";
            // 
            // labelDisplayType
            // 
            this.labelDisplayType.AutoSize = true;
            this.labelDisplayType.Location = new System.Drawing.Point(116, 149);
            this.labelDisplayType.Name = "labelDisplayType";
            this.labelDisplayType.Size = new System.Drawing.Size(51, 13);
            this.labelDisplayType.TabIndex = 9;
            this.labelDisplayType.Text = "unknown";
            this.labelDisplayType.Click += new System.EventHandler(this.labelDisplayType_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dateiToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checkBoxLogActive
            // 
            this.checkBoxLogActive.AutoSize = true;
            this.checkBoxLogActive.Checked = true;
            this.checkBoxLogActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLogActive.Location = new System.Drawing.Point(428, 121);
            this.checkBoxLogActive.Name = "checkBoxLogActive";
            this.checkBoxLogActive.Size = new System.Drawing.Size(44, 17);
            this.checkBoxLogActive.TabIndex = 11;
            this.checkBoxLogActive.Text = "Log";
            this.checkBoxLogActive.UseVisualStyleBackColor = true;
            // 
            // pictureBoxDvbvConnected
            // 
            this.pictureBoxDvbvConnected.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBoxDvbvConnected.Location = new System.Drawing.Point(82, 19);
            this.pictureBoxDvbvConnected.Name = "pictureBoxDvbvConnected";
            this.pictureBoxDvbvConnected.Size = new System.Drawing.Size(78, 23);
            this.pictureBoxDvbvConnected.TabIndex = 12;
            this.pictureBoxDvbvConnected.TabStop = false;
            // 
            // pictureBoxiMonConnected
            // 
            this.pictureBoxiMonConnected.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBoxiMonConnected.Location = new System.Drawing.Point(82, 48);
            this.pictureBoxiMonConnected.Name = "pictureBoxiMonConnected";
            this.pictureBoxiMonConnected.Size = new System.Drawing.Size(78, 23);
            this.pictureBoxiMonConnected.TabIndex = 13;
            this.pictureBoxiMonConnected.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "DVBViewer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "iMon Display:";
            // 
            // groupBoxConnectionState
            // 
            this.groupBoxConnectionState.Controls.Add(this.pictureBoxDvbvConnected);
            this.groupBoxConnectionState.Controls.Add(this.label2);
            this.groupBoxConnectionState.Controls.Add(this.pictureBoxiMonConnected);
            this.groupBoxConnectionState.Controls.Add(this.label1);
            this.groupBoxConnectionState.Location = new System.Drawing.Point(314, 27);
            this.groupBoxConnectionState.Name = "groupBoxConnectionState";
            this.groupBoxConnectionState.Size = new System.Drawing.Size(170, 88);
            this.groupBoxConnectionState.TabIndex = 16;
            this.groupBoxConnectionState.TabStop = false;
            this.groupBoxConnectionState.Text = "Connection state";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 345);
            this.Controls.Add(this.groupBoxConnectionState);
            this.Controls.Add(this.checkBoxLogActive);
            this.Controls.Add(this.labelDisplayType);
            this.Controls.Add(this.labelActiveChannel);
            this.Controls.Add(this.labelActiveChannel_);
            this.Controls.Add(this.labelDisplayType_);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStripMainForm);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBoxLog);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "DVBViewer iMon Display Plugin" + " v" + this.ProductVersion;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStripMainForm.ResumeLayout(false);
            this.statusStripMainForm.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDvbvConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxiMonConnected)).EndInit();
            this.groupBoxConnectionState.ResumeLayout(false);
            this.groupBoxConnectionState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Timer timerConnect;
        private System.Windows.Forms.StatusStrip statusStripMainForm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Label labelDisplayType_;
        private System.Windows.Forms.Timer timerUpdateData;
        private System.Windows.Forms.Label labelActiveChannel_;
        private System.Windows.Forms.Label labelActiveChannel;
        private System.Windows.Forms.Label labelDisplayType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxLogActive;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxDvbvConnected;
        private System.Windows.Forms.PictureBox pictureBoxiMonConnected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxConnectionState;
    }
}

