﻿using System;
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

        internal bool GunSplit
        {
            get => gunSplitcheckBox.Checked;
            set => gunSplitcheckBox.Checked = value;
        }

        internal bool ToothSplit
        {
            get => toothSplitChechBox.Checked;
            set => toothSplitChechBox.Checked = value;
        }
    }
}
