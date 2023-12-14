using Additions.Pool;
using UnityEngine;

namespace Core
{
    public class Particles : MonoBehaviourPoolObject
    {
        [SerializeField] private ParticleSystem thisParticles;

        public ParticleSystem ThisParticles => thisParticles;
        
        private void OnEnable()
        {
            var main = thisParticles.main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }
        
        void OnParticleSystemStopped()
        {
            Debug.Log("System has stopped!");
            Push();
        }
        
        public override void Push()
        {
            ParticlesPool.Instance.Push(this);
        }
    }
}
