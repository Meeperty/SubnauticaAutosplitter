using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubnauticaAutosplitter
{
    public class SubnauticaSplitter : IAutoSplitter
    {
        Process game;
        Timer memCheckTimer;
        bool lifepodCodeloaded = false;
        bool launchRocketCodeLoaded = false;

        private readonly SubnauticaSettings settings;
        internal SubnauticaSplitter(SubnauticaSettings settings)
        {
            this.settings = settings;
        }

        #region Memory & Such
        public void GetGameProcess()
        {
            if (game == null)
            {
                game = Process.GetProcessesByName("Subnautica").FirstOrDefault(p => !p.HasExited);
            }
        }

        public void CheckMemory(object o)
        {
            
        }
        
        #endregion

        #region Logic
        public bool ShouldSplit(LiveSplitState state)
        {
            throw new NotImplementedException();
        }

        public bool ShouldReset(LiveSplitState state)
        {
            throw new NotImplementedException();
        }
        
        public bool ShouldStart(LiveSplitState state)
        {
            if (game == null)
            {
                GetGameProcess();
                if (!(game == null))
                {
                    memCheckTimer = new Timer(CheckMemory, null, 0, 4000);
                }
                return false;
            }
            if (!lifepodCodeloaded)
            {

            }
            return false;
        }

        public bool IsGameTimePaused(LiveSplitState state) { return false; }
        public TimeSpan? GetGameTime(LiveSplitState state) { return null; }

        #endregion Logic
    }

    internal class Signature
    {
        public string sig;
        public int offset;

        public Signature(string s, int o)
        {
            sig = s;
            offset = o;
        }
    }
}
