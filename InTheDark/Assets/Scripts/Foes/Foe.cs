using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Foes
{
    public class Foe : MonoBehaviour
    {
        public Material hitMaterial;
        public float maxHealth = 20;
        
        private MeshRenderer[] _renderers;
        private Material[] _materials;

        public float CurrentHealth { get; private set; }

        public bool IsAlive => CurrentHealth > 0;

        void Start()
        {
            CurrentHealth = maxHealth;
            _renderers = this.GetComponentsInChildren<MeshRenderer>();

            var materials = _renderers.SelectMany(r => r.materials).ToList();
            _materials = new Material[materials.Count];

            int index = 0;
            foreach (var material in materials)
            {
                _materials[index] = material;
                index++;
            }
        }

        public void TakeDamage(float damages)
        {
            CurrentHealth -= damages;

            Debug.Log("ARGH");
            foreach (var meshRenderer in _renderers)
            {
                for (int i = 0; i < meshRenderer.materials.Length; i++)
                {
                    meshRenderer.materials[i] = hitMaterial;
                    //Debug.Log($"{meshRenderer.gameObject.name} - material {i} : {meshRenderer.materials[i].name}");
                }
            }

            //Invoke(nameof(RestoreColors), 3);

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

        private void RestoreColors()
        {
            int index = 0;
            foreach (var meshRenderer in _renderers)
            {
                for (int i = 0; i < meshRenderer.materials.Length; i++)
                {
                    meshRenderer.materials[i] = _materials[index];
                    index++;
                }
            }
        }
    }
}