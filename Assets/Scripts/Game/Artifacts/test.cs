using Artifacts;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private DynamicBlob.Core.DynamicBlob player;
    
    public void DoIt()
    {
        player.AddArtifact(new PoisonArtifact());
    }
}
