using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit;
using LiveSplit.UI.Components.AutoSplit;
using LiveSplit.Model;
using System.Xml;
using LiveSplit.UI;
using System.Windows.Forms;

namespace SubnauticaAutosplitter
{
    public class SubnauticaComponent : AutoSplitComponent
    {
        internal SubnauticaComponent(LiveSplitState state) : base(new SubnauticaSplitter(settings), state) { }

        private readonly static SubnauticaSettings settings = new SubnauticaSettings(); 

        public override string ComponentName => "Subnautica Autosplitter";


        public override void Dispose()
        {
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public override void SetSettings(XmlNode settings)
        {
            throw new NotImplementedException();
        }
    }
}
