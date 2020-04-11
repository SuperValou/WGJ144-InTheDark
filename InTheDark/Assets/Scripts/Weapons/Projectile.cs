using Assets.Scripts.Foes;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [Tooltip("Time in second")]
        public float lifetime = 1;

        [Tooltip("Speed in m/s")]
        public float speed = 1;

        public float damage = 5;
        
        private Rigidbody _rigidbody;
        
        void Start()
        {
            _rigidbody = this.GetOrThrow<Rigidbody>();
            _rigidbody.AddForce(_rigidbody.transform.forward * speed, ForceMode.Impulse);

            Invoke(nameof(DieOut), lifetime);
        }
        
        void OnCollisionEnter(Collision collision)
        {
            var foe = collision.gameObject.GetComponent<Foe>();
            if (foe != null)
            {
                foe.TakeDamage(damage);
            }

            DieOut();
            //ContactPoint contact = collision.GetContact(0);

            //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Vector3 position = contact.point;
        }

        void DieOut()
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}