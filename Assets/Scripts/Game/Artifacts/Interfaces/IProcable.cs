using Interfaces;

namespace Artifacts.Interfaces
{
    public interface IProcable : IArtifact
    {
        float GetProcChance();
        void Proc(IHittable target);
    }
}