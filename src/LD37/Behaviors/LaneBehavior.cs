using Coldsteel.Scripting;
using LD37.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class LaneBehavior : Behavior
    {
        public bool IsComplete { get; private set; } = false;

        private Nexus _activeNexus;

        private List<Nexus> _nexusLevels = new List<Nexus>();

        private int _currentNexusLevel = 0;

        public void PushNexus(Nexus nexus)
        {
            _nexusLevels.Add(nexus);
            if (_nexusLevels.Count == 1)
                ActivateNexus(_currentNexusLevel);
        }

        public override void Update()
        {
            if (IsComplete)
                return;

            if (_activeNexus.IsDestroyed)
            {
                _currentNexusLevel++;

                if (_currentNexusLevel >= _nexusLevels.Count)
                {
                    _activeNexus = null;
                    IsComplete = true;
                    return;
                }

                ActivateNexus(_currentNexusLevel);
            }
        }

        private void ActivateNexus(int level)
        {
            _activeNexus = _nexusLevels[level];
            _activeNexus.Activate();
        }
    }
}
