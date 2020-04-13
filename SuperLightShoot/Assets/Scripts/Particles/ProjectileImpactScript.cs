using UnityEngine;

namespace Assets.Scripts.Particles
{
    public abstract class ProjectileImpactScript : MonoBehaviour
    {
        public abstract void Impact();
        public abstract void Explode();
        public abstract void DieOut();
    }
}