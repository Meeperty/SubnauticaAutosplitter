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
using System.Diagnostics;

namespace SubnauticaAutosplitter
{
    public class SubnauticaComponent : AutoSplitComponent
    {
        private static SubnauticaSettings settings = new SubnauticaSettings();
        static SubnauticaSplitter splitter = new SubnauticaSplitter(settings);

        internal SubnauticaComponent(LiveSplitState state) : base(splitter, state) { }

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

            XmlElement startSplit_Node = document.CreateElement("startSplit");
            startSplit_Node.InnerText = settings.StartSplit.ToString();
            settings_Node.AppendChild(startSplit_Node);

            XmlElement endSplit_Node = document.CreateElement("endSplit");
            endSplit_Node.InnerText = settings.EndSplit.ToString();
            settings_Node.AppendChild(endSplit_Node);

            return settings_Node;
        }

        public override void SetSettings(XmlNode node)
        {
            if (bool.TryParse(node["startSplit"]?.InnerText, out bool val))
            {
                settings.StartSplit = val;
                WriteDebug($"startSplit set to {val}");
            }
            if (bool.TryParse(node["endSplit"]?.InnerText, out bool val2))
            {
                settings.EndSplit = val2;
                WriteDebug($"endSplit set to {val}");
            }
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        private void WriteDebug(string message)
        {
            Debug.WriteLine($"[Subnautica Component] {message}");
        }
    }
}
