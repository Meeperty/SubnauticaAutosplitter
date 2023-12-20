using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components.AutoSplit;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace SubnauticaAutosplitter
{
    public class SubnauticaComponent : AutoSplitComponent
    {
        private static SubnauticaSettings settings = new SubnauticaSettings();
        static SubnauticaSplitter splitter = new SubnauticaSplitter(settings);

        internal SubnauticaComponent(LiveSplitState state) : base(splitter, state)
        {
            state.OnReset += OnReset;
        }
        
        public override string ComponentName => "Subnautica Autosplitter";

        public override void Dispose()
        {
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            splitter.Update();
            base.Update(invalidator, state, width, height, mode);
        }
        
        public void OnReset(object sender, TimerPhase t)
        {
            splitter.OnReset(t);
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

            XmlElement gunSplit_Node = document.CreateElement("gunSplit");
            gunSplit_Node.InnerText = settings.GunSplit.ToString();
            settings_Node.AppendChild(gunSplit_Node);

            XmlElement toothSplit_Node = document.CreateElement("toothSplit");
            toothSplit_Node.InnerText = settings.ToothSplit.ToString();
            settings_Node.AppendChild(toothSplit_Node);

            XmlElement rocketSplit_Node = document.CreateElement("rocketSplit");
            rocketSplit_Node.InnerText = settings.RocketSplit.ToString();
            settings_Node.AppendChild(rocketSplit_Node);

            XmlElement mountainSplit_node = document.CreateElement("mountainSplit");
            mountainSplit_node.InnerText = settings.MountainSplit.ToString();
            settings_Node.AppendChild(mountainSplit_node);

            XmlElement ionSplit_node = document.CreateElement("ionSplit");
            ionSplit_node.InnerText = settings.IonSplit.ToString();
            settings_Node.AppendChild(ionSplit_node);

            XmlElement sparseSplit_node = document.CreateElement("sparseSplit");
            sparseSplit_node.InnerText = settings.SparseSplit.ToString();
            settings_Node.AppendChild(sparseSplit_node);

            XmlElement unstuckPause_node = document.CreateElement("unstuckPause");
            unstuckPause_node.InnerText = settings.UnstuckPause.ToString();
            settings_Node.AppendChild(unstuckPause_node);

            //XmlElement {name}_node = document.CreateElement("{name}");
            //{name}_node.InnerText = settings.{Name}.ToString();
            //settings_Node.AppendChild({name}_node);

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
                WriteDebug($"endSplit set to {val2}");
            }
            if (bool.TryParse(node["gunSplit"]?.InnerText, out bool val3))
            {
                settings.GunSplit = val3;
                WriteDebug($"gunSplit set to {val3}");
            }
            if (bool.TryParse(node["toothSplit"]?.InnerText, out bool val4))
            {
                settings.ToothSplit = val4;
                WriteDebug($"toothSplit set to {val4}");
            }
            if (bool.TryParse(node["rocketSplit"]?.InnerText, out bool val5))
            {
                settings.RocketSplit = val5;
                WriteDebug($"rocketSplit set to {val5}");
            }
            if (bool.TryParse(node["mountainSplit"]?.InnerText, out bool val6))
            {
                settings.MountainSplit = val6;
                WriteDebug($"mountainSplit set to {val6}");
            }
            if (bool.TryParse(node["ionSplit"]?.InnerText, out bool val7))
            {
                settings.IonSplit = val7;
                WriteDebug($"ionSplit set to {val7}");
            }
            if (bool.TryParse(node["sparseSplit"]?.InnerText, out bool val8))
            {
                settings.SparseSplit = val8;
                WriteDebug($"sparseSplit set to {val8}");
            }
            if (bool.TryParse(node["unstuckPause"]?.InnerText, out bool val9))
            {
				settings.UnstuckPause = val9;
				WriteDebug($"unstuckPause set to {val9}");
			}
            //if (bool.TryParse(node["{name}"]?.InnerText, out bool val10))
			//{
			//    settings.{Name} = val10;
			//    WriteDebug($"{name} set to {val10}");
			//}
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
