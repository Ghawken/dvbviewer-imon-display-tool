namespace DVBViewer_iMonDisplayPlugin
{
    partial class SettingsDialog
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
            this.checkBoxLogtoFile = new System.Windows.Forms.CheckBox();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.checkBoxLogToWindow = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxLogtoFile
            // 
            this.checkBoxLogtoFile.AutoSize = true;
            this.checkBoxLogtoFile.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLogtoFile.Name = "checkBoxLogtoFile";
            this.checkBoxLogtoFile.Size = new System.Drawing.Size(236, 17);
            this.checkBoxLogtoFile.TabIndex = 0;
            this.checkBoxLogtoFile.Text = "Log to file (debug.log in application directory)";
            this.checkBoxLogtoFile.UseVisualStyleBackColor = true;
            this.checkBoxLogtoFile.CheckedChanged += new System.EventHandler(this.checkBoxLogtoFile_CheckedChanged);
            // 
            // groupBoxLogging
            // 
            this.groupBoxLogging.Controls.Add(this.checkBoxLogToWindow);
            this.groupBoxLogging.Controls.Add(this.checkBoxLogtoFile);
            this.groupBoxLogging.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Size = new System.Drawing.Size(317, 69);
            this.groupBoxLogging.TabIndex = 1;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // checkBoxLogToWindow
            // 
            this.checkBoxLogToWindow.AutoSize = true;
            this.checkBoxLogToWindow.Location = new System.Drawing.Point(6, 43);
            this.checkBoxLogToWindow.Name = "checkBoxLogToWindow";
            this.checkBoxLogToWindow.Size = new System.Drawing.Size(273, 17);
            this.checkBoxLogToWindow.TabIndex = 1;
            this.checkBoxLogToWindow.Text = "Log to application window (only important messages)";
            this.checkBoxLogToWindow.UseVisualStyleBackColor = true;
            this.checkBoxLogToWindow.CheckedChanged += new System.EventHandler(this.checkBoxLogToWindow_CheckedChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(178, 407);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxLogging);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "SettingsDialog";
            this.Text = "SettingsDialog";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.groupBoxLogging.ResumeLayout(false);
            this.groupBoxLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxLogtoFile;
        private System.Windows.Forms.GroupBox groupBoxLogging;
        private System.Windows.Forms.CheckBox checkBoxLogToWindow;
        private System.Windows.Forms.Button buttonClose;
    }
}