using Additions.Pool;

namespace Weapons.Core
{
    public abstract class Aim : MonoBehaviourPoolObject
    {
        public override void Push()
        {
            AimsPool.Instance.Push(this);
        }
    }
}
