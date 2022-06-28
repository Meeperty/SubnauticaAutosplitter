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
        static SubnauticaSplitter splitter = new SubnauticaSplitter(settings);

        internal SubnauticaComponent(LiveSplitState state) : base(splitter, state) { }

        private readonly static SubnauticaSettings settings = new SubnauticaSettings(); 

        public override string ComponentName => "Subnautica Autosplitter";

        public override void Dispose()
        {
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            splitter.Update();
            base.Update(invalidator, state, width, height, mode);
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settings_Node = document.CreateElement("Settings");
            return settings_Node;
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        public override void SetSettings(XmlNode settings)
        {
            
        }
    }
}
