using Artifacts;
using Artifacts.Enums;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    ArtifactsConfig GetArtifactConfig(ArtifactTypeId artifactTypeId);
  }
}