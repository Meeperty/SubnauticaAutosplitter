using System;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace SubnauticaAutosplit
{
    class AutosplitFactory : IComponentFactory
    {
        public string ComponentName => "Subnautica Autosplit";

        public string Description => "Automatic splitting for subnautica by Meeperty and Stonetooth";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("0.1.0");

        public IComponent Create(LiveSplitState state) => new AutosplitComponent(state);
    }
}
