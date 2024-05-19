using Artifacts;
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
        player.AddArtifact(_artifactFactory.CreateArtifact(ArtifactTypeId.Poison));
    }

    public void SetBuff()
    {
    }
}
