using Weapons.Core;

namespace Artifacts.Interfaces
{
    public interface IStat : IArtifact
    {
        void ApplyStats(Weapon weapon);
    }
}
