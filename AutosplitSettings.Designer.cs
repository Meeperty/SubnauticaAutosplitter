
namespace SubnauticaAutosplit
{
    partial class AutosplitSettings
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
            this.startSplit = new System.Windows.Forms.CheckBox();
            this.endSplit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // startSplit
            // 
            this.startSplit.AutoSize = true;
            this.startSplit.Location = new System.Drawing.Point(4, 4);
            this.startSplit.Name = "startSplit";
            this.startSplit.Size = new System.Drawing.Size(113, 29);
            this.startSplit.TabIndex = 0;
            this.startSplit.Text = "startSplit";
            this.startSplit.UseVisualStyleBackColor = true;
            // 
            // endSplit
            // 
            this.endSplit.AutoSize = true;
            this.endSplit.Location = new System.Drawing.Point(4, 40);
            this.endSplit.Name = "endSplit";
            this.endSplit.Size = new System.Drawing.Size(109, 29);
            this.endSplit.TabIndex = 1;
            this.endSplit.Text = "endSplit";
            this.endSplit.UseVisualStyleBackColor = true;
            // 
            // AutosplitSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.endSplit);
            this.Controls.Add(this.startSplit);
            this.Name = "AutosplitSettings";
            this.Load += new System.EventHandler(this.AutosplitSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox startSplit;
        private System.Windows.Forms.CheckBox endSplit;
    }
}
