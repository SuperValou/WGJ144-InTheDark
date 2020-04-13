using System.Linq;
using Assets.Scripts.Utilities;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class GunBulletDieOutScript : ProjectileImpactScript
    {
        public float attenuationTime = 3;
        
        private MeshRenderer _renderer;
        
        void Awake()
        {
            _renderer = this.GetOrThrow<MeshRenderer>();
            _renderer.enabled = false;
        }

        public override void Impact()
        {
            _renderer.enabled = true;
            _renderer.materials.First().DOFade(0, attenuationTime);

            Explode();
        }

        public override void Explode()
        {
            DieOut();
        }

        public override void DieOut()
        {
            Invoke(nameof(AutoDestroy), attenuationTime + 1);
        }
        
        private void AutoDestroy()
        {
            Destroy(this.gameObject);
        }
    }
}