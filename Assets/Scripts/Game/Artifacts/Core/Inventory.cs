using System.Collections.Generic;
using Artifacts.Interfaces;

namespace Artifacts.Core
{
    public class Inventory
    {
        private readonly List<IArtifact> _allArtifacts = new List<IArtifact>();
        private readonly List<IProcable> _weaponProcables = new List<IProcable>();
        private readonly List<IProcable> _shieldProcables = new List<IProcable>();
        private readonly List<IStat> _stats = new List<IStat>();

        public List<IArtifact> AllArtifacts => _allArtifacts;
        public List<IProcable> WeaponProcables => _weaponProcables;
        public List<IProcable> ShieldProcables => _shieldProcables;

        public void AddArtifact(IArtifact newArtifact)
        {
            _allArtifacts.Add(newArtifact);

            switch (newArtifact)
            {
                case IProcable procable:
                    _weaponProcables.Add(procable);
                    break;
                case IStat stat:
                    _stats.Add(stat);
                    break;
            }
        }
    }
}