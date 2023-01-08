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
            this.sparseDeathCheckBox = new System.Windows.Forms.CheckBox();
            this.ionSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.mountainSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.rocketSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.toothSplitChechBox = new System.Windows.Forms.CheckBox();
            this.gunSplitcheckBox = new System.Windows.Forms.CheckBox();
            this.endSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.startSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.sparseDeathCheckBox);
            this.MainPanel.Controls.Add(this.ionSplitCheckBox);
            this.MainPanel.Controls.Add(this.mountainSplitCheckBox);
            this.MainPanel.Controls.Add(this.rocketSplitCheckBox);
            this.MainPanel.Controls.Add(this.toothSplitChechBox);
            this.MainPanel.Controls.Add(this.gunSplitcheckBox);
            this.MainPanel.Controls.Add(this.endSplitCheckBox);
            this.MainPanel.Controls.Add(this.startSplitCheckBox);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(374, 469);
            this.MainPanel.TabIndex = 0;
            // 
            // sparseDeathCheckBox
            // 
            this.sparseDeathCheckBox.AutoSize = true;
            this.sparseDeathCheckBox.Location = new System.Drawing.Point(2, 169);
            this.sparseDeathCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sparseDeathCheckBox.Name = "sparseDeathCheckBox";
            this.sparseDeathCheckBox.Size = new System.Drawing.Size(219, 24);
            this.sparseDeathCheckBox.TabIndex = 7;
            this.sparseDeathCheckBox.Text = "Split on sparse deathwarp\r\n";
            this.sparseDeathCheckBox.UseVisualStyleBackColor = true;
            // 
            // ionSplitCheckBox
            // 
            this.ionSplitCheckBox.AutoSize = true;
            this.ionSplitCheckBox.Location = new System.Drawing.Point(2, 140);
            this.ionSplitCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ionSplitCheckBox.Name = "ionSplitCheckBox";
            this.ionSplitCheckBox.Size = new System.Drawing.Size(292, 24);
            this.ionSplitCheckBox.TabIndex = 6;
            this.ionSplitCheckBox.Text = "Split on getting ion battery blueprints\r\n";
            this.ionSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // mountainSplitCheckBox
            // 
            this.mountainSplitCheckBox.AutoSize = true;
            this.mountainSplitCheckBox.Location = new System.Drawing.Point(2, 90);
            this.mountainSplitCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mountainSplitCheckBox.Name = "mountainSplitCheckBox";
            this.mountainSplitCheckBox.Size = new System.Drawing.Size(266, 44);
            this.mountainSplitCheckBox.TabIndex = 5;
            this.mountainSplitCheckBox.Text = "Split on entering Mountains\r\nfrom Kelp Forest for the first time\r\n";
            this.mountainSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // rocketSplitCheckBox
            // 
            this.rocketSplitCheckBox.AutoSize = true;
            this.rocketSplitCheckBox.Location = new System.Drawing.Point(2, 61);
            this.rocketSplitCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rocketSplitCheckBox.Name = "rocketSplitCheckBox";
            this.rocketSplitCheckBox.Size = new System.Drawing.Size(254, 24);
            this.rocketSplitCheckBox.TabIndex = 4;
            this.rocketSplitCheckBox.Text = "Split on getting rocket blueprint\r\n";
            this.rocketSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // toothSplitChechBox
            // 
            this.toothSplitChechBox.AutoSize = true;
            this.toothSplitChechBox.Location = new System.Drawing.Point(2, 32);
            this.toothSplitChechBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toothSplitChechBox.Name = "toothSplitChechBox";
            this.toothSplitChechBox.Size = new System.Drawing.Size(360, 24);
            this.toothSplitChechBox.TabIndex = 3;
            this.toothSplitChechBox.Text = "Split on getting 4 stalker teeth for the first time\r\n";
            this.toothSplitChechBox.UseVisualStyleBackColor = true;
            // 
            // gunSplitcheckBox
            // 
            this.gunSplitcheckBox.AutoSize = true;
            this.gunSplitcheckBox.Location = new System.Drawing.Point(2, 198);
            this.gunSplitcheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunSplitcheckBox.Name = "gunSplitcheckBox";
            this.gunSplitcheckBox.Size = new System.Drawing.Size(214, 24);
            this.gunSplitcheckBox.TabIndex = 2;
            this.gunSplitcheckBox.Text = "Split on QEP deactivation";
            this.gunSplitcheckBox.UseVisualStyleBackColor = true;
            // 
            // endSplitCheckBox
            // 
            this.endSplitCheckBox.AutoSize = true;
            this.endSplitCheckBox.Location = new System.Drawing.Point(2, 228);
            this.endSplitCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.endSplitCheckBox.Name = "endSplitCheckBox";
            this.endSplitCheckBox.Size = new System.Drawing.Size(269, 44);
            this.endSplitCheckBox.TabIndex = 1;
            this.endSplitCheckBox.Text = "Split when rocket cutscene starts\r\n\r\n";
            this.endSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // startSplitCheckBox
            // 
            this.startSplitCheckBox.AutoSize = true;
            this.startSplitCheckBox.Location = new System.Drawing.Point(2, 2);
            this.startSplitCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startSplitCheckBox.Name = "startSplitCheckBox";
            this.startSplitCheckBox.Size = new System.Drawing.Size(268, 24);
            this.startSplitCheckBox.TabIndex = 0;
            this.startSplitCheckBox.Text = "Start after skipping first cutscene\r\n";
            this.startSplitCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubnauticaSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SubnauticaSettings";
            this.Size = new System.Drawing.Size(374, 469);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        public SubnauticaSettings()
        {
            InitializeComponent();
        }
        
        private Panel MainPanel;
        private CheckBox endSplitCheckBox;
        private CheckBox startSplitCheckBox;
        private CheckBox gunSplitcheckBox;
        private CheckBox toothSplitChechBox;
        private CheckBox rocketSplitCheckBox;
        private CheckBox mountainSplitCheckBox;
        private CheckBox ionSplitCheckBox;
        private CheckBox sparseDeathCheckBox;
    }
}
