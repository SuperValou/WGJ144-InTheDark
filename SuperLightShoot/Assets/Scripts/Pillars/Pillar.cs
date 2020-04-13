using System;
using Assets.Scripts.Controllers;
using Assets.Scripts.Foes;
using Assets.Scripts.Utilities;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Pillars
{
    public class Pillar : MonoBehaviour
    {
        public float explosionRadius = 20;
        public AudioClip explosionSound;

        private AudioSource _audioSource;

        void Start()
        {
            _audioSource = this.GetOrThrow<AudioSource>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag != "Foe")
            {
                return;
            }

            var attackingFoe = collision.gameObject.GetComponent<Foe>();
            if (attackingFoe == null)
            {
                return;
            }

            attackingFoe.Kill();

            // kill nearby foes
            Vector3 explosionPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Collider[] nearbyColliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
            foreach (Collider nearbyCollider in nearbyColliders)
            {
                var nearbyFoe = nearbyCollider.GetComponent<Foe>();
                if (nearbyFoe == null)
                {
                    continue;
                }

                nearbyFoe.Kill();
            }

            _audioSource.PlayOneShot(explosionSound);

            Destroy(this.gameObject);
        }
    }
}