﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVBViewer_iMonDisplayPlugin
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void SettingsDialog_Load(object sender, System.EventArgs e)
        {
            this.checkBoxLogToWindow.Checked = Properties.Settings.Default.logToWindow;
            this.checkBoxLogtoFile.Checked = Properties.Settings.Default.logToFile;
            this.maskedTextBox1.Text = Properties.Settings.Default.scrollDelay.ToString();
        }

        private void checkBoxLogtoFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxLogtoFile.Checked)
                Properties.Settings.Default.logToFile = true;
            else
                Properties.Settings.Default.logToFile = false;

            Properties.Settings.Default.Save();
        }

        private void checkBoxLogToWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxLogToWindow.Checked)
                Properties.Settings.Default.logToWindow = true;
            else
                Properties.Settings.Default.logToWindow = false;

            Properties.Settings.Default.Save();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != null && maskedTextBox1.Text != String.Empty)
            {
                Properties.Settings.Default.scrollDelay = Convert.ToInt32(maskedTextBox1.Text);
                Properties.Settings.Default.Save();
            }
        }
    }
}
