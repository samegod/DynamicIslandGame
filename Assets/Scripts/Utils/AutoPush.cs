using System.Collections;
using Additions.Pool;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(MonoBehaviourPoolObject))]
    public class AutoPush : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        private Coroutine _lifeCoroutine;
        private MonoBehaviourPoolObject _poolObject;

        private void Awake()
        {
            _poolObject = GetComponent<MonoBehaviourPoolObject>();
            _poolObject.OnPopped += Popped;
            _poolObject.OnPushed += Pushed;
        }
        
        private void Popped()
        {
            _lifeCoroutine = StartCoroutine(Life());
        }

        private void Pushed()
        {
            if (_lifeCoroutine != null)
            {
                StopCoroutine(_lifeCoroutine);
            }
        }
        
        private IEnumerator Life()
        {
            yield return new WaitForSeconds(lifeTime);
            _poolObject.Push();
        }
    }
}
