using System.Windows.Forms;

namespace SubnauticaAutosplitter
{
    partial class SubnauticaSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.endSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.startSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.endSplitCheckBox);
            this.MainPanel.Controls.Add(this.startSplitCheckBox);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(457, 563);
            this.MainPanel.TabIndex = 0;
            // 
            // endSplitCheckBox
            // 
            this.endSplitCheckBox.AutoSize = true;
            this.endSplitCheckBox.Location = new System.Drawing.Point(3, 38);
            this.endSplitCheckBox.Name = "endSplitCheckBox";
            this.endSplitCheckBox.Size = new System.Drawing.Size(359, 29);
            this.endSplitCheckBox.TabIndex = 1;
            this.endSplitCheckBox.Text = "Autosplit when rocket cutscene starts";
            this.endSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // startSplitCheckBox
            // 
            this.startSplitCheckBox.AutoSize = true;
            this.startSplitCheckBox.Location = new System.Drawing.Point(3, 3);
            this.startSplitCheckBox.Name = "startSplitCheckBox";
            this.startSplitCheckBox.Size = new System.Drawing.Size(355, 29);
            this.startSplitCheckBox.TabIndex = 0;
            this.startSplitCheckBox.Text = "Autostart after skipping first cutscene\r\n";
            this.startSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubnauticaSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "SubnauticaSettings";
            this.Size = new System.Drawing.Size(457, 563);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private CheckBox endSplitCheckBox;
        private CheckBox startSplitCheckBox;

        public SubnauticaSettings()
        {
            InitializeComponent();
        }
    }
}
