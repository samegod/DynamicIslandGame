using Artifacts;
using Artifacts.Enums;
using Artifacts.Factory;
using UnityEngine;
using Zenject;

public class test : MonoBehaviour
{
    [SerializeField] private DynamicBlob.Core.DynamicBlob player;
    private IArtifactFactory _artifactFactory;

    [Inject]
    private void Construct(IArtifactFactory artifactFactory)
    {
        _artifactFactory = artifactFactory;
    }
    
    public void SetPoison()
    {
        player.AddArtifact(_artifactFactory.CreateArtifact(ArtifactTypeId.LightningBolts));
    }

    public void SetBuff()
    {
        player.AddArtifact(_artifactFactory.CreateArtifact(ArtifactTypeId.Poison));
    }
}
