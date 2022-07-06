using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubnauticaAutosplitter
{
    public partial class SubnauticaSettings : UserControl
    {
        public SubnauticaSettings()
        {
            InitializeComponent();
        }

        internal bool StartSplit
        {
            get => startSplitCheckBox.Checked;
            set => startSplitCheckBox.Checked = value;
        }

        internal bool EndSplit
        {
            get => endSplitCheckBox.Checked;
            set => endSplitCheckBox.Checked = value;
        }
    }
}
