using UnityEngine;

namespace Assets.Scripts.Foes
{
    public class Foe : MonoBehaviour
    {
        public float maxHealth = 20;
        
        public float CurrentHealth { get; private set; }

        public bool IsAlive => CurrentHealth > 0;

        void Start()
        {
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damages)
        {
            CurrentHealth -= damages;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}