using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class AutoDestroy : MonoBehaviour
    {
        public float secondsBeforeAutoDestroy = 10;

        void Start()
        {
            Invoke(nameof(AutoDestruct), secondsBeforeAutoDestroy);
        }

        private void AutoDestruct()
        {
            Destroy(gameObject);
        }
    }
}