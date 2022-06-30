using LiveSplit.UI.Components;
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubnauticaAutosplitter;

[assembly : ComponentFactory(typeof(SubnauticaFactory))]

namespace SubnauticaAutosplitter
{
    public class SubnauticaFactory : IComponentFactory
    {
        public string ComponentName => "Subnautica Autosplitter";

        public string Description => "Automatic start and stop for Subnautica";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => UpdateURL + "Subnautica.xml";

        public string UpdateURL => "https://raw.githubusercontent.com/Meeperty/SubnauticaAutosplitter/component/";

        public Version Version => Version.Parse("1.0.0");

        public IComponent Create(LiveSplitState state) => new SubnauticaComponent(state);
    }
}
