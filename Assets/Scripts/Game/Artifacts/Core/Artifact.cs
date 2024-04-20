using Artifacts.Interfaces;
using UnityEngine;

namespace Artifacts.Core
{
    public enum ArtifactName
    {
        DamageRange,
        Bolt,
        Heal,
        
    }
    
    public enum ImpactTarget
    {
        Weapon, 
        Shield,
        Stats,
        Other
    }
    
    public abstract class Artifact : IArtifact
    {
        
    }
}
