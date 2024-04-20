using Artifacts;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private DynamicBlob.Core.DynamicBlob player;
    
    public void SetPoison()
    {
        player.AddArtifact(new PoisonArtifact());
    }

    public void SetBuff()
    {
        player.AddArtifact(new DamageArtifact());
    }
}
